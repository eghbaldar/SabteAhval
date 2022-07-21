using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.Definition
{
    [Serializable()]
    public sealed class Office:HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _OfficeID;
        public Int16 OfficeID
        {
            get
            {
                return this._OfficeID;
            }
            set
            {
                this._OfficeID = value;
            }
        }

        private string _OfficeName;
        public string OfficeName
        {
            get
            {
                return this._OfficeName;
            }
            set
            {
                this._OfficeName = value;
            }
        }

        private string _Address;
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            if (dal.DeleteOffice(this.OfficeID))
            {
                NCollections.Offices.Remove(this.OfficeID);
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
            if (dal.InsertOffice(this))
            {
                NCollections.Offices.Add(this);
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
            if (dal.UpdateOffice(this))
            {
                NCollections.Offices[this.OfficeID] = this;
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
    public sealed class OfficeCollection : HNP.Base.CollectionBaseClass<Int16, Office>
    {
        public override void Add(Office obj)
        {
            if (!this.dic.ContainsKey(obj.OfficeID))
            {
                this.dic.Add(obj.OfficeID, obj);
                this._refresh = true;
            }
        }

    }
}
