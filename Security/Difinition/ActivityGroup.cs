using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class ActivityGroup : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _ActivityGroupID;
        public Int16 ActivityGroupID
        {
            get
            {
                return this._ActivityGroupID;
            }
            set
            {
                this._ActivityGroupID = value;
            }
        }

        private HNP.Security.Difinition.Activity _Activity;
        public HNP.Security.Difinition.Activity Activity
        {
            get
            {
                if (this._Activity == null)
                    this._Activity = new Activity();
                return this._Activity;
            }
            set
            {
                this._Activity = value;
            }
        }

        private HNP.Security.Difinition.ActivityTypeAction _ATA;
        public HNP.Security.Difinition.ActivityTypeAction ATA
        {
            get
            {
                if (this._ATA == null)
                    this._ATA = new ActivityTypeAction();
                return this._ATA;
            }
            set
            {
                this._ATA = value;
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
            if (dal.DeleteActivityGroup(this.ActivityGroupID))
            {
                SecurityCollections.ActivityGroup.Remove(this.ActivityGroupID);
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
            if (dal.InsertActivityGroup(this))
            {
                SecurityCollections.ActivityGroup.Add(this);
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
            if (dal.UpdateActivityGroup(this))
            {
                SecurityCollections.ActivityGroup[this.ActivityGroupID] = this;
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
    public sealed class ActivityGroupCollection : HNP.Base.CollectionBaseClass<Int16, ActivityGroup>
    {
        public override void Add(ActivityGroup obj)
        {
            if (!this.dic.ContainsKey(obj.ActivityGroupID))
            {
                this.dic.Add(obj.ActivityGroupID, obj);
                this._refresh = true;
            }
        }

        public List<ActivityGroup> GetByGroupID(int GroupID)
        {
            List<ActivityGroup> objCollection = new List<ActivityGroup>();
            foreach (ActivityGroup obj in this.GetAll)
            {
                if (obj.Group.GroupID == GroupID)
                {
                    objCollection.Add(obj);
                    
                }
            }
            return objCollection;
        }

    }
}
