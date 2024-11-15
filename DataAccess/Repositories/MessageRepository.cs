using Dapper;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        IConnectionFactory _connectionFactory;
        public MessageRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Message>> GetMessageList(string hotel_guid, int messageType_id, int timezone_offsetInMins)
        {
            var query = "usp_Api_Message_GeMessageList";
            var param = new DynamicParameters();
            param.Add("@hotel_guid", hotel_guid);
            param.Add("@messageType_id", messageType_id);
            param.Add("@timezone_offsetInMins", timezone_offsetInMins);

            var list = await SqlMapper.QueryAsync<Message>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return list;
            
        }

        public async Task<IEnumerable<Message>> GetMessage(string hotel_guid, int message_id, int timezone_offsetInMins)
        {
            var query = "usp_Api_Message_GeMessage";
            var param = new DynamicParameters();
            param.Add("@hotel_guid", hotel_guid);
            param.Add("@message_id", message_id);
            param.Add("@timezone_offsetInMins", timezone_offsetInMins);

            var list = await SqlMapper.QueryAsync<Message>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return list;

        }
    }
}
