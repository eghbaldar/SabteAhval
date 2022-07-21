using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.DataProvider
{
    public class DataTools
    {
//        private string _connectionString = "Data Source=;Initial Catalog=Devins;Persist Security Info=True;User ID=POWER;Password='13839'";
        private string _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["CnnMain"].ConnectionString;

        private Dictionary<string, string> _parser;
        private Dictionary<string, string> Parser
        {
            get
            {
                if (this._parser == null)
                {
                    this._parser = new Dictionary<string, string>();
                    this.ConnectionStringParser();
                }
                return this._parser;
            }
        }

        protected string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
            set
            {
                this._connectionString = value;
            }
        }

        private SqlConnection _connection;
        protected SqlConnection GetConnection
        {
            get
            {
                this._connection = new SqlConnection(this.ConnectionString);
                if (this._connection.State == System.Data.ConnectionState.Closed || this._connection.State == System.Data.ConnectionState.Broken)
                    this._connection.Open();
                return this._connection;
            }
        }
        
        private void ConnectionStringParser()
        {
            _parser.Clear();
            string[] pairs = this._connectionString.Split(";".ToCharArray());
            foreach (string str in pairs)
            {
                if (str.IndexOf("=") > 0)
                    _parser.Add(str.Substring(0, str.IndexOf("=")).ToLower().Trim(), str.Substring(str.IndexOf("=") + 1, str.Length - str.Substring(0, str.IndexOf("=")).Length - 1).Trim());
            }
        }

        protected bool RollbackTransaction(SqlCommand command)
        {
            command.Transaction.Rollback();
            command.Connection.Close();
            command.Dispose();
            return false;
        }

        protected bool RollbackTransaction(SqlTransaction transaction)
        {
            transaction.Rollback();
            transaction.Connection.Dispose();
            return false;
        }
    }
}
