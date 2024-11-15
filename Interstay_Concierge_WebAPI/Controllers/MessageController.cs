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
    public class MessageController : ApiController
    {
        IMessageService _messageService;

        public MessageController()
        {

        }

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("hotel_guid") && headers.Contains("messageType_id"))
            {
                string hotel_guid = headers.GetValues("hotel_guid").First();
                int messageType_id = int.Parse(headers.GetValues("messageType_id").First());
                int timezone_offsetInMins = headers.Contains("timezone_offsetInMins") ? int.Parse(headers.GetValues("timezone_offsetInMins").First().ToString()) : 0;

                var resultData = await _messageService.GetMessageList(hotel_guid, messageType_id, timezone_offsetInMins);
                if (resultData == null)
                {
                    return NotFound();
                }

                return Ok(resultData);
            }

            return NotFound();
            
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {   
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("hotel_guid"))
            {
                string hotel_guid = headers.GetValues("hotel_guid").First();
                int timezone_offsetInMins = headers.Contains("timezone_offsetInMins") ? int.Parse(headers.GetValues("timezone_offsetInMins").First().ToString()) : 0; 
                
                var resultData = await _messageService.GetMessage(hotel_guid, id, timezone_offsetInMins);
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
