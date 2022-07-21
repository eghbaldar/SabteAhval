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
        internal bool InsertAction(Action obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Action_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.TinyInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@ActionName", SqlDbType.NVarChar)).Value = obj.ActionName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.ActionID = short.Parse(command.Parameters["@ActionID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertActivity(Activity obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Activity_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = obj.ActivityType.ActivityTypeID;
                command.Parameters.Add(new SqlParameter("@ActivityName", SqlDbType.NVarChar)).Value = obj.ActivityName;
                command.Parameters.Add(new SqlParameter("@ActivityDesc", SqlDbType.NVarChar)).Value = obj.ActivityDesc;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.ActivityID = short.Parse(command.Parameters["@ActivityID"].Value.ToString()); 
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertActivityGroup(ActivityGroup obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityGroup_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityGroupID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output;  
                command.Parameters.Add(new SqlParameter("@ActivityID", SqlDbType.SmallInt)).Value = obj.Activity.ActivityID;
                command.Parameters.Add(new SqlParameter("@ATAID", SqlDbType.SmallInt)).Value = obj.ATA.ATAID;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = obj.Group.GroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.ActivityGroupID = short.Parse(command.Parameters["@ActivityGroupID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertActivityType(ActivityType obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityType_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@ActivityTypeName", SqlDbType.NVarChar)).Value = obj.ActivityTypeName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.ActivityTypeID = short.Parse(command.Parameters["@ActivityTypeID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertActivityTypeAction(ActivityTypeAction obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "ActivityTypeAction_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ATAID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@ActivityTypeID", SqlDbType.TinyInt)).Value = obj.ActivityType.ActivityTypeID;
                command.Parameters.Add(new SqlParameter("@ActionID", SqlDbType.TinyInt)).Value = obj.Action.ActionID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.ATAID = short.Parse(command.Parameters["@ATAID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertGroup(Group obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "Group_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.NVarChar)).Value = obj.GroupName;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.GroupID = short.Parse(command.Parameters["@GroupID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertHierarchalAccount(HierarchalAccount obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "HierarchalAccount_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@HAccountID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@ParentID", SqlDbType.SmallInt)).Value = obj.Parent.UserID;
                command.Parameters.Add(new SqlParameter("@IsParent", SqlDbType.Bit)).Value = obj.IsParent;
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit)).Value = obj.Status;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.HAccountID = short.Parse(command.Parameters["@HAccountID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertUser(User obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "User_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output;
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
                {
                    obj.UserID = short.Parse(command.Parameters["@UserID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertUserGroup(UserGroup obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserGroup_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserGroupID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output; 
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.TinyInt)).Value = obj.Group.GroupID;
                int i = command.ExecuteNonQuery();
                command.Connection.Close();
                command.Dispose();
                if (i > 0)
                {
                    obj.UserGroupID = short.Parse(command.Parameters["@UserGroupID"].Value.ToString());
                    return true;
                }
                else
                    return false;
            }
        }

        internal bool InsertUserOffice(UserOffice obj)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "UserOffice_SP_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserOfficeID", SqlDbType.SmallInt)).Direction = ParameterDirection.Output;
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.SmallInt)).Value = obj.User.UserID;
                command.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.SmallInt)).Value = obj.Office.OfficeID;
                int i = command.ExecuteNonQuery();
                
                if (i > 0)
                {
                    obj.UserOfficeID = short.Parse(command.Parameters["@UserOfficeID"].Value.ToString());
                    command.Connection.Close();
                    command.Dispose();
                    return true;
                }
                else
                {
                    command.Connection.Close();
                    command.Dispose();
                    return false;
                }
            }
        }

    }
}
