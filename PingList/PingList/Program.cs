using System.Runtime.InteropServices;

namespace PingList
{
    internal class Program
    {
        static void Main(string[] args)
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

                if(!ValidateParameters(arg1, filename))
                {
                    Console.WriteLine("");
                }
                else
                {
                    int iterations;

                    if(int.TryParse(arg1, out iterations))
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

        private static void ExecutePingOperation(int iterations, string filename)
        {
            throw new NotImplementedException();
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