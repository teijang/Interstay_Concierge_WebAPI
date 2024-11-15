using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUserByLoginInfo(string login_id, string login_pwd);
    }
}
