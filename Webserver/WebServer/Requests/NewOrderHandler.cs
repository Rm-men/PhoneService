using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using ServiceDB.Models;
using Trivial.Security;
using WebServer.Models;

namespace WebServer.Requests
{
    [RequestHandlerPath("/usercabinet")]
    public class NewOrderHandler : RequestHandler
    {
        private string GenerateToken(Client cl)
        {
            var model = new JsonWebTokenPayload
            {
                Id = Guid.NewGuid().ToString("n"),
                Issuer = $"{cl.Email}",
                Expiration = DateTime.Now + new TimeSpan(365, 0, 0, 0)
            };
            var jwt = new JsonWebToken<JsonWebTokenPayload>(model, Program.Sign);

            var jwtStr = jwt.ToEncodedString();
            return jwtStr;
        }

        [Post("/neworder")]
        public void NewOrder()
        {

            var body = Bind<NewOrderModel>();
            if (body is null || string.IsNullOrEmpty(body.Email) || string.IsNullOrEmpty(body.Address) || string.IsNullOrEmpty(body.Phonenumber))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

            var user = Client.GetUserByMail(body.Email);

            var order = new Order(body.Phonenumber, body.Address, user.IdClient, body.IdPhone, body.Descriptionord );
            if (order is null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var ormod = new NewOrderModel(order);
            if (!order.AddOrder())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request"));
                return;
            }
            Send(new AnswerModel(true, new { order = order }, null, null));
        }

        [Get("getorder")]
        public void GetOrder()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

            var user = TokenWorker.GetUserByToken(token);
            if (user is null)
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            List<Order.OrderInfo> orders = Order.GetOrdersForUser(user.Email);

            Send(new AnswerModel(true, new { orders = orders }, null, null));
        }
    }
}
