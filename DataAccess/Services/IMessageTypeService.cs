using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public interface IMessageTypeService 
    {
        Task<IEnumerable<MessageType>> GetAllAvailableMessageTypes(string hotel_guid, string user_guid);
                
    }
}
