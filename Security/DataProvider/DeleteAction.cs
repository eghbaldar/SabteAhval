using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HNP.Security.DataProvider
{
    internal sealed partial class DAL : HNP.DataProvider.Base
    {
        internal bool DeleteAction(short ActionID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Action_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.TinyInt)).Value = ActionID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteActivity(Int16 ActivityID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Activity_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityID", SqlDbType.SmallInt)).Value = ActivityID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteActivityGroup(Int16 ActivityGroupID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityGroup_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityGroupID", SqlDbType.SmallInt)).Value = ActivityGroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteActivityType(short ActivityTypeID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityType_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = ActivityTypeID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteActivityTypeAction(Int16 ATAID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityTypeAction_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ATAID", SqlDbType.SmallInt)).Value = ATAID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteGroup(short GroupID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Group_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = GroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteHierarchalAccount(Int16 HAccountID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "HierarchalAccount_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@HAccountID", SqlDbType.SmallInt)).Value = HAccountID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteUser(Int16 UserID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "User_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = UserID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteUserGroup(Int16 UserGroupID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserGroup_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserGroupID", SqlDbType.SmallInt)).Value = UserGroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool DeleteUserOffice(Int16 UserOfficeID)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserOffice_SP_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserOfficeID", SqlDbType.SmallInt)).Value = UserOfficeID;
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
