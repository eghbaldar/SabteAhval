using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class User : HNP.Base.Interface.IDataBaseAction
    {
        private Int16 _UserID;
        public Int16 UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }

        private PNationalCard.Definition.Office _Office;
        public PNationalCard.Definition.Office Office
        {
            get
            {
                return this._Office;
            }
            set
            {
                this._Office = value;
            }
        }

        private string _UserName;
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }


        private string _Password;
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        private string _RegisterDate;
        public string RegisterDate
        {
            get
            {
                return this._RegisterDate;
            }
            set
            {
                this._RegisterDate = value;
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }


        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteUser(this.UserID))
            {
                SecurityCollections.User.Remove(this.UserID);
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
            if (dal.InsertUser(this))
            {
                SecurityCollections.User.Add(this);
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
            if (dal.UpdateUser(this))
            {
                SecurityCollections.User[this.UserID] = this;
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
    public sealed class UserCollection : HNP.Base.CollectionBaseClass<Int16, User>
    {
        public override void Add(User obj)
        {
            if (!this.dic.ContainsKey(obj.UserID))
            {
                this.dic.Add(obj.UserID, obj);
                this._refresh = true;
            }
        }
    }
}
