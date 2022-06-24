using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using ServiceDB;
using ServiceDB.Models;
using Trivial.Security;
using WebServer.Models;
using static ServiceDB.Models.OnOrderCmp;
using static ServiceDB.Models.OnOrderSrv;
using static ServiceDB.Models.Order;

namespace WebServer.Requests
{
    [RequestHandlerPath("/usercabinet")]
    public class OrdersHandler : RequestHandler
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

            PhoneModel ph = PhoneModel.getPhoneModel(body.Namephone);

            var ord = new Order(body.Phonenumber, body.Address, user.IdClient, ph.IdPhoneModel, body.Descriptionord );
            if (ord is null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var order = new NewOrderModel(ord);
            if (!ord.AddOrder())
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
            List<OrderInfo> orders = GetOrdersInfoForUser(user.IdClient);

            Send(new AnswerModel(true, new { orders = orders }, null, null));
        }
        [Get("setagree")]
        public void SetAgree()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }

            if (!Order.GetOrder(int.Parse(id)).SetAgree(true))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request"));
                return;
            }

            Send(new AnswerModel(true, null, null, null));
        }
        [Get("setdisagree")]
        public void SetDisAgree()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            /*            var user = TokenWorker.GetUserByToken(token);
                        if (user is null)
                        {
                            Send(new AnswerModel(false, null, 400, "incorrect request"));
                            return;
                        }*/
            if (!Order.GetOrder(int.Parse(id)).SetAgree(false))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request"));
                return;
            }
            Send(new AnswerModel(true, null, null, null));
        }
        [Get("setpay")]
        public void SetPay()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }



            try {
                var user = TokenWorker.GetUserByToken(token);
                OrderInfo oi = Order.GetOrderInfo(int.Parse(id));
                SendTicket(oi, user);
                if (!Order.GetOrder(int.Parse(id)).SetPay())
                {
                    Send(new AnswerModel(false, null, 401, "incorrect request"));
                    return;
                }
            }
            catch { 

            };

            Send(new AnswerModel(true, null, null, null));
        }
        public static void SendTicket(OrderInfo order, Client user)
        {
            var from = new MailAddress("service_phone_in_kirov@mail.ru", "Ремонт телефонов IFixeg");
            var to = new MailAddress("ro.sym@yandex.ru", "Пользователь");
            var message = new MailMessage(from, to);

            message.Subject = "Чек за ремонт";
            message.Body = ConstructTicket(order, user);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient("smtp.mail.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("service_phone_in_kirov@mail.ru", "ie4Kbk8Oua0DE3JLvaA5");
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
        public static string ConstructTicket(OrderInfo order, Client user)
        {
            List<OnOrderCmpInfo> cmp = OnOrderCmp.GetServicesFor(order.IdOrder);
            List<OnOrderSrvInfo> srv = OnOrderSrv.GetServicesFor(order.IdOrder);

            var s = new StringBuilder("<h2 style = \"text-align:center;\">" + user.Family + " " + user.Namecl + user.Patronymic+", оплата прошла успешна.</h2>" + Environment.NewLine);
            s.Append("<dl>" + Environment.NewLine);
            s.Append("<dt>Заказ №" + order.IdOrder + "</dt>" + Environment.NewLine);
            s.Append("<dd>Устройство: " + order.PhoneModel + "</dd>" + Environment.NewLine);
            s.Append("<dd>Описание неисправности: " + order.Descriptionord + "</dd>" + Environment.NewLine);
            s.Append("<dd>Заключение диагностики: " + order.Diagnostic + "</dd>" + Environment.NewLine);
            s.Append("</dl>" + Environment.NewLine);
            s.Append("<table>" + Environment.NewLine);

                 s.Append("<thead>" + Environment.NewLine);
                     s.Append("<tr>" + Environment.NewLine);
                        s.Append("<th>Услуга</th>" + Environment.NewLine);
                        s.Append("<th>Стоимость</th>" + Environment.NewLine);
                    s.Append("</tr>" + Environment.NewLine);
                s.Append("</thead>" + Environment.NewLine);

                s.Append("<tbody>" + Environment.NewLine);
            foreach (OnOrderSrvInfo service in srv)
            {
                s.Append("<tr>" + Environment.NewLine);
                s.Append("<th>"+ service .Namesrv + "</th>" + Environment.NewLine);
                s.Append("<th>"+ service.Costsrv + "</th>" + Environment.NewLine);
                s.Append("</tr>" + Environment.NewLine);
            }
                s.Append("</tbody>" + Environment.NewLine);

            s.Append("<div><br></div>" + Environment.NewLine);

            if (cmp.Count > 0)
            {
                s.Append("<thead>" + Environment.NewLine);
                s.Append("<tr>" + Environment.NewLine);
                s.Append("<th>Компонент</th>" + Environment.NewLine);
                s.Append("<th>Стоимость</th>" + Environment.NewLine);
                s.Append("</tr>" + Environment.NewLine);
                s.Append("</thead>" + Environment.NewLine);


                s.Append("<tbody>" + Environment.NewLine);
                foreach (OnOrderCmpInfo cm in cmp)
                {
                    s.Append("<tr>" + Environment.NewLine);
                    s.Append("<th>" + cm.Namecmp + "</th>" + Environment.NewLine);
                    s.Append("<th>" + cm.Pricecmp + "</th>" + Environment.NewLine);
                    s.Append("</tr>" + Environment.NewLine);
                }
                s.Append("</tbody>" + Environment.NewLine);
            }

            s.Append("<div><br></div>" + Environment.NewLine);

            s.Append("</table>" + Environment.NewLine);
            s.Append("<dt>Сумма платежа: <strong>" + order.Priceord + "</strong></dt>" + Environment.NewLine);


            return s.ToString();
        }
    }
}
