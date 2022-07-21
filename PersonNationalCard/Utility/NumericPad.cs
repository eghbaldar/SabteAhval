using System;
using System.Collections.Generic;
using System.Text;

namespace PNationalCard.Utility
{
    public class NumericPad
    {
        private int _Num0;
        public int Num0
        {
            get { return _Num0; }
            set { _Num0 = value; }
        }

        private int _Num1;

        public int Num1
        {
            get { return _Num1; }
            set { _Num1 = value; }
        }

        private int _Num2;

        public int Num2
        {
            get { return _Num2; }
            set { _Num2 = value; }
        }

        private int _Num3;

        public int Num3
        {
            get { return _Num3; }
            set { _Num3 = value; }
        }

        private int _Num4;

        public int Num4
        {
            get { return _Num4; }
            set { _Num4 = value; }
        }

        private int _Num5;

        public int Num5
        {
            get { return _Num5; }
            set { _Num5 = value; }
        }

        private int _Num6;

        public int Num6
        {
            get { return _Num6; }
            set { _Num6 = value; }
        }

        private int _Num7;

        public int Num7
        {
            get { return _Num7; }
            set { _Num7 = value; }
        }

        private int _Num8;

        public int Num8
        {
            get { return _Num8; }
            set { _Num8 = value; }
        }

        private int _Num9;

        public int Num9
        {
            get { return _Num9; }
            set { _Num9 = value; }
        }

        public void CreateNumber()
        {
            Random obj = new Random();
            List<int> lst = new List<int>();
            int num = 0;
            int index = 0;
            while (lst.Count < 10)
            {
                num = obj.Next(0, 10);
                if (!lst.Contains(num))
                {
                    this.GetType().GetProperty("Num" + index).SetValue(this, num, null);
                    lst.Add(num);
                    index++;
                }
            }
        }

    }
}
