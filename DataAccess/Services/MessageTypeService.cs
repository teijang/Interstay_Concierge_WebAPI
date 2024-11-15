using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class MessageTypeService : IMessageTypeService
    {
        IUnitOfWorkMessageType _unitOfWork;
        public MessageTypeService(IUnitOfWorkMessageType unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MessageType>> GetAllAvailableMessageTypes(string hotel_guid, string user_guid) {            
            return await _unitOfWork.MessageTypeRepository.GetAllAvailableMessageTypes(hotel_guid, user_guid);
        }
    }
}
