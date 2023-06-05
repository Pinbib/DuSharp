using System;
using static System.Console;
using DuCom;
namespace DuLine
{

    class _delete
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
        public _delete(string[] line, int li, string src)
        {
            if (line.Length >= 3)
            {
                if (line[1] == "var")
                {
                    Approve.del(line[2]);
                }
                else if (line[1] == "dec")
                {
                    Declare.del(line[2]);
                }
            }
        }
    }
}