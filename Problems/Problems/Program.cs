using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    
    class Program
    {
        static void Main(string[] args) 
        {
            int partLength = 15;
            string sentence = "Silver badges are awarded for longer term goals. Silver badges are uncommon.";
            sentence = "The quick brown fox jumped over the lazy dog.";
            string[] words = sentence.Split(' ');
            var parts = new Dictionary<int, string>();
            string partsFinal = "";
            string part = string.Empty;
            
            foreach (var word in words) 
            {
                if (part.Length + word.Length < partLength)
                {
                    part += string.IsNullOrEmpty(part) ? word : " " + word;
                }
                else
                {

                    partsFinal = partsFinal + part + "\n";
                    part = word;
                }
            }
            
            partsFinal += part;
            Console.WriteLine(partsFinal);
            //foreach (var item in parts)
            //{
            //    Console.WriteLine("{1}",  item.Value.Length);
            //}
            Console.ReadLine();
        }
    }
}
