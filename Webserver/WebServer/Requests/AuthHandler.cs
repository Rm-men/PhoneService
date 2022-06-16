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
    [RequestHandlerPath("/auth")]
    public class AuthHandler : RequestHandler
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

        [Post("/signin")]
        public void LoginUser()
        {

            var body = Bind<AuthModel>();
            if (body is null || string.IsNullOrEmpty(body.email) || string.IsNullOrEmpty(body.password))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }

            var user = Client.GeUserForAuth(body.email, body.password);
            if (user is null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var client = new ClientModel(user);

            Send(new AnswerModel(true, new { access_token = GenerateToken(user), user = client }, null, null));
        }

        [Post("/signon")]
        public void RegisterUser()
        {
            
/*            var body = Bind<RegModel>();
            if (RegModel.Check(body))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request"));
                return;
            }
            Client user;
            if (!Client.IsHasUser(body.phone))
            {
                user = new Client(body!.surname, body.name, body.phone)
                {
                    NameOfCompany = body.nameOfCompany == "" ? null : body.nameOfCompany,
                    Middlename = body.middlename == "" ? null : body.middlename,
                    Email = body.email == "" ? null : body.email,
                    Login = body.login,
                    Password = body.password
                };
                var team = new Team("Моя команда", user);

                if (!user.Add() || !team.Add())
                {
                    Send(new AnswerModel(false, null, 401, "incorrect request"));
                    return;
                }

                if (user.NameOfCompany == null) 
                {
                    var aloneTeam = new Team("Пойти в одиночку", user);
                    var aloneTeammate = new Teammate(aloneTeam, user) { IsActive = true, IsTeammate =true};
                    if (!aloneTeam.Add() || !aloneTeammate.Add())
                    {
                        Send(new AnswerModel(false, null, 401, "incorrect request"));
                        return;
                    }
                }                          
            }
            else
            {
                user = User.GetUserByPhoneNumber(body.phone);
            }
            var client = new ClientModel(user);
            Send(new AnswerModel(true, new { access_token = GenerateToken(user), user = client }, null, null));*/
        }
    }
}
