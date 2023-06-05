using System;
using System.Data;
using System.Text.RegularExpressions;
using DuCom;
using static System.Console;
using System.IO;

namespace DuLine
{
    class _declare
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
        public _declare(string[] line, int li, string src)
        {
            if (line.Length > 3)
            {
                string name = line[1];

                int codeI = Array.IndexOf(line, "{");
                if (codeI != -1)
                {
                    int codeX = Array.IndexOf(line, "}");
                    if (codeX != -1)
                    {
                        ArraySegment<string> segment = new ArraySegment<string>(line, codeI + 1, codeX - codeI - 1);

                        string[] newArray = segment.ToArray();

                        string file = string.Join(" ", newArray);
                        file = Regex.Replace(file, @"\r?\n", ";\n");
                        Declare.set(name, file);
                    }
                    else
                    {
                        ELog("Error: " + "Work: " + src + ": Line: " + li + ": The \"declare\" block is not closed.");
                    }
                }
                else
                {
                    ELog("Error: " + "Work: " + src + ": Line: " + li + ": The \"declare\" block is not open.");
                }
            }
        }
    }
}