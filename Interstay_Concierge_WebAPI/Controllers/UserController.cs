using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Services;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Interstay_Concierge_WebAPI.Tools;

namespace Interstay_Concierge_WebAPI.Controllers
{
    public class UserController : ApiController
    {
        IUserService _userService;

        public UserController()
        {

        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        /*
        {
              "login_id" : "123",
              "login_pwd" : "456"
        }
        */
        public async Task<IHttpActionResult> GetUserByLoginInfo(JObject data)
        {
            if (data == null || data["login_id"] == null || data["login_pwd"] == null)
            {                
                return NotFound();
            }
            
            string login_pwd_decrypted = Cryptography.EncryptingPassword(data["login_pwd"].ToString());

            var resultData = await _userService.GetUserByLoginInfo(data["login_id"].ToString(), login_pwd_decrypted);
            if (resultData == null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }
                
    }
}
