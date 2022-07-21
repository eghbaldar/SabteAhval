using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    internal sealed class AllCollection
    {
        private HNP.Security.Difinition.ActionCollection _Action = new ActionCollection();
        internal HNP.Security.Difinition.ActionCollection Action
        {
            get
            {
                return this._Action;
            }
        }

        private HNP.Security.Difinition.ActivityCollection _Activity = new ActivityCollection();
        internal HNP.Security.Difinition.ActivityCollection Activity
        {
            get
            {
                return this._Activity;
            }
        }

        private HNP.Security.Difinition.ActivityGroupCollection _ActivityGroup = new ActivityGroupCollection();
        internal HNP.Security.Difinition.ActivityGroupCollection ActivityGroup
        {
            get
            {
                return this._ActivityGroup;
            }
        }

        private HNP.Security.Difinition.ActivityTypeCollection _ActivityType = new ActivityTypeCollection();
        internal HNP.Security.Difinition.ActivityTypeCollection ActivityType
        {
            get
            {
                return this._ActivityType;
            }
        }

        private HNP.Security.Difinition.ActivityTypeActionCollection _ActivityTypeAction = new ActivityTypeActionCollection();
        internal HNP.Security.Difinition.ActivityTypeActionCollection ActivityTypeAction
        {
            get
            {
                return this._ActivityTypeAction;
            }
        }

        private HNP.Security.Difinition.GroupCollection _Group = new GroupCollection();
        internal HNP.Security.Difinition.GroupCollection Group
        {
            get
            {
                return this._Group;
            }
        }

        private HNP.Security.Difinition.UserCollection _User = new UserCollection();
        internal HNP.Security.Difinition.UserCollection User
        {
            get
            {
                return this._User;
            }
        }

        private HNP.Security.Difinition.UserGroupCollection _UserGroup = new UserGroupCollection();
        internal HNP.Security.Difinition.UserGroupCollection UserGroup
        {
            get
            {
                return this._UserGroup;
            }
        }

        private HNP.Security.Difinition.UserOfficeCollection _UserOffice = new UserOfficeCollection();
        internal HNP.Security.Difinition.UserOfficeCollection UserOffice
        {
            get
            {
                return this._UserOffice;
            }
        }

        internal void FetchData()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            dal.GetAllCollection(this);
        }

    }
}
