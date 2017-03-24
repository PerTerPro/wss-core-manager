using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.SqlDb
{
    public class Util 
    {
        public static SqlParameter GetCommand(string name, SqlDbType type, object value)
        {
            SqlParameter sqlCommand = new SqlParameter();
            sqlCommand.ParameterName = name;
            sqlCommand.Value = value;
            sqlCommand.SqlDbType = type;
            return sqlCommand;
        }
    }
}
