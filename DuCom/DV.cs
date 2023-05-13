using System;

namespace DuCom
{
    class DV
    {
        private string _type = "undefined";
        private object _data = "void";

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public object Data
        {
            set { _data = value; }
            get
            {
                return _data;
            }
        }

        public DV(string type, object data)
        {
            Type = type;
            Data = data;
        }
        public DV() { }

        public override string ToString()
        {
            return "" + Data + "";
        }
    }
}