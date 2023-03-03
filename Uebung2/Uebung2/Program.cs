namespace Uebung2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter height in m: ");
                double height = double.Parse(Console.ReadLine());

                Console.Write("Enter weight in kg: ");
                double weight = double.Parse(Console.ReadLine());

                if (height <= 0 || weight <= 0)
                {
                    Console.WriteLine("Error: Wrong input.");
                    return;
                }

                double bmi = weight / (height * height);

                Console.WriteLine($"Your BMI is: {bmi:F2}");

                Console.Write("According to your BMI you are ");

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
            catch (Exception)
            {

                Console.WriteLine("Oh no something went wrong :(");
            }
        }
    }
}