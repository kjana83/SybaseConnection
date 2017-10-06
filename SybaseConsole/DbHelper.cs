using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sybase.Data.AseClient;
using System.Data;
using System.Configuration;

namespace SybaseConsole
{
    public class DbHelper
    {
        private AseConnection _dbConn;
        public DbHelper() { }
        private string GetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings["sybase-connectionstring"] != null)
                return ConfigurationManager.ConnectionStrings["sybase-connectionstring"].ConnectionString;
            else
                return "";
        }
        private void OpenConnection()
        {
            if (_dbConn != null)
            {
                if (_dbConn.State == ConnectionState.Closed)
                {
                    _dbConn.Open();
                }
            }
        }
        public IDataReader ExecuteReader(string query)
        {
            _dbConn = new AseConnection(GetConnectionString());
            AseCommand dbCommand = new AseCommand(query, _dbConn);
            dbCommand.CommandType = CommandType.Text;
            OpenConnection();
            return dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
