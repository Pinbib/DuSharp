using System;
using static System.Console;
using System.IO;

namespace DuCom
{
    class Approve
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
        public static void set(string name, string type, object value)
        {
            if (!File.Exists(Path.Join("./variable", name + ".var")))
            {
                File.WriteAllText(Path.Join("./variable", name + ".var"), type + " " + value.ToString());
            }
            else
            {
                string[] var = File.ReadAllText(Path.Join("./variable", name + ".var")).Split(" ");

                if (var[0] == type)
                {
                    File.WriteAllText(Path.Join("./variable", name + ".var"), type + " " + value.ToString());
                }
                else if (var[0] == "undefined")
                {
                    File.WriteAllText(Path.Join("./variable", name + ".var"), type + " " + value.ToString());
                }
                else
                {
                    ILog("Info: " + "Command: " + "Approve: " + "You cannot change the type of the variable \"" + name + "\" when it is already defined.");
                }
            }
        }
        public static DV get(string name)
        {
            DV var = new DV();
            if (File.Exists(Path.Join("./variable", name + ".var")))
            {
                string[] file = File.ReadAllText(Path.Join("./variable", name + ".var")).Split(" ");

                var.Type = file[0];
                var.Data = string.Join(" ", file.Skip(1).ToArray());
            }
            else
            {
                ILog("Info: " + "Command: " + "Approve: " + "Variable \"" + name + "\" does not exist.");
            }
            return var;
        }
    }
}