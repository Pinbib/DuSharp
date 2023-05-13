using System;
using System.Data;
using System.Text.Json;
using System.Linq;
using static System.Console;
using System.Text.RegularExpressions;
using DuCom;
namespace DuLine
{

    class _approve
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
        public _approve(string[] line, int li, string src)
        {
            if (line.Length > 1)
            {
                string name = line[1];

                if (line.Length > 2)
                {
                    if (line.Length > 3)
                    {
                        if (line[2] == "=")
                        {
                            if (line.Length > 4)
                            {
                                string type = line[3];

                                switch (type)
                                {
                                    case "Int":
                                        if (true)
                                        {
                                            DataTable table = new DataTable();
                                            object resultObject = table.Compute(Transform.var(string.Join(" ", line.Skip(4).ToArray())), null);
                                            string? result = resultObject != null ? resultObject.ToString() : null;
                                            Approve.set(name, type, result!);
                                        }
                                        break;
                                    case "String":
                                        Approve.set(name, type, Transform.var(string.Join(" ", line.Skip(4).ToArray())));
                                        break;
                                    case "Boolean":
                                        if (true)
                                        {
                                            bool? val = false;
                                            if (line[4] == "true")
                                            {
                                                val = true;
                                            }
                                            else if (line[4] == "false")
                                            {
                                                val = false;
                                            }
                                            else
                                            {
                                                ELog("Error: " + "Work: " + src + ": From: _approve" + ": Line: " + li + ": A boolean variable must be true or false.");
                                            }
                                            Approve.set(name, type, val);
                                        }
                                        break;
                                    case "Array":
                                        if (Regex.IsMatch(string.Join(" ", line.Skip(4).ToArray()), @"^\[|\]$"))
                                        {
                                            object[] val = JsonSerializer.Deserialize<object[]>(string.Join(" ", line.Skip(4).ToArray())!) ?? Array.Empty<object>();
                                            Approve.set(name, type, string.Join("-=-,-Q-S-A-C-=-,-", val));
                                        }
                                        else
                                        {
                                            ELog("Error: " + "Work: " + src + ": Line: " + li + ": When creating an array, there must be [] characters at the end and beginning.");
                                        }
                                        break;
                                    case "ViewCondtion":
                                        Approve.set(name, type, Convert.ToBoolean(new DataTable().Compute(Regex.Replace(Transform.var(string.Join(" ", line.Skip(4).ToArray())), @"==", "=").ToString(), null)));
                                        break;
                                    default:
                                        ELog("Error: " + "Work: " + src + ": Line: " + li + ": Unknown data type \"" + type + "\".");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            ELog("Error: " + "Work: " + src + ": Line: " + li + ": If the value of the variable is determined, then after the name there should be a sign \"=\".");
                        }
                    }
                }
                else
                {
                    Approve.set(line[1], "undefined", "void");
                }
            }
            else
            {
                ELog("Error: " + "Work: " + src + ": Line: " + li + ": The variable must have a name.");
            }
        }
    }
}