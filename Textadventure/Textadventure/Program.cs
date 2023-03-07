using System.Data;
using System.Runtime.InteropServices;

namespace Textadventure
{
    internal class Program
    {
        //fields needed to check if the input is valid
        private static List<String> allowedCommands = new List<String>() { "n", "e", "w", "s", "u", "x", "a", "clear" };

        //value defines the current room starting at 1 for better understanding
        private static int currentRoomNumber = 1;
        static void Main(string[] args)
        {

            PrintIntroduction();
            PrintHelp();
            Room1();

        }

        private static void PrintHelp()
        {
            Console.WriteLine("\n");
            Console.WriteLine("a\t... describe the current room");
            Console.WriteLine("u [item]\t ... use an item");
            Console.WriteLine("n\t... go north");
            Console.WriteLine("w\t... go west");
            Console.WriteLine("e\t... to east");
            Console.WriteLine("s\t... go south");
            Console.WriteLine("x\t... end your adventure (exit)");
            Console.WriteLine("clear\t ... clear the terminal and reprint the text from the current room");
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("The Quest for the Golden Key - a textadventure done by Roman Schabus");
            Console.WriteLine("\n You are in a Castle. There are three different rooms each containing two puzzles to solve in order to reacht the next room\n");

            Console.WriteLine("""
                You are a treasure hunter on a mission to find the Golden Key, an ancient artifact that unlocks a legendary treasure trove. 
                Legend has it that the key is hidden deep within a labyrinthine castle, guarded by traps and puzzles. 
                Your mission is to navigate through the castle, solve the puzzles, and find the Golden Key.
                """);

            Console.WriteLine("Good luck on your quest!");

        }

        private static void Room1()
        {
            bool keyFound = false;
            PrintRoom1();

            while (true)
            {
                string input = Console.ReadLine();

                if (!CheckInput(input)) 
                {
                    PrintError();
                    continue;
                }

                if (input.StartsWith("u"))
                {
                    if (input.Contains("sword"))
                    {
                        Console.WriteLine("""
                        The sword has been pulled and the helmet of the knight opens. 
                        It contains a key. You take the key and put it in your pockets.
                        """);

                        keyFound = true;
                    }
                    else
                    {
                        PrintError();
                    }
                }
                
                if (keyFound && input == "e")
                {
                    Console.WriteLine("You find yourself looking at a locked door.");

                    while(true)
                    {
                        input = Console.ReadLine();

                        if (!CheckInput(input))
                        {
                            continue;
                        }

                        if (input.StartsWith("u") && input.Contains("key"))
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine("You open the door and walk into the other room.");
        }

        private static void PrintRoom1()
        {
            PrintFancyHeading("The Entrance Hall");

            Console.WriteLine("""
                You enter the castle through a grand entrance hall. 
                In the center of the room is a large statue of a knight, holding a sword that looks like it can be used.
                To the right is a door leading to the next room. Find the key that opens the door.
                """);
        }

        private static void PrintRoomDescription2()
        {

            PrintFancyHeading("The Puzzle Room");

            Console.WriteLine("""
                You enter a room filled with puzzles. In the center of the room is a large chessboard. 
                On the wall, there are three levers, each with a symbol on it: a sun, a moon, and a star. There is also a door leading to the next room.
                """);

            Console.WriteLine("""
                Use the levers to unlock the door. 
                The parchment from the first room has a riddle that provides clues on which lever to pull in which order. 
                Pull the levers in the correct order, and the door will unlock.
                """);
        }

        private static void PrintRoomDescription3()
        {
            PrintFancyHeading("The Treasure Room");

            Console.WriteLine("""
                You enter a room filled with gold and jewels. In the center of the room is a pedestal with a small box on it. 
                There is also a door leading out of the room.
                """);

            Console.WriteLine("""
                Open the box. The box is locked with a combination.
                The riddle from the first room provides clues to the combination.
                """);
        }

        private static void PrintEnding()
        {
            Console.WriteLine("""
                Once the box is opened you find the golden key. The golden key is then used to open the door behind the pedestal. 
                You escape the castle not only to tell a great story, but also with the might you earned throught your journy. 
                Good luck on your next adventure!
                """);
        }

        private static void PrintFancyHeading(string text)
        {
            Console.WriteLine($"\n\n################# {text} #################\n\n");
        }

        private static bool CheckInput(string input)
        {

            string command = input[0].ToString();

            if (!String.IsNullOrEmpty(input) && allowedCommands.Contains(command))
            {
                return true;
            }

            return false;
        }
        private static void PrintError()
        {
            Console.WriteLine("That did not work.");
        }
    }
}