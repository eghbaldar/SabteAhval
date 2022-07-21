using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.Definition
{
    internal sealed class AllCollection
    {
        private StatusCollection _Status = new StatusCollection();
        internal StatusCollection Status
        {
            get
            {
                return this._Status;
            }
        }

        private OfficeCollection _Offices = new OfficeCollection();
        internal OfficeCollection Offices
        {
            get
            {
                return this._Offices;
            }
        }


        internal void FetchData()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            dal.GetAllDefinition(this);
        }
    }
}
