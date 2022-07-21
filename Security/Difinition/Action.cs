using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Difinition
{
    [Serializable()]
    public sealed class Action : HNP.Base.Interface.IDataBaseAction
    {
        private short _ActionID;
        public short ActionID
        {
            get
            {
                return this._ActionID;
            }
            set
            {
                this._ActionID = value;
            }
        }

        private string _ActionName;
        public string ActionName
        {
            get
            {
                return this._ActionName;
            }
            set
            {
                this._ActionName = value;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            HNP.Security.DataProvider.DAL dal = new HNP.Security.DataProvider.DAL();
            if (dal.DeleteAction(this.ActionID))
            {
                SecurityCollections.Action.Remove(this.ActionID);
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
            if (dal.InsertAction(this))
            {
                SecurityCollections.Action.Add(this);
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
            if (dal.UpdateAction(this))
            {
                SecurityCollections.Action[this.ActionID] = this;
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
    public sealed class ActionCollection : HNP.Base.CollectionBaseClass<short, Action>
    {
        public override void Add(Action obj)
        {
            if (!this.dic.ContainsKey(obj.ActionID))
            {
                this.dic.Add(obj.ActionID, obj);
                this._refresh = true;
            }
        }
    }
}
