using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    public static class SecurityCollections
    {
        private static AllCollection all = new AllCollection();

        public static HNP.Security.Difinition.ActionCollection Action
        {
            get
            {
                return all.Action;
            }
        }

        public static HNP.Security.Difinition.ActivityCollection Activity
        {
            get
            {
                return all.Activity;
            }
        }

        public static HNP.Security.Difinition.ActivityGroupCollection ActivityGroup
        {
            get
            {
                return all.ActivityGroup;
            }
        }

        public static HNP.Security.Difinition.ActivityTypeCollection ActivityType
        {
            get
            {
                return all.ActivityType;
            }
        }

        public static HNP.Security.Difinition.ActivityTypeActionCollection ActivityTypeAction
        {
            get
            {
                return all.ActivityTypeAction;
            }
        }

        public static HNP.Security.Difinition.GroupCollection Group
        {
            get
            {
                return all.Group;
            }
        }

        public static HNP.Security.Difinition.UserCollection User
        {
            get
            {
                return all.User;
            }
        }

        public static HNP.Security.Difinition.UserGroupCollection UserGroup
        {
            get
            {
                return all.UserGroup;
            }
        }

        public static HNP.Security.Difinition.UserOfficeCollection UserOffice
        {
            get
            {
                return all.UserOffice;
            }
        }

        #region Methods

        public static void CreateInstance()
        {
            lock (all)
            {
                all = new AllCollection();
                all.FetchData();
            }            
        }

        public static void RecreateInstance()
        {
            all = new AllCollection();
            all.FetchData();
        }

        //public static bool ExportStop(string CashCode)
        //{
        //    double? paramValue = CashCollections.Parameter[CashCode, Insurance.Cash.Enum.ParameterName.ExportStop].ParameterValue;
        //    if (paramValue == null)
        //        return true;
        //    Insurance.Cash.Entity.Cash_PolicyStatusCollection obj = new Insurance.Cash.Entity.Cash_PolicyStatusCollection();
        //    obj.Load(CashCode, false);
        //    if (obj.Count > paramValue)
        //        return true;
        //    else
        //        return false;
        //}

        #endregion
    }
}
