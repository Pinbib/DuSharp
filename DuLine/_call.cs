using System;
using static System.Console;
using System.Text.RegularExpressions;
using DuCom;
namespace DuLine
{

    class _call
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
        public _call(string[] line, int li, string src)
        {
            if (line.Length >= 3)
            {
                string callType = line[1];

                if (callType == "variable")
                {
                    DV var = Approve.get(line[2]);
                    switch (var.Type)
                    {
                        case "Int":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            WriteLine(var.Data);
                            Console.ResetColor();
                            break;
                        case "String":
                            WriteLine(var.Data);
                            break;
                        case "Boolean":

                            if (var.Data.ToString() == "True")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                WriteLine(var.Data);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                WriteLine(var.Data);
                                Console.ResetColor();
                            }
                            break;
                        case "ViewCondtion":
                            if (var.Data.ToString() == "True")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                WriteLine(var.Data);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                WriteLine(var.Data);
                                Console.ResetColor();
                            }
                            break;
                        case "Array":
                            if (line.Length >= 4)
                            {
                                string a = var.Data.ToString() ?? "NoN";
                                string[] b = a.Split("-=-,-Q-S-A-C-=-,-");
                                int index = Convert.ToInt32(line[3]);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                WriteLine(b[index]);
                                Console.ResetColor();
                            }
                            else
                            {
                                string a = var.Data.ToString() ?? "NoN";
                                string da = "[ " + string.Join(", ", a.Split("-=-,-Q-S-A-C-=-,-")) + " ]";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                WriteLine(da);
                                Console.ResetColor();
                            }
                            break;
                        default:
                            WriteLine(var.Data);
                            break;
                    }
                }
                else if (callType == "function")
                {

                }
                else
                {
                    ELog("Error: " + "Work: " + src + ": Line: " + li + ": Unknown call type \"" + callType + "\".");
                }
            }
            else
            {
                ELog("Error: " + "Work: " + src + ": Line: " + li + ": The \"call\" command was not filled.");
            }
        }
    }
}