using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Services;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Interstay_Concierge_WebAPI.Controllers
{
    public class MessageTypeController : ApiController
    {
        IMessageTypeService _messageTypeService;

        public MessageTypeController()
        {

        }

        public MessageTypeController(IMessageTypeService messageTypeService)
        {
            _messageTypeService = messageTypeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("hotel_guid") && headers.Contains("user_guid"))
            {
                string hotel_guid = headers.GetValues("hotel_guid").First();
                string user_guid = headers.GetValues("user_guid").First();
                
                var resultData = await _messageTypeService.GetAllAvailableMessageTypes(hotel_guid, user_guid);
                if (resultData == null)
                {
                    return NotFound();
                }

                return Ok(resultData);
            }

            return NotFound();
        }
    }
}
