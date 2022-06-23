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
using static ServiceDB.Models.Order;

namespace WebServer.Requests
{
    [RequestHandlerPath("/get")]
    public class InfoListHandler : RequestHandler
    {

        [Get("addres")]
        public void GetAddress()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

/*            var user = TokenWorker.GetUserByToken(token);
            if (user is null)
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }*/
            List<LM_Adress> addresses = LM_Adress.GetAdresses();

            Send(new AnswerModel(true, new { addresses = addresses }, null, null));
        }

        [Get("phones")]
        public void GetPhones()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) || !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

/*            var user = TokenWorker.GetUserByToken(token);
            if (user is null)
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }*/
            List<LM_PhoneModels> phonemodels = LM_PhoneModels.GetPhoneModels();

            Send(new AnswerModel(true, new { phonemodels = phonemodels }, null, null));
        }
        [Get("ordmove")]
        public void GetOrdMove()
        {
            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
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
            List<LM_OrderStoryMove> ordmoves = LM_OrderStoryMove.GetOrderMoves(int.Parse(id));

            Send(new AnswerModel(true, new { ordmoves = ordmoves }, null, null));
        }

    }
}
