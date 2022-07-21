using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class UserGroup : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _UserGroupID;
        public Int16 UserGroupID
        {
            get
            {
                return this._UserGroupID;
            }
            set
            {
                this._UserGroupID = value;
            }
        }

        private HNP.Security.Difinition.User _User;
        public HNP.Security.Difinition.User User
        {
            get
            {
                if (this._User == null)
                    this._User = new User();
                return this._User;
            }
            set
            {
                this._User = value;
            }
        }

        private HNP.Security.Difinition.Group _Group;
        public HNP.Security.Difinition.Group Group
        {
            get
            {
                if (this._Group == null)
                    this._Group = new Group();
                return this._Group;
            }
            set
            {
                this._Group = value;
            }
        }


        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteUserGroup(this.UserGroupID))
            {
                SecurityCollections.UserGroup.Remove(this.UserGroupID);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.InsertUserGroup(this))
            {
                SecurityCollections.UserGroup.Add(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.UpdateUserGroup(this))
            {
                SecurityCollections.UserGroup[this.UserGroupID] = this;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }

    [Serializable()]
    public sealed class UserGroupCollection : HNP.Base.CollectionBaseClass<Int16, UserGroup>
    {
        public override void Add(UserGroup obj)
        {
            if (!this.dic.ContainsKey(obj.UserGroupID))
            {
                this.dic.Add(obj.UserGroupID, obj);
                this._refresh = true;
            }
        }

        public UserGroup GetByUserID(int UserID)
        {
            foreach (UserGroup obj in this.GetAll)
            {
                if (obj.User.UserID == UserID)
                {
                    return obj;
                }
            }
            return null;
        }

    }
}
