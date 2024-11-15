using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using DataAccess.Infrastructure;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void DB_Log(IDbConnection conn, string source, string type, string query_input, string param_input)
        {
            var query = "INSERT INTO [DB_Log] ([source],[type],[query],[param]) VALUES(@source, @type, @query, @param)";
            var param = new DynamicParameters();
            param.Add("@source", source);
            param.Add("@type", type);
            param.Add("@query", query_input);
            param.Add("@param", param_input);

            SqlMapper.Query(conn, query, param, commandType: CommandType.Text);
        }
    }
}
