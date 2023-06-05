using System;
using static System.Console;
using System.IO;
using DuSharp;

namespace DuCom
{
    class Declare
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

        public static void set(string name, string code)
        {
            if (!File.Exists(Path.Combine("./declare", name + ".dec")))
            {
                File.WriteAllText(Path.Combine("./declare", name + ".dec"), code);
            }
            else
            {
                ILog("Info: " + "Command: " + "Declare: " + "The \"" + name + "\" function is already there.");
            }
        }
        public static string get(string name)
        {
            string file = "NoN";

            if (File.Exists(Path.Combine("./declare", name + ".dec")))
            {
                file = File.ReadAllText(Path.Combine("./declare", name + ".dec"));
            }
            else
            {
                ILog("Info: " + "Command: " + "Declare: " + "It does not have the functions of \"" + name + "\".");
            }
            return file;
        }
        public static void call(string name, string src)
        {
            string file = "NoN";

            if (File.Exists(Path.Combine("./declare", name + ".dec")))
            {
                file = File.ReadAllText(Path.Combine("./declare", name + ".dec"));
                DuSharp.DuSharp a = new DuSharp.DuSharp();
                string dirname = Path.GetDirectoryName(src) ?? "NoN";
                if (dirname != "NoN")
                {
                    a.Dum(file, Path.Combine(dirname, "declare", name + ".dec"));
                }
            }
            else
            {
                ILog("Info: " + "Command: " + "Declare: " + "It does not have the functions of \"" + name + "\".");
            }
        }
        public static void del(string name)
        {
            if (File.Exists(Path.Combine("./declare", name + ".dec")))
            {
                File.Delete(Path.Combine("./declare", name + ".dec"));
            }
            else
            {
                ILog("Info: " + "Command: " + "Declare: " + "Function \"" + name + "\" does not exist.");
            }
        }
    }
}