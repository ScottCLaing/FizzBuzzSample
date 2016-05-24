using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        public string GetFizzBuzz(Dictionary<int, string> userNewCases = null)
        {
            bool noNewCases = (userNewCases == null);
            var fizzBuzz = new StringBuilder();
            for (int i = 1; i <= 100; i++)
            {
                var showNumber = true;
                if (noNewCases)
                {
                    fizzBuzz.AppendLine(i.ToString());
                    continue;
                }
                foreach (var key in userNewCases.Keys)
                {
                    if (i % key == 0)
                    {
                        fizzBuzz.Append(" " + userNewCases[key]);
                        showNumber = false;
                    }
                }
                if (showNumber)
                {
                    fizzBuzz.AppendLine(i.ToString());
                }
                else
                {
                    fizzBuzz.AppendLine();
                }
            }
            return fizzBuzz.ToString();
        }
    }
}
