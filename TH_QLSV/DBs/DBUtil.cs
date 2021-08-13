using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH_QLSV.DBs
{
    class DBUtil
    {
        static DbProviderFactory factory; 
        static DbConnection connection;
        static string connectionString;
        static string providerName;
        private static string configuration;

        static DBUtil()
        {

        }

        public static void Load(string name)
        {
            providerName = ConfigurationManager.ConnectionStrings[name].ProviderName;
            factory = DbProviderFactories.GetFactory(providerName);
            connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
        }
        
        static void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        static void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static DataTable GetTable(string tbName)
        {
            if (factory == null)
            {
                return null;
            }
            var tb = new DataTable(tbName);
            //OpenConnection();
            var adapter = factory.CreateDataAdapter();
            var selectCommand = factory.CreateCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = string.Format($"SELECT * FROM {tbName}");
            adapter.SelectCommand = selectCommand;
            adapter.Fill(tb);

            //CloseConnection();
            return tb;
        }

        public static int SaveTable(DataTable tb)
        {
            if (factory == null)
            {
                return -1;
            }
            var adapter = factory.CreateDataAdapter();
            var selectCommand = factory.CreateCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = string.Format($"SELECT * FROM {tb.TableName}");
            adapter.SelectCommand = selectCommand;
            var commandBuilder = factory.CreateCommandBuilder();
            commandBuilder.DataAdapter = adapter;
            return adapter.Update(tb);
           
        }
    }
}
