using System.Text.RegularExpressions;

namespace Infrastructure.Utils
{
    public static class FormatAI
    {
        public static string FormatName(string name)
        {
            name = name.Replace("O e-mail do candidato é:", "").Trim();

            return name;
        }

        public static string FormatEmail(string email)
        {
            string padrao = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            Regex regex = new Regex(padrao);
            MatchCollection matches = regex.Matches(email);

            if (matches.Count > 0 )
            {
                return matches[0].Value;
            }  else {
                return string.Empty;
            }
        }

        public static string FormatCpf(string cpf)
        {
            string padrao = @"\d{3}\.\d{3}\.\d{3}-\d{2}";

            Regex regex = new Regex(padrao);
            MatchCollection matches = regex.Matches(cpf);

            if (matches.Count > 0)
            {
                return matches[0].Value;
            }
            else
            {
                return string.Empty;
            }
        }
        public static DateTime FormatDate(string date)
        {
            string padrao = @"\d{2}/\d{2}/\d{4}|\d{4}-\d{2}-\d{2}|\d{2}\sde\s[A-Za-z]+\sde\s\d{4}";

            Regex regex = new Regex(padrao);
            MatchCollection matches = regex.Matches(date);

            if (matches.Count > 0)
            {
                return DateTime.Parse(matches[0].Value);
            }
            else
            {
                return DateTime.MinValue;
            }
        }



    }
}
