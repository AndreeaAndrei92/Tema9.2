using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly SqlConnection Connection;

        protected BaseRepository(SqlConnection connection)
        {
            this.Connection = connection;
        }
    }
}
