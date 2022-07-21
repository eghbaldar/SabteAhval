using System;
using System.Collections.Generic;
using System.Text;
using PNationalCard.Definition;

namespace PNationalCard.Entity
{
    [Serializable()]
    public sealed class Person : HNP.Base.Interface.IDataBaseAction
    {
        private Int64 _NationalID;
        public Int64 NationalID
        {
            get
            {
                return this._NationalID;
            }
            set
            {
                this._NationalID = value;
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

        private Status _Status;
        public Status Status
        {
            get
            {
                if (this._Status == null)
                    this._Status = new Status();
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        private String _ErrMessage = String.Empty;
        public String ErrMessage
        {
            get
            {
                return _ErrMessage;
            }
        }

        public bool NationalIDValidate()
        {
            if (this.NationalID == 0)
                return false;

            string NID = this.NationalID.ToString();
            int len = 10 - NID.Length;
            for (int i = 1; i <= len; i++)
                NID = "0" + NID;

            string NIDPart1 = "", NIDPart2 = "", NIDPart3 = "";
            this.NationalIDStep(NID, ref NIDPart1, ref NIDPart2, ref NIDPart3);

            if (NIDPart1 == "000")
                return false;

            if (NIDPart2 == "000000")
                return false;

            //if (NIDPart3 == "0")
            //    return false;

            switch (NID)
            {
                //case "1111111111":
                case "2222222222":
                case "3333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                case "9999999999":
                    return false;
            }

            int total = 0;
            for (int i = 1; i < 10; i++)
                total += i * int.Parse(NID.Substring(i - 1, 1));

            double reminder = total % 11;
            if (reminder.ToString().Substring(0, 1) == NIDPart3)
                return true;
            else
                return false;
        }

        public bool NationalIDValidate(Double NationalID)
        {
            if (NationalID == 0)
                return false;

            string NID = NationalID.ToString();
            int len = 10 - NID.Length;
            for (int i = 1; i <= len; i++)
                NID = "0" + NID;

            string NIDPart1 = "", NIDPart2 = "", NIDPart3 = "";
            this.NationalIDStep(NID, ref NIDPart1, ref NIDPart2, ref NIDPart3);

            if (NIDPart1 == "000")
                return false;

            if (NIDPart2 == "000000")
                return false;

            //if (NIDPart3 == "0")
            //    return false;
            switch (NID)
            {
                //case "1111111111":
                case "2222222222":
                case "3333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                case "9999999999":
                    return false;
            }

            int total = 0;
            for (int i = 1; i < 10; i++)
                total += i * int.Parse(NID.Substring(i - 1, 1));

            double reminder = total % 11;
            if (reminder.ToString().Substring(0, 1) == NIDPart3)
                return true;
            else
                return false;
        }

        public void NationalIDStep(string NID, ref string NationalIDStep1, ref string NationalIDStep2, ref string NationalIDStep3)
        {
            String strZero = "";
            if (NID.Length < 10 && NID.Length > 7)
            {
                for (int i = 10; i > NID.Length; i--)
                    strZero += "0";
                NID = strZero + NID;
            }
            NationalIDStep1 = NID.Substring(0, 3);
            NationalIDStep2 = NID.Substring(3, 6);
            NationalIDStep3 = NID.Substring(9, 1);
        }

        public bool Load()
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            return dal.SelectPerson(this);
        }

        public bool Convert(String pathFile)
        {
            PNationalCard.DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            string errMessage = String.Empty;
            if (!dal.ChangePerson(pathFile, this.Status, this.Office, out errMessage))
            {
                this._ErrMessage = errMessage;
                return false;
            }
            else
            {
                return true;
            }
        }

        #region IDataBaseAction Members

        public bool Delete()
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            return dal.DeletePerson(this.NationalID);
        }

        public bool Insert()
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            return dal.InsertPerson(this);
        }

        public bool Update()
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            return dal.UpdatePerson(this);
        }

        #endregion
    }

    [Serializable()]
    public sealed class PersonCollection : HNP.Base.CollectionBaseClass<Int64, Person>
    {
        public override void Add(Person obj)
        {
            if (!this.dic.ContainsKey(obj.NationalID))
            {
                this.dic.Add(obj.NationalID, obj);
                this._refresh = true;
            }
        }

        public void Load()
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            dal.SelectPerson(this);
        }

        public void LoadByStatus(short StatusID)
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            dal.SelectPersonWithStatus(this, StatusID);
        }

        public void LoadByOffice(short OfficeID)
        {
            DataProvider.DAL dal = new PNationalCard.DataProvider.DAL();
            dal.SelectPersonWithOffice(this, OfficeID);
        }
    }
}
