using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;



namespace Delegate
{
    internal class Program
    {
        //delcare delegate
        private delegate bool DelegateSelection(string marticularnumber, DateTime date);
        static void Main(string[] args)
        {
            while (true)
            {
                DateTime dt;
                string marticulationNumber;

                try
                {
                    while (true)
                    {
                        Console.WriteLine("Geben Sie das Datum ein (Format: TT.MM.YYYY):");
                        string date = Console.ReadLine() ?? "";

                        if (String.IsNullOrEmpty(date))
                        {
                            Console.WriteLine("Keine Eingabe");
                            continue;
                        }

                        else if (!DateTime.TryParse(date, out dt))
                        {
                            Console.WriteLine("Ungültiges Datumsformat oder Datum");
                            continue;
                        }

                        break;
                    }

                    while (true)
                    { 
                        Console.WriteLine("Geben Sie eine Martrikelnummer ein (Format isJJXXXX):");
                        marticulationNumber = Console.ReadLine() ?? "";

                        if (!CheckIfMarticulationNumberValid(marticulationNumber))
                        {
                            Console.WriteLine("Keine Eingabe");
                            continue;
                        }
                        break;
                    }

                    PrintOptions();

                    while (true) {
                        string selection = Console.ReadLine() ?? "";

                        DelegateSelection delsec = null;

                        switch (selection)
                        {
                            case "1":
                                delsec = new DelegateSelection(CheckMonth);
                                break;

                            case "2":
                                delsec = new DelegateSelection(CheckDayOfMarticulationNumber);
                                break;

                            case "3":
                                delsec = new DelegateSelection(MonthInMartriculationNumber);
                                break;

                            default:
                                Console.WriteLine("Ungültige Eingabe");
                                continue;
                        }

                        if (delsec(marticulationNumber, dt))
                            PrintResult("JA");
                        else
                            PrintResult("NEIN");

                        Console.WriteLine();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error\n" + ex.Message);
                    continue;
                }
            }
        }

        private static void PrintOptions()
        {
            Console.WriteLine("""
                1 ... Ist der Monat in der Matrikelnummer enthalten?
                2 ... Ist der Tag in der Matrikelnummer enthalten? 
                3 ... Ist das Jahr des Datums das Inskriptionsjahr der Matrikelnummer?
                """);
        }

        private static bool CheckMonth(string marticularnumber, DateTime date)
        {
            if (marticularnumber.Contains(date.Month.ToString()))
                return true;
            else
                return false;
        }

        private static bool CheckDayOfMarticulationNumber(string marticularnumber, DateTime date)
        {
            if (marticularnumber.Contains(date.Day.ToString()))
                return true;
            else
                return false;
        }

        private static bool MonthInMartriculationNumber(string marticularnumber, DateTime date)
        {
            string year = date.Year.ToString();
            if (marticularnumber[2] == year[0] && marticularnumber[3] == year[1])
                return true;
            else
                return false;
        }

        private static bool CheckIfMarticulationNumberValid(string marticulationNumber)
        {
            if (String.IsNullOrEmpty(marticulationNumber) || marticulationNumber.Length < 7) 
                return false;

            return true;
        }

        private static void PrintResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ergebnis: {result}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}