using System;
using System.Data;
using static System.Console;
using System.IO;

namespace DuCom
{
    class If
    {
        static void ELog(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Error.WriteLine(msg);
            Console.ResetColor();
        }
        static void ILog(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine(msg);
            Console.ResetColor();
        }

        public static bool Cond(string line)
        {
            bool result = false;

            DataTable dataTable = new DataTable();

            result = Convert.ToBoolean(dataTable.Compute(line, ""));

            return result;
        }
    }
}