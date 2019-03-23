using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication15
{
    public class MyAuthentication : AuthorizeAttribute
    {
        protected override bool 
            IsAuthorized(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Authorization == null)
            {
                return false;
            }
            else
            {
                string authenticationHeader = 
                    actionContext.Request.Headers.Authorization.Parameter;
                string decodedHeader = 
                    Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeader));

                string[] userPass = decodedHeader.Split(':');
                string username = userPass[0];
                string password = userPass[1];

                if (username == "Joe" && password == "HumberRocks")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            
        }
    }
}