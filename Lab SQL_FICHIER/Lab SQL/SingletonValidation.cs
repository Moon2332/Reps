using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Lab_SQL
{
    internal class SingletonValidation
    {
        static SingletonValidation instance;
        public SingletonValidation() { }

        public static SingletonValidation getInstance()
        {
            if (instance == null)
                instance = new SingletonValidation();

            return instance;
        }

        public bool isStringValide(string m)
        {
            if (!string.IsNullOrEmpty(m.Trim()))
                return true;
            else
                return false;
        }

        public bool isCodeValide(string code)
        {
            int iCode = 0;
            if (int.TryParse(code, out iCode) == true)
                return false;
            else
                return true;
        }

        public bool isCodeLengthValide(int code)
        {
            if (code < 100)
                return false;
            else
                return true;
        }

        public bool isPrixValide(string prix)
        {
            double p = 0;
            if (double.TryParse(prix, out p))
                 return false;
            else
                return true;
        }
    }
}
