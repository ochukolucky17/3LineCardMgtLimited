using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _3LineCardMgtLimited.Security
{
    public class HeaderAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.GetValues("authorization") == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            if (actionContext.Request.Headers.GetValues("timeStamp") == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            if (actionContext.Request.Headers.GetValues("appKey") == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                var authorization = actionContext.Request.Headers.GetValues("authorization").FirstOrDefault();
                var timeStamp = actionContext.Request.Headers.GetValues("timeStamp").FirstOrDefault();
                var appKey = actionContext.Request.Headers.GetValues("appKey").FirstOrDefault();
                if (!ValidateSecuritySessionKey(authorization, timeStamp, appKey))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

        }

        private bool ValidateSecuritySessionKey(string authorization, string appKey, string timeStamp)
        {
            string[] authParams = authorization.Split();
            string hashed = authParams[1];
            String orig = Hash512(appKey + timeStamp);


            if (orig != hashed.ToLower())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string Hash512(String s)
        {

            HashAlgorithm Hasher = new SHA512CryptoServiceProvider();
            byte[] strBytes = Encoding.UTF8.GetBytes(s);
            byte[] strHash = Hasher.ComputeHash(strBytes);
            return BitConverter.ToString(strHash).Replace("-", "").ToLowerInvariant().Trim();
        }
    }

}
