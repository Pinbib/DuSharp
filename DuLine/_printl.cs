using System;
using System.Data;
using System.Text.Json;
using static System.Console;
using System.Text.RegularExpressions;
using DuCom;
namespace DuLine
{

    class _printl
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
        public _printl(string[] line, int li, string src)
        {
            WriteLine(Transform.var(string.Join(" ", line.Skip(1).ToArray())));
        }
    }
}