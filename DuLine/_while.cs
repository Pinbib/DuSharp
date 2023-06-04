using System;
using System.Data;
using System.Text.RegularExpressions;
using DuCom;
using static System.Console;
using System.IO;

namespace DuLine
{
    class _while
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
        public _while(string[] line, int li, string src)
        {
            int codeI = Array.IndexOf(line, "{");
            if (codeI != -1)
            {
                string cond = string.Join(" ", line.Skip(1).ToArray().Take(codeI - 1));
                while (If.Cond(Transform.var(cond)))
                {
                    int codeX = Array.IndexOf(line, "}");
                    if (codeX != -1)
                    {
                        ArraySegment<string> segment = new ArraySegment<string>(line, codeI + 1, codeX - codeI - 1);

                        string[] newArray = segment.ToArray();

                        string file = string.Join(" ", newArray);
                        file = Regex.Replace(file, @"\r?\n", ";\n");
                        DuSharp.DuSharp a = new DuSharp.DuSharp();
                        a.Dum(file, src);
                    }
                    else
                    {
                        ELog("Error: " + "Work: " + src + ": Line: " + li + ": The \"while\" block is not closed.");
                    }
                }
            }
            else
            {
                ELog("Error: " + "Work: " + src + ": Line: " + li + ": The \"while\" block is not open.");
            }
        }
    }
}