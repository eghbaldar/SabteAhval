using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PNationalCard.Definition;
using PNationalCard.Entity;
using System.Text;

namespace PNationalCard.DataProvider
{
    internal sealed partial class DAL //: AXA.DataProvider.Base
    {
        internal bool InsertPerson(Person obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NationalID", SqlDbType.BigInt)).Value = obj.NationalID;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.Office.OfficeID;
                command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt)).Value = obj.Status.StatusID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool InsertStatus(Status obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Status_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt)).Direction = ParameterDirection.Output;
                command.Parameters.Add(new SqlParameter("@StatusDesc", SqlDbType.NVarChar)).Value = obj.StatusDesc;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.StatusID = short.Parse(command.Parameters["@StatusID"].Value.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal bool InsertOffice(Office obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Office_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.OfficeID;
                command.Parameters.Add(new SqlParameter("@OfficeName", SqlDbType.NVarChar)).Value = obj.OfficeName;
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar)).Value = obj.Address;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.OfficeID = short.Parse(command.Parameters["@OfficeID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool ChangePerson(String path, Status status, Office office, out string errMessage)
        {
            PersonCollection objPersons = new PersonCollection();
            try
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
                connectionString = connectionString + path + ";Persist Security Info=False";
                string strSelect = "";

                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Table.xml");

                DataRow drTable = ds.Tables[0].Rows[0];
                strSelect = "Select " + drTable["field"].ToString() + " FROM " + drTable["name"].ToString();
                String fieldName = drTable["field"].ToString();
                ds.Dispose();

                System.Data.OleDb.OleDbConnection objConnection = new System.Data.OleDb.OleDbConnection(connectionString);
                objConnection.Open();
                System.Data.OleDb.OleDbCommand oleCommand = new System.Data.OleDb.OleDbCommand();

                oleCommand.CommandText = strSelect;
                oleCommand.CommandType = CommandType.Text;
                oleCommand.Connection = objConnection;
                System.Data.OleDb.OleDbDataReader dr = oleCommand.ExecuteReader();

                while (dr.Read())
                {
                    Person obj = new Person();
                    obj.NationalID = long.Parse(dr[fieldName].ToString());
                    obj.Office = office;
                    obj.Status = status;

                    objPersons.Add(obj);
                }
                oleCommand.Dispose();
                objConnection.Close();
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                try
                {
                    command.CommandText = "Person_SP_Change";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NationalID", SqlDbType.BigInt));
                    command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt));
                    command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt));
                    StringBuilder strNotTransfer = new StringBuilder();
                    foreach (Person obj in objPersons.GetAll)
                    {
                        command.Parameters["@NationalID"].Value = obj.NationalID;
                        command.Parameters["@OfficeID"].Value = obj.Office.OfficeID;
                        command.Parameters["@StatusID"].Value = obj.Status.StatusID;

                        if (command.ExecuteNonQuery() < 0)
                        {
                            strNotTransfer.Append(obj.NationalID.ToString());
                        }
                    }
                    command.Connection.Close();
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    command.Connection.Close();
                    command.Dispose();
                    errMessage = ex.Message;
                    return false;
                }
            }
            errMessage = String.Empty;
            return true;
        }
    }
}
