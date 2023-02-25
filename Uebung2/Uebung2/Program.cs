namespace Uebung2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter height in m: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Enter weight in kg: ");
            double weight = double.Parse(Console.ReadLine());

            double bmi = weight / (height * height);

            Console.WriteLine($"Your BMI is: {Math.Round(bmi, 2)}");

            Console.WriteLine("According to your BMI you are ");

            if (bmi < 18.5)
            {
                Console.Write("underweight.");
            }
            else if (bmi > 25)
            {
                Console.Write("overweight.");
            }
            else
            {
                Console.Write("normal.");
            }

        }
    }
}