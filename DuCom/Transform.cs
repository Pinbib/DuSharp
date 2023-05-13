using System;
using System.Text.RegularExpressions;

namespace DuCom
{
    class Transform
    {
        public static string var(string text)
        {
            var regex = new Regex(@"\@[^\s]+");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var data = Approve.get(match.Value.Substring(1)).Data.ToString();
                if (Approve.get(match.Value.Substring(1)).Type == "Array")
                {
                    text = "[" + string.Join(",", text.Replace("@" + match.Value.Substring(1), data).Split("-=-,-Q-S-A-C-=-,-")) + "]";
                }
                text = text.Replace("@" + match.Value.Substring(1), data);
            }

            return text;
        }
    }
}