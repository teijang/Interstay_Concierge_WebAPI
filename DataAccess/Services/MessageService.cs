using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class MessageService : IMessageService
    {
        IUnitOfWorkMessage _unitOfWork;
        public MessageService(IUnitOfWorkMessage unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Message>> GetMessageList(string hotel_guid, int messageType_id, int timezone_offsetInMins) {            
            return await _unitOfWork.MessageRepository.GetMessageList(hotel_guid, messageType_id, timezone_offsetInMins);
        }

        public async Task<IEnumerable<Message>> GetMessage(string hotel_guid, int message_id, int timezone_offsetInMins)
        {
            return await _unitOfWork.MessageRepository.GetMessage(hotel_guid, message_id, timezone_offsetInMins);
        }
    }
}
