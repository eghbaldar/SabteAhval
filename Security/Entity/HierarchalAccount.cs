using System;
using System.Collections.Generic;
using System.Text;

namespace HNP.Security.Entity
{
    [Serializable()]
    public sealed class HierarchalAccount
    {
        private Int16 _HAccountID;
        public Int16 HAccountID
        {
            get
            {
                return this._HAccountID;
            }
            set
            {
                this._HAccountID = value;
            }
        }

        private HNP.Security.Difinition.User _User;
        public HNP.Security.Difinition.User User
        {
            get
            {
                return this._User;
            }
            set
            {
                this._User = value;
            }
        }

        private HNP.Security.Difinition.User _Parent;
        public HNP.Security.Difinition.User Parent
        {
            get
            {
                return this._Parent;
            }
            set
            {
                this._Parent = value;
            }
        }

        private bool _IsParent;
        public bool IsParent
        {
            get
            {
                return this._IsParent;
            }
            set
            {
                this._IsParent = value;
            }
        }

        private bool _Status;
        public bool Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
    }

    [Serializable()]
    public sealed class HierarchalAccountCollection
    {
        Dictionary<Int16, HierarchalAccount> dic = new Dictionary<Int16, HierarchalAccount>();
        List<HierarchalAccount> _allItems = null;
        private bool _refresh = false;

        public void Add(HierarchalAccount obj)
        {
            if (!this.dic.ContainsKey(obj.HAccountID))
            {
                this.dic.Add(obj.HAccountID, obj);
                this._refresh = true;
            }
        }

        public HierarchalAccount this[Int16 HAccountID]
        {
            get
            {
                return this.dic[HAccountID];
            }
        }

        public List<HierarchalAccount> GetAll
        {
            get
            {
                if (this._allItems == null || this._refresh == true)
                {
                    this._allItems = new List<HierarchalAccount>(this.dic.Values);
                    this._refresh = false;
                }
                return this._allItems;
            }
        }

        public bool Remove(Int16 HAccountID)
        {
            if (this.dic.ContainsKey(HAccountID))
            {
                this.dic.Remove(HAccountID);
                this._refresh = true;
                return true;
            }
            return false;
        }

        public bool Remove(HierarchalAccount obj)
        {
            if (this.dic.ContainsKey(obj.HAccountID))
            {
                this.dic.Remove(obj.HAccountID);
                this._refresh = true;
                return true;
            }
            return false;
        }

        public int Count
        {
            get
            {
                return this.dic.Count;
            }
        }

        public bool Contain(Int16 HAccountID)
        {
            return this.dic.ContainsKey(HAccountID);
        }

        public bool Contain(HierarchalAccount obj)
        {
            return this.dic.ContainsKey(obj.HAccountID);
        }

        public void Clear()
        {
            this.dic.Clear();
            this._refresh = true;
        }

    }
}
