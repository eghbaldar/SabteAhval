using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class Group : HNP.Base.Interface.IDataBaseAction
    {
        private short _GroupID;
        public short GroupID
        {
            get
            {
                return this._GroupID;
            }
            set
            {
                this._GroupID = value;
            }
        }

        private string _GroupName;
        public string GroupName
        {
            get
            {
                return this._GroupName;
            }
            set
            {
                this._GroupName = value;
            }
        }


        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteGroup(this.GroupID))
            {
                SecurityCollections.Group.Remove(this.GroupID);
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
            if (dal.InsertGroup(this))
            {
                SecurityCollections.Group.Add(this);
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
            if (dal.UpdateGroup(this))
            {
                SecurityCollections.Group[this.GroupID] = this;
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
    public sealed class GroupCollection : HNP.Base.CollectionBaseClass<short, Group>
    {
        public override void Add(Group obj)
        {
            if (!this.dic.ContainsKey(obj.GroupID))
            {
                this.dic.Add(obj.GroupID, obj);
                this._refresh = true;
            }
        }
    }
}
