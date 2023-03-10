using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace PingList
{
    internal class Program
    {
        //field for the log file
        private static string _logPath = @"log.txt";

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Missing Input");
                    PrintExample();
                }
                else
                {
                    string arg1 = args[0];
                    string filename = args[1];

                    if (!ValidateParameters(arg1, filename))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        int iterations;

                        if (int.TryParse(arg1, out iterations))
                        {
                            ExecutePingOperation(iterations, filename);
                        }
                        else
                        {
                            Console.WriteLine("Iteration is not a number!");
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Unkown Error\n" + ex.Message);
            }

        }

        private static void ExecutePingOperation(int iterations, string filename)
        {
            try
            {
                for (int i = 0; i < iterations; i++)
                {
                    foreach (string line in File.ReadAllLines(filename))
                    {
                        DateTime dt = DateTime.Now;
                        Console.ForegroundColor = ConsoleColor.White;
                        try
                        {
                            //Setting the timeout to 3000ms = 3s
                            PingReply result = new Ping().Send(line, 3000);

                            Console.ForegroundColor = ConsoleColor.Green;
                            string message = $"{dt} OK {line}";
                            Console.WriteLine(message);
                            LogResult(message);
                        }
                        // If the ping should not reach the targeted host we catch the exception and print out the result
                        catch (PingException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            string message = $"{dt} NOK {line}";
                            Console.WriteLine(message);
                            LogResult(message);
                        }
                        finally
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static void LogResult(string message)
        {
            File.AppendAllText(_logPath, message + "\n");
        }

        private static void PrintExample()
        {
            Console.WriteLine("PingList.exe <number of iterations> <txt file contaning the ip addresses or hostnames");
            Console.WriteLine("PingList.exe 2 input.txt");
        }

        private static bool ValidateParameters(string arg1, string arg2)
        {
            if(string.IsNullOrEmpty(arg1) || string.IsNullOrEmpty(arg2))
            {
                return false;
            }



            return true;
        }
    }
}