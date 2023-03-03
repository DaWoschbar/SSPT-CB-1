namespace Uebung4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter leap year: ");
                string input = Console.ReadLine();

                int year = DateTime.Now.Year;

                if (input != "")
                {
                    year = int.Parse(input);
                }

                if (year < 0)
                {
                    Console.WriteLine("Invalid year.");
                    return;
                }

                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                {
                    Console.WriteLine($"{year} is a leap year - nice!");
                }
                else
                {
                    Console.WriteLine($"Sorry, {year} is no leap year ;-;");
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Unkown error.");
            }
        }
    }
}