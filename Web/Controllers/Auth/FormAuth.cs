﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using System.Web;

namespace Web.Controllers.WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class FormAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }

                var cookie = actionContext.Request.Headers.GetCookies();
                if (cookie == null || cookie.Count < 1)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }

                FormsAuthenticationTicket ticket = null;

                foreach (var perCookie in cookie[0].Cookies)
                {
                    if (perCookie.Name == FormsAuthentication.FormsCookieName)
                    {
                        ticket = FormsAuthentication.Decrypt(perCookie.Value);
                        break;
                    }
                }

                if (ticket == null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }

                

                // TODO: 添加其它验证方法

                base.OnActionExecuting(actionContext);
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }

    }
}
