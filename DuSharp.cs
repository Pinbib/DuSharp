﻿using System;
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;
using DuLine;

namespace DuSharp
{
    class DuSharp
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
        static void Main(string[] arg)
        {
            /*
            .
            .
            Getting the path to the executable file or folder.
            .
            .
            */
            string src = "NoN";

            if (arg.Length <= 0)
            {
                bool ensr = true;

                while (ensr)
                {
                    Write("SRC: ");
                    string subsrc = ReadLine() ?? "src";

                    if (Regex.IsMatch(subsrc, @"."))
                    {
                        ensr = false;
                        src = subsrc;
                    }
                    else
                    {
                        subsrc = ReadLine() ?? "src";
                    }

                }

            }
            else
            {
                src = arg[0];
            }

            /*
            .
            .
            Path handling and the interpreter itself.
            .
            .
            */

            if (Path.Exists(src))
            {
                if (!Path.Exists("./variable"))
                {
                    Directory.CreateDirectory("./variable");
                }
                if (Path.GetExtension(src) != "")
                {
                    if (Path.GetExtension(src) == ".du")
                    {
                        string file = File.ReadAllText(src);

                        string[] lines = file.Split(";");

                        for (var i = 0; i < lines.Length; i++)
                        {
                            string[] line = lines[i].Trim().Split(" ");

                            switch (line[0])
                            {
                                case " ":
                                    break;
                                case "":
                                    break;
                                case "approve":
                                    new _approve(line, i + 1, src);
                                    break;
                                case "printl":
                                    new _printl(line, i + 1, src);
                                    break;
                                default:
                                    ELog("Error: " + "Work: " + src + ": Line: " + (i + 1) + ": Unknown command \"" + line[0] + "\".");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ELog("Error: " + "SRC: " + "The executable file \"" + src + "\" must have the extension .du");
                    }
                }
                else
                {
                    /*
                    .
                    .
                    Door.json
                    .
                    .
                    */
                }
                if (Path.Exists("./variable"))
                {
                    Directory.Delete("./variable", true);
                }
            }
            else
            {
                ELog("Error: " + "SRC: " + "Path \"" + src + "\" does not exist.");
            }
        }
    }
}