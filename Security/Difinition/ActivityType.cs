using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class ActivityType : HNP.Base.Interface.IDataBaseAction
    {
        private short _ActivityTypeID;
        public short ActivityTypeID
        {
            get
            {
                return this._ActivityTypeID;
            }
            set
            {
                this._ActivityTypeID = value;
            }
        }

        private string _ActivityTypeName;
        public string ActivityTypeName
        {
            get
            {
                return this._ActivityTypeName;
            }
            set
            {
                this._ActivityTypeName = value;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteActivityType(this.ActivityTypeID))
            {
                SecurityCollections.ActivityType.Remove(this.ActivityTypeID);
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
            if (dal.InsertActivityType(this))
            {
                SecurityCollections.ActivityType.Add(this);
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
            if (dal.UpdateActivityType(this))
            {
                SecurityCollections.ActivityType[this.ActivityTypeID] = this;
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
    public sealed class ActivityTypeCollection : HNP.Base.CollectionBaseClass<short, ActivityType>
    {
        public override void Add(ActivityType obj)
        {
            if (!this.dic.ContainsKey(obj.ActivityTypeID))
            {
                this.dic.Add(obj.ActivityTypeID, obj);
                this._refresh = true;
            }
        }
    }
}
