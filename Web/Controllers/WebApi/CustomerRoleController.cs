﻿using System.Web.Http;
using System.Threading.Tasks;
using Models;
using Helper.T;
using BLL;
using Helper;
using Newtonsoft.Json;
using Web.Controllers.WebApi;

namespace Web.Controllers.WebApi
{
    [FormAuth]
    [RoutePrefix("api/customer/role")]
    public class CustomerRoleController : ApiController
    {
        // GET api/<controller>
        [Route("gets")]
        [HttpPost]
        [HttpGet]
        public async Task<object> GetRoles(CustomerParams param)
        {
            param.CategoryId = "0";
            param.Cids = new string[] { };
            var data = await T_Customer_BLL.GetCustomers(param);
            return Ok(new
            {
                statusCode = 200,
                result = data
            });
        }

        [Route("get")]
        [HttpPost]
        [HttpGet]
        public async Task<object> GetRole(T_Customer_Role model)
        {
            object o = new { };
            //if (model.Input0 != null)
            //{
            string s = string.Empty;
            //s = POSTJson.ResolveTJSON(model);
            //customer = JsonConvert.DeserializeObject<T_Customer>(s);
            o = await T_Customer_BLL.GetCustomerRole(model.Cid);
            //}
            return Ok(new
            {
                statusCode = 200,
                result = o
            });
        }

        [Route("check")]
        [HttpPost]
        public async Task<object> CheckCustomer(string userName)
        {
            var o = await T_Customer_BLL.CheckUserName(userName);
            return Ok(new
            {
                statusCode = 200,
                result = o
            });
        }

        [Route("submit")]
        [HttpPost]
        public async Task<object> Submit(T_JSON model)
        {
            T_Customer_Role role = new T_Customer_Role();
            object effects = 0;
            if (model.Input0 != null)
            {
                string s = string.Empty;
                s = POSTJson.ResolveTJSON(model);
                role = JsonConvert.DeserializeObject<T_Customer_Role>(s);
                effects = await T_Customer_BLL.SaveCustomerRole(role);
            }
            return Ok(new
            {
                statusCode = 200,
                result = effects
            });
        }

        [Route("remove")]
        [HttpPost]
        public async Task<object> Register(long cid)
        {
            int effects = await T_Customer_BLL.RemoveCustomerRole(cid);
            return Ok(new
            {
                statusCode = 200,
                result = effects
            });
        }
    }
}
