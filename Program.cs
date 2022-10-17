using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Its not a common way to call namespaces in C#
// Please see https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
namespace Practice_core
{
    class Program
    {
        // Change whole logic to get input until its valid
        // In case if program throws exception, it should try to read input again
        // Or make it show errors or numbers of symbols for infinite number of inputs
        static void Main(string[] args)
        {
            try
            {
                string input = isTextValid(); // rename it to Run and put logic there
                Console.WriteLine($"Your input has {input.Length} symbols!");

            }
            // put this catch to Run()
            // also you can use it this way
            // catch (Exception e)
            // {
            //    Console.WriteLine(e.ToString());
            // }
            // It will print both exception in a proper way + you can avoid code duplication
            catch (CustomExSize ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CustomExAlph ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        // Also invalid method name
        // Its not following naming convention
        // Also name is just invalid
        // From the name, I expect bool return parameter that shows me that some text is valid
        // But you return string

        // Its better to call this method just Run and put logic above inside
        // Or, even better, to follow S principle (single responsibility) from SOLID, you should break this method to different parts
        static string isTextValid()
        {
            Console.WriteLine("(Shouldn't contain >2000 symbols, in english alphabet)" +
                               "\nEnter the text: ");

            // You can put this two lines in method ReadText() that will return string
            string input = Console.ReadLine();
            if(System.IO.File.Exists(input)) input = File.ReadAllText(input);

            // Next three lines - to method Validate(string text)
            if (input.Length > 2000) throw new CustomExSize("Wrong input - text has more than 2000 symbols!");
            
            var regexItem = new Regex("^[a-zA-Z0-9 !\"#$%&'()*+,./:;<=>?@\\^_`{|}~-]*$");
            if (!regexItem.IsMatch(input)) throw new CustomExAlph("Wrong input - text has non-english alphabet or invalid symbol!");

            // Here you can just use Console.WriteLine($"Your input has {input.Length} symbols!");
            return input;
        }

        // Its better to move this classes to separated files, and folder like Exception/{CustomException}.cs


        // Its better to call it InvalidInputSizeException
        public class CustomExSize : Exception
        {
            public CustomExSize(string msg) : base(msg)
            {

            }
        }

        // Its better to call it InvalidInputCharactersException
        public class CustomExAlph : Exception
        {
            public CustomExAlph(string msg) : base(msg)
            {

            }
        }

    }
}