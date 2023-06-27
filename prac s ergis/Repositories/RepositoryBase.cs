using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace prac_s_ergis.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionStrring;
        public RepositoryBase()
        {
            _connectionStrring = "Server=localhost; Database=PracLogin ;Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionStrring);
        }


    }
}
