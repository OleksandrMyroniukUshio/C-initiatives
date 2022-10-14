using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Practice_core
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = isTextValid();
                Console.WriteLine($"Your input has {input.Length} symbols!");

            }
            catch (CustomExSize ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CustomExAlph ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        static string isTextValid()
        {
            Console.WriteLine("(Shouldn't contain >2000 symbols, in english alphabet)" +
                               "\nEnter the text: ");
            
            string input = Console.ReadLine();
            if(System.IO.File.Exists(input)) input = File.ReadAllText(input);

            if (input.Length > 2000) throw new CustomExSize("Wrong input - text has more than 2000 symbols!");
            
            var regexItem = new Regex("^[a-zA-Z0-9 !\"#$%&'()*+,./:;<=>?@\\^_`{|}~-]*$");
            if (!regexItem.IsMatch(input)) throw new CustomExAlph("Wrong input - text has non-english alphabet or invalid symbol!");
            
            return input;
        }
        public class CustomExSize : Exception
        {
            public CustomExSize(string msg) : base(msg)
            {

            }
        }
        public class CustomExAlph : Exception
        {
            public CustomExAlph(string msg) : base(msg)
            {

            }
        }

    }
}