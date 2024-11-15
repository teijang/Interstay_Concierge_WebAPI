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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<User>> GetUserByLoginInfo(string login_id, string login_pwd)
        {
            var query = "usp_Api_User_GetUserByLoginInfo";
            var param = new DynamicParameters();
            param.Add("@user_loginId", login_id);
            param.Add("@user_loginPwd", login_pwd);
            
            //DB_Log(_connectionFactory.GetConnection, this.ToString(), "", query, param.ToString());

            var list = await SqlMapper.QueryAsync<User>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
                        
            return list;
        }
    }
}
