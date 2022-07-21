using System;
using System.Collections.Generic;
using System.Text;
using PNationalCard.Definition;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class UserOffice : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _UserOfficeID;
        public Int16 UserOfficeID
        {
            get
            {
                return this._UserOfficeID;
            }
            set
            {
                this._UserOfficeID = value;
            }
        }

        private User _User;
        public User User
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

        private Office _Office;
        public Office Office
        {
            get
            {
                if (this._Office == null)
                    this._Office = new Office();
                return this._Office;
            }
            set
            {
                this._Office = value;
            }
        }

        #region IDataBaseAction Members

        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteUserOffice(this.UserOfficeID))
            {
                SecurityCollections.UserOffice.Remove(this.UserOfficeID);
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
            if (dal.InsertUserOffice(this))
            {
                SecurityCollections.UserOffice.Add(this);
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
            if (dal.UpdateUserOffice(this))
            {
                SecurityCollections.UserOffice[this.UserOfficeID] = this;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #endregion
    }

    [Serializable()]
    public sealed class UserOfficeCollection : HNP.Base.CollectionBaseClass<Int16, UserOffice>
    {
        public override void Add(UserOffice obj)
        {
            if (!this.dic.ContainsKey(obj.UserOfficeID))
            {
                this.dic.Add(obj.UserOfficeID, obj);
                this._refresh = true;
            }
        }
    }
}
