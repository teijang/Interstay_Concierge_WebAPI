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
    public class MessageTypeRepository : GenericRepository<MessageType>, IMessageTypeRepository
    {
        IConnectionFactory _connectionFactory;
        public MessageTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<MessageType>> GetAllAvailableMessageTypes(string hotel_guid, string user_guid)
        {
            var query = "usp_Api_MessageType_GeAllAvailableMessageTypes";
            var param = new DynamicParameters();
            param.Add("@hotel_guid", hotel_guid);
            param.Add("@user_guid", user_guid);
            
            try
            {
                //DB_Log(_connectionFactory.GetConnection, this.ToString(), "", query, param.ToString());

                var list = await SqlMapper.QueryAsync<MessageType>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
                return list;
            }
            catch(Exception err)
            {
                
            }
            return null;
        }
    }
}
