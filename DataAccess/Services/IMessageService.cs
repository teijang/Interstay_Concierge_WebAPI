using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public interface IMessageService 
    {
        Task<IEnumerable<Message>> GetMessageList(string hotel_guid, int messageType_id, int timezone_offsetInMins);

        Task<IEnumerable<Message>> GetMessage(string hotel_guid, int message_id, int timezone_offsetInMins);
    }
}
