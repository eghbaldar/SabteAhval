using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using HNP.Security.Difinition;
using HNP.Security.Entity;

namespace HNP.Security.DataProvider
{
    internal sealed partial class DAL : HNP.DataProvider.Base
    {
        internal bool UpdateAction(Action obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Action_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.TinyInt)).Value = obj.ActionID;
                command.Parameters.Add(new SqlParameter("@ActionName", SqlDbType.NVarChar)).Value = obj.ActionName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateActivity(Activity obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Activity_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityID", SqlDbType.SmallInt)).Value = obj.ActivityID;
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = obj.ActivityType.ActivityTypeID;
                command.Parameters.Add(new SqlParameter("@ActivityName", SqlDbType.NVarChar)).Value = obj.ActivityName;
                command.Parameters.Add(new SqlParameter("@ActivityDesc", SqlDbType.NVarChar)).Value = obj.ActivityDesc;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateActivityGroup(ActivityGroup obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityGroup_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityGroupID", SqlDbType.SmallInt)).Value = obj.ActivityGroupID;
                command.Parameters.Add(new SqlParameter("@ActivityID", SqlDbType.SmallInt)).Value = obj.Activity.ActivityID;
                command.Parameters.Add(new SqlParameter("@ATAID", SqlDbType.SmallInt)).Value = obj.ATA.ATAID;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = obj.Group.GroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateActivityType(ActivityType obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityType_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = obj.ActivityTypeID;
                command.Parameters.Add(new SqlParameter("@ActivityTypeName", SqlDbType.NVarChar)).Value = obj.ActivityTypeName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateActivityTypeAction(ActivityTypeAction obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityTypeAction_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ATAID", SqlDbType.SmallInt)).Value = obj.ATAID;
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = obj.ActivityType.ActivityTypeID;
                command.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.TinyInt)).Value = obj.Action.ActionID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateGroup(Group obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Group_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = obj.GroupID;
                command.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.NVarChar)).Value = obj.GroupName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateHierarchalAccount(HierarchalAccount obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "HierarchalAccount_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@HAccountID", SqlDbType.SmallInt)).Value = obj.HAccountID;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.SmallInt)).Value = obj.Parent.UserID;
                command.Parameters.Add(new SqlParameter("@IsParent", SqlDbType.Bit)).Value = obj.IsParent;
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit)).Value = obj.Status;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateUser(User obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "User_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.UserID;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.Office.OfficeID;
                command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar)).Value = obj.UserName;
                command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar)).Value = obj.FirstName;
                command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar)).Value = obj.LastName;
                command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar)).Value = obj.Password;
                //command.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.NVarChar)).Value = obj.RegisterDate;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateUserGroup(UserGroup obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserGroup_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserGroupID", SqlDbType.SmallInt)).Value = obj.UserGroupID;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = obj.Group.GroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        internal bool UpdateUserOffice(UserOffice obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserOffice_SP_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserOfficeID", SqlDbType.SmallInt)).Value = obj.UserOfficeID;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.Office.OfficeID;
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
