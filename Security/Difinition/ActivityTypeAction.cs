using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class ActivityTypeAction : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _ATAID;
        public Int16 ATAID
        {
            get
            {
                return this._ATAID;
            }
            set
            {
                this._ATAID = value;
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

        private HNP.Security.Difinition.Action _Action;
        public HNP.Security.Difinition.Action Action
        {
            get
            {
                if (this._Action == null)
                    this._Action = new Action();
                return this._Action;
            }
            set
            {
                this._Action = value;
            }
        }

        public String ATADesc
        {
            get
            {
                return this.ActivityType.ActivityTypeName + " / " + this.Action.ActionName;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteActivityTypeAction(this.ATAID))
            {
                SecurityCollections.ActivityTypeAction.Remove(this.ATAID);
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
            if (dal.InsertActivityTypeAction(this))
            {
                SecurityCollections.ActivityTypeAction.Add(this);
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
            if (dal.UpdateActivityTypeAction(this))
            {
                SecurityCollections.ActivityTypeAction[this.ATAID] = this;
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
    public sealed class ActivityTypeActionCollection : HNP.Base.CollectionBaseClass<Int16, ActivityTypeAction>
    {
        public override void Add(ActivityTypeAction obj)
        {
            if (!this.dic.ContainsKey(obj.ATAID))
            {
                this.dic.Add(obj.ATAID, obj);
                this._refresh = true;
            }
        }

    }
}
