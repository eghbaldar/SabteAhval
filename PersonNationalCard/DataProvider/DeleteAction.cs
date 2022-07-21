using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace PNationalCard.DataProvider
{
    internal sealed partial class DAL //: AXA.DataProvider.Base
    {
        internal bool DeletePerson(Int64 NationalID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Person_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NationalID", SqlDbType.BigInt)).Value = NationalID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteStatus(short StatusID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Status_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.TinyInt)).Value = StatusID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteOffice(Int16 OfficeID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Office_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = OfficeID;
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
