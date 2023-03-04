namespace Uebung7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = InputInt("Enter a number between 5 and 10", 5, 10);
                Console.WriteLine($"Nice, your number {num} is between min and max ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error :c");
            }
        }

        private static int InputInt(string text, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(text);

                string input = Console.ReadLine();
                int num = 0;

                if (int.TryParse(input, out num))
                    num = int.Parse(input);
                    

                if (num == 0)
                {
                    Console.WriteLine("Invalid input or 0");
                    continue;
                }

                if (num > min && num < max)
                    return num;

                Console.WriteLine("Not in rage - try again.");
            }
        }
    }
}