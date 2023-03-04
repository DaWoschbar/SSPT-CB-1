using System.ComponentModel;

namespace Uebung8
{
    internal class Program
    {
        private const string exit = "exit";
        private const string quit = "quit";
        private const string list = "list";
        private const string delete = "delete";

        private static List<string> _passwordList = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello and welcome to your great Secure input password list");

                List<string> passwordList = new List<string>();


                while (true)
                {
                    PrintOptions();
                    Console.WriteLine("Enter anything besides the option to add a new password");
                    string input = Console.ReadLine() ?? "";
                    bool exit = CheckInput(input);

                    if (exit)
                        break;
                    PrintList();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.ToString());
            }
        }

        private static bool CheckInput(string input)
        {
            try
            {
                switch (input)
                {
                    case exit:
                        return true;

                    case quit:
                        return true;

                    case list:
                        PrintList();
                        return false;

                    case delete:
                        DeleteEntry();
                        return false;

                    default:
                        AddToList(input);
                        return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static void AddToList(string input)
        {
            try
            {
                if (_passwordList.Contains(input))
                {
                    Console.WriteLine("Password already in list.");
                    return;
                }
                _passwordList.Add(input);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static void DeleteEntry()
        {
            try
            {
                while (true)
                {
                    Console.Write("Enter index to delete item: ");
                    string? input = Console.ReadLine();
                    int index;

                    bool isNumber = int.TryParse(input, out index);

                    if (String.IsNullOrEmpty(input) || !isNumber)
                    {
                        Console.WriteLine("Not a number");
                        continue;
                    }

                    

                    if (index > _passwordList.Count || index < 0)
                    {
                        Console.WriteLine("Invalid Index. try again");
                        continue;
                    }

                    _passwordList.RemoveAt(index);
                    break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        private static void PrintOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("\tquit / exit \t close programm");
            Console.WriteLine("\tlist \t\t list stored passwords");
            Console.WriteLine("\tdelete \t\t delete at given index");
        }

        private static void PrintList()
        {
            try
            {
                Console.WriteLine("Your Current Passwords:");

                for (int i = 0; i < _passwordList.Count; i++)
                {
                    Console.WriteLine($"\t{i}\t{_passwordList[i]}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}