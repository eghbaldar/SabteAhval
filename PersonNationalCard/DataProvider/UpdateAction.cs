using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PNationalCard.Definition;
using PNationalCard.Entity;

namespace PNationalCard.DataProvider
{
    internal sealed partial class DAL //: AXA.DataProvider.Base
    {
        internal bool UpdatePerson(Person obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_Update";
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

        internal bool UpdateStatus(Status obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Status_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt)).Value = obj.StatusID;
                command.Parameters.Add(new SqlParameter("@StatusDesc", SqlDbType.NVarChar)).Value = obj.StatusDesc;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateOffice(Office obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Office_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.OfficeID;
                command.Parameters.Add(new SqlParameter("@OfficeName", SqlDbType.NVarChar)).Value = obj.OfficeName;
                command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar)).Value = obj.Address;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }


    }
}
