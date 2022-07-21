using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.Definition
{
    [Serializable()]
    public sealed class Status : HNP.Base.Interface.IDataBaseAction
    {
        private short _StatusID;
        public short StatusID
        {
            get
            {
                return this._StatusID;
            }
            set
            {
                this._StatusID = value;
            }
        }

        private string _StatusDesc;
        public string StatusDesc
        {
            get
            {
                return this._StatusDesc;
            }
            set
            {
                this._StatusDesc = value;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            if (dal.DeleteStatus(this.StatusID))
            {
                NCollections.Status.Remove(this.StatusID);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            if (dal.InsertStatus(this))
            {
                NCollections.Status.Add(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            if (dal.UpdateStatus(this))
            {
                NCollections.Status[this.StatusID] = this;
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
    public sealed class StatusCollection : HNP.Base.CollectionBaseClass<short, Status>
    {
        public override void Add(Status obj)
        {
            if (!this.dic.ContainsKey(obj.StatusID))
            {
                this.dic.Add(obj.StatusID, obj);
                this._refresh = true;
            }
        }

    }
}
