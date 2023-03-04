using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Uebung8
{
    internal class Program
    {
        private const string exit = "exit";
        private const string quit = "quit";
        private const string list = "list";
        private const string delete = "delete";
        private const string add = "add";

        private static List<string> _passwordList = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Hello and welcome to your great Secure input password list");
                    PrintList();
                    PrintOptions();
                    Console.WriteLine("Enter the of the keywords to choose an option");

                    string option = Console.ReadLine() ?? "";

                    bool exit = CheckInput(option);

                    if (exit)
                        Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.ToString());
            }
        }

        private static bool CheckInput(string option)
        {
            try
            {
                switch (option)
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

                    case add:
                        AddToList();
                        return false;

                    default:
                        PrintOptions();
                        return false;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private static void AddToList()
        {
            try
            {
                Console.WriteLine("Enter your password");

                while (true)
                {
                    string input = GetObfuscatedUserInput();

                    if (!_passwordList.Contains(input))
                    {
                        _passwordList.Add(input);
                        break;
                    }

                    Console.WriteLine("Password already in list. Try again.");
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static string GetObfuscatedUserInput()
        {
            string input = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Debug.WriteLine($"CKI KEY: {key.Key}");
                Debug.WriteLine($"CKI KEY CHAR: {key.KeyChar}");

                if (key.Key == ConsoleKey.Enter)
                    break;
                input += key.KeyChar;
                Console.Write("*");
            }
            Console.WriteLine();

            return input;
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
            Console.WriteLine("\tadd \t\t add new password");
            Console.WriteLine("\tlist \t\t list stored passwords");
            Console.WriteLine("\tdelete \t\t delete at given index");
            Console.WriteLine("\tquit / exit \t close programm");
        }

        private static void PrintList()
        {
            try
            {
                Console.WriteLine("Your Current Passwords:");
                Console.WriteLine($"\tIndex\tPassword");
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