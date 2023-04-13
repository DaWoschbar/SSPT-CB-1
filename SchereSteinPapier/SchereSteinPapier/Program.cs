namespace SchereSteinPapier
{
    internal class Program
    {
        //declare fields to count the won rounds 
        private static int _playerWon = 0;
        private static int _computerWon = 0;
        private static int _ties = 0;
        private static int _roundCounter = 0;

        //List to determine the choosen type
        private static Dictionary<int, string> _selection = new() { { 1, "Schere" }, { 2, "Stein" }, { 3, "Papier" } };

        //Global accessible variable winner
        private static string _winner = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Schere Stein Papier");
            while (true)
            {
                try
                {
                    PrintOptions();
                    int playerSelection = GetPlayerSelection();

                    if (playerSelection == -1)
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                    }
                    else if (playerSelection == 0)
                    {
                        Environment.Exit(0);
                    }

                    int computerSelection = GetComputerSelection();

                    DetermineWinner(playerSelection, computerSelection);
                    Console.Clear();
                    PrintResults(playerSelection, computerSelection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oh no, ein Fehler ist aufgetreten\n" + ex.Message); ;
                }
            }
        }

        private static void DetermineWinner(int player, int computer)
        {
            try
            {
                if (player == computer)
                {
                    _ties++;
                }
                else if ((player == 1 && computer == 2) || (player == 2 && computer == 3) || (player == 3 && computer == 1))
                {
                    _winner = "Computer";
                    _computerWon++;
                }
                else
                {
                    _winner = "Player";
                    _playerWon++;
                }
                _roundCounter++;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static int GetComputerSelection()
        {
            try
            {
                Random rnd = new Random();
                return rnd.Next(1, 4);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private static int GetPlayerSelection()
        {
            try
            {
                Console.WriteLine("Wählen Sie aus:");
                string input = Console.ReadLine() ?? "";
                int res = 0;

                if (String.IsNullOrEmpty(input))
                    return -1;

                else if (!int.TryParse(input, out res))
                    return -1;

                if (res > 3 || res < 0)
                    return -1;

                return res;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private static void PrintOptions()
        {
            Console.WriteLine("""
                    1 Schere
                    2 Stein
                    3 Papier
                    0 Beenden
                """);
        }

        private static void PrintResults(int valuePlayer, int valueComputer)
        {
            try
            {
                string player = _selection[valuePlayer];
                string computer = _selection[valueComputer];

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Round\t\t\t: {_roundCounter}");
                Console.WriteLine($"Spieler\t\t\t: {player}");
                Console.WriteLine($"Computer\t\t: {computer}");
                Console.WriteLine($"Gewinner\t\t: {_winner}");
                Console.WriteLine($"Spielstand\t\t: Player {_playerWon}\t Computer: {_computerWon}");
                Console.WriteLine($"Unentschieden\t\t: {_ties}");
                Console.WriteLine("-----------------------------------------");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}