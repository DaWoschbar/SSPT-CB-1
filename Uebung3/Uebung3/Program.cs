namespace Uebung3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Height in cm: ");
                int height = int.Parse(Console.ReadLine());

                Console.Write("Weight in kg: ");
                double weight = int.Parse(Console.ReadLine());

                if (height <= 0 || weight <= 0)
                {
                    Console.WriteLine("Invalid values.");
                }

                double bodyarea = Math.Sqrt((height * weight) / 3600);

                Console.WriteLine($"Bodyarea: {bodyarea:F2}");
            }
            catch (Exception)
            {

                Console.WriteLine("Unkown error occured.");
            }
        }
    }
}