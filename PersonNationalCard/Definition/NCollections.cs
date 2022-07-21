using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.Definition
{
    public static class NCollections
    {
        private static AllCollection all;

        public static StatusCollection Status
        {
            get
            {
                return all.Status;
            }
        }

        public static OfficeCollection Offices
        {
            get
            {
                return all.Offices;
            }
        }

        #region Methods

        public static void CreateInstance()
        {
            all = new AllCollection();
            all.FetchData();
        }

        public static void RecreateInstance()
        {
            all = new AllCollection();
            all.FetchData();
        }


        #endregion
    }
}
