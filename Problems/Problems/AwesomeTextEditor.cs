using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
  public class AwesomeTextEditor
    {
        public string GetStringWithLineBreaks( string input,int column)
        {
            if (String.IsNullOrEmpty(input)) return string.Empty ;

            if (column <= 0 || column>input.Length)
                throw new ArgumentException(nameof(column));

            string[] words = input.Split(' ');   
            string finalString = string.Empty;
            string line = string.Empty;

            foreach (var word in words)
            {
                if (line.Length + word.Length < column)
                {
                    line += string.IsNullOrEmpty(line) ? word : " " + word;
                }
                else
                {

                    finalString = finalString + line + "\n";
                    line = word;
                }
            }

            finalString += line;
            return finalString;
        }

    }
}
