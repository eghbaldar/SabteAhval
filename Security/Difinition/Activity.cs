using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class Activity : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _ActivityID;
        public Int16 ActivityID
        {
            get
            {
                return this._ActivityID;
            }
            set
            {
                this._ActivityID = value;
            }
        }

        private HNP.Security.Difinition.ActivityType _ActivityType;
        public HNP.Security.Difinition.ActivityType ActivityType
        {
            get
            {
                if (this._ActivityType == null)
                    this._ActivityType = new ActivityType();
                return this._ActivityType;
            }
            set
            {
                this._ActivityType = value;
            }
        }

        private string _ActivityName;
        public string ActivityName
        {
            get
            {
                return this._ActivityName;
            }
            set
            {
                this._ActivityName = value;
            }
        }

        private string _ActivityDesc;
        public string ActivityDesc
        {
            get
            {
                return this._ActivityDesc;
            }
            set
            {
                this._ActivityDesc = value;
            }
        }


        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteActivity(this.ActivityID))
            {
                SecurityCollections.Activity.Remove(this.ActivityID);
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
            if (dal.InsertActivity(this))
            {
                SecurityCollections.Activity.Add(this);
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
            if (dal.UpdateActivity(this))
            {
                SecurityCollections.Activity[this.ActivityID] = this;
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
    public sealed class ActivityCollection : HNP.Base.CollectionBaseClass<Int16, Activity>
    {
        public override void Add(Activity obj)
        {
            if (!this.dic.ContainsKey(obj.ActivityID))
            {
                this.dic.Add(obj.ActivityID, obj);
                this._refresh = true;
            }
        }
    }
}
