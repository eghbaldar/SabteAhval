using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HNP.Security.Difinition;

namespace HNP.Security.DataProvider
{
    internal sealed partial class DAL : HNP.DataProvider.Base
    {
        internal void GetAllCollection(HNP.Security.Difinition.AllCollection all)
        {
            using (SqlCommand command = this.GetConnection.CreateCommand())
            {
                command.CommandText = "SecurityGetAll";
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = command.ExecuteReader();
                all.Action.Clear();
                while (dr.Read())
                {
                    Action obj = new Action();
                    obj.ActionID = short.Parse(dr["ActionID"].ToString());
                    obj.ActionName = dr["ActionName"].ToString();
                    all.Action.Add(obj);
                }

                dr.NextResult();

                all.ActivityType.Clear();
                while (dr.Read())
                {
                    ActivityType obj = new ActivityType();
                    obj.ActivityTypeID = short.Parse(dr["ActivityTypeID"].ToString());
                    obj.ActivityTypeName = dr["ActivityTypeName"].ToString();
                    all.ActivityType.Add(obj);
                }

                dr.NextResult();

                all.Activity.Clear();
                while (dr.Read())
                {
                    Activity obj = new Activity();
                    obj.ActivityID = short.Parse(dr["ActivityID"].ToString());
                    obj.ActivityName = dr["ActivityName"].ToString();
                    obj.ActivityDesc = dr["ActivityDesc"].ToString();
                    obj.ActivityType = all.ActivityType[short.Parse(dr["ActivityTypeID"].ToString())];
                    all.Activity.Add(obj);
                }

                dr.NextResult();

                all.ActivityTypeAction.Clear();
                while (dr.Read())
                {
                    ActivityTypeAction obj = new ActivityTypeAction();
                    obj.Action = all.Action[short.Parse(dr["ActionID"].ToString())];
                    obj.ActivityType = all.ActivityType[short.Parse(dr["ActivityTypeID"].ToString())];
                    obj.ATAID = short.Parse(dr["ATAID"].ToString());
                    all.ActivityTypeAction.Add(obj);
                }

                dr.NextResult();

                all.Group.Clear();
                while (dr.Read())
                {
                    Group obj = new Group();
                    obj.GroupID = short.Parse(dr["GroupID"].ToString());
                    obj.GroupName = dr["GroupName"].ToString();
                    all.Group.Add(obj);
                }

                dr.NextResult();

                all.ActivityGroup.Clear();
                while (dr.Read())
                {
                    ActivityGroup obj = new ActivityGroup();
                    obj.Activity = all.Activity[short.Parse(dr["ActivityID"].ToString())];
                    obj.ActivityGroupID = short.Parse(dr["ActivityGroupID"].ToString());
                    obj.ATA = all.ActivityTypeAction[short.Parse(dr["ATAID"].ToString())];
                    obj.Group = all.Group[short.Parse(dr["GroupID"].ToString())];
                    all.ActivityGroup.Add(obj);
                }

                dr.NextResult();

                all.User.Clear();
                while (dr.Read())
                {
                    User obj = new User();
                    obj.UserID = Int16.Parse(dr["UserID"].ToString());
                    obj.Office = PNationalCard.Definition.NCollections.Offices[Int16.Parse(dr["OfficeID"].ToString())];
                    obj.UserName = dr["UserName"].ToString();
                    obj.FirstName = dr["FirstName"].ToString();
                    obj.LastName = dr["LastName"].ToString();
                    obj.Password = dr["Password"].ToString();
                    //obj.RegisterDate = dr["RegisterDate"].ToString();

                    all.User.Add(obj);
                }

                dr.NextResult();

                all.UserGroup.Clear();
                while (dr.Read())
                {
                    UserGroup obj = new UserGroup();
                    obj.Group = all.Group[short.Parse(dr["GroupID"].ToString())];
                    obj.User = all.User[short.Parse(dr["UserID"].ToString())];
                    obj.UserGroupID = short.Parse(dr["UserGroupID"].ToString());
                    all.UserGroup.Add(obj);
                }

                dr.NextResult();

                all.UserGroup.Clear();
                while (dr.Read())
                {
                    UserGroup obj = new UserGroup();
                    obj.Group = all.Group[short.Parse(dr["GroupID"].ToString())];
                    obj.User = all.User[short.Parse(dr["UserID"].ToString())];
                    obj.UserGroupID = short.Parse(dr["UserGroupID"].ToString());
                    all.UserGroup.Add(obj);
                }

                dr.Close();
                command.Connection.Dispose();
                command.Dispose();
            }
        }
    }
}
