using System.Data;
using System.Runtime.InteropServices;

namespace Textadventure
{
    internal class Program
    {
        //fields needed to check if the input is valid
        private static List<String> allowedCommands = new List<String>() { "n", "e", "w", "s", "u", "x", "a", "help" };

        //value defines the current room starting at 1 for better understanding
        private static int currentRoomNumber = 1;
        static void Main(string[] args)
        {
            //the delay below is just so that the user is not fronted with a bunch of text and won't be overwhelmed
            PrintIntroduction();
            PrintHelp();
            Console.WriteLine("\nPress any key to start your journey...\n");
            Console.ReadKey();
            Room1();
            Room2();
            Room3();
            PrintEnding();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("\n");
            Console.WriteLine("a\t\t... clear console and redescribe the current room");
            Console.WriteLine("u [item]\t ... use an item");
            Console.WriteLine("n\t\t... go north");
            Console.WriteLine("w\t\t... go west");
            Console.WriteLine("e\t\t... to east");
            Console.WriteLine("s\t\t... go south");
            Console.WriteLine("x\t\t... end your adventure (exit)");
            Console.WriteLine("help\t\t... this help screen");
        }
        private static void PrintIntroduction()
        {
            Console.WriteLine("The Quest for the Golden Key - a text adventure done by Roman Schabus");
            WriteStory("\nYou are in a Castle. There are three different rooms each containing two puzzles to solve in order to reach the next room\n");

            WriteStory("""
                You are a treasure hunter on a mission to find the Golden Key, an ancient artifact that unlocks a legendary treasure trove. 
                Legend has it that the key is hidden deep within a labyrinthine castle, guarded by traps and puzzles. 
                Your mission is to navigate through the castle, solve the puzzles, and find the Golden Key. Since the chest is already in your possession, all that's left to do is finding the key that opens it...
                """);

            WriteStory("Good luck on your quest!");

        }

        #region Rooms and text
        private static void Room1()
        {
            bool keyFound = false;
            PrintRoomDescription1();

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (!CheckInput(input)) 
                {
                    PrintError();
                    continue;
                }

                if (input.StartsWith("u"))
                {
                    if (input.Contains("sword"))
                    {
                        WriteStory("""
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
                    WriteStory("You find yourself looking at a locked door.");

                    while(true)
                    {
                        input = Console.ReadLine().ToLower();

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
            WriteStory("You open the door and walk into the other room.");
        }
        private static void PrintRoomDescription1()
        {
            PrintFancyHeading("The Entrance Hall");

            WriteStory("""
                You enter the castle through a grand entrance hall. 
                In the center of the room is a large statue of a knight, holding a sword that looks like it can be used.
                To the right is a door leading to the next room. Find the key that opens the door.
                """);
        }
        private static void Room2()
        {
            currentRoomNumber++;
            bool boulderMoved = false;

            PrintRoomDescription2();

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("u") && input.Contains("chess"))
                {
                    WriteStory("""
                       You move the chess piece entlong the weird lines to the end. 
                       Suddenly the room starts to shake and the boulder beings to move towards the right side of the room revealing an entrance to another part of the castle.
                       """);
                    boulderMoved = true;
                }
                else if (input.StartsWith("n") && boulderMoved)
                {
                    WriteStory("You walk towards the entrance and walk right through it.");
                    break;
                }
            }
        }
        private static void PrintRoomDescription2()
        {
            PrintFancyHeading("The Puzzle Room");

            WriteStory("""
                You enter a room filled with puzzles. In the center of the room is a large chessboard. 
                On the chessboard is a single chess piece right in the middle. The cheesboard is kind of strange, it has some weird lines on it.
                Behind the board is a boulder which seems unmoveable by a normal human being.
                """);
        }
        private static void Room3()
        {
            currentRoomNumber++;
            PrintRoomDescription3();

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (CheckInput(input))
                {
                    if (input.StartsWith("n"))
                    {
                        WriteStory("""
                            You walk towards the box and find the golden key. It's aura is almost frighenting, but the key itself shines in a nice golden tone.
                            But it is behind some glass that cannot be destroyed. After inspecting the glass some more you realize that there is palm print which looks very familiar to yours.
                            """);
                    }
                    else if (input.StartsWith("u") && input.Contains("hand"))
                        {

                        WriteStory("""
                            You place the hand on the glass. A beam of light appears which fills the room and starts to blind you.

                            A few seconds later the glass disappeared and the key is to be taken out of the box.
                            """);
                        break;
                    }
                }
            }
        }
        private static void PrintRoomDescription3()
        {
            PrintFancyHeading("The Treasure Room");

            WriteStory("""
                You enter a room filled with gold and jewels. In the center of the room is a pedestal with a small box on it. 
                There is also a door leading out of the room.
                """);
        }
        private static void PrintEnding()
        {
            WriteStory("""
                Once the box is opened you find the golden key. The golden key is then used to open the door behind the pedestal. 
                You escape the castle not only to tell a great story, but also with the might you earned throught your journy. 
                Good luck on your next adventure!
                """);
        }
        #endregion
        private static void PrintFancyHeading(string text)
        {
            Console.WriteLine($"\n\n################# {text} #################");
        }
        private static bool CheckInput(string input)
        { 
            if (!String.IsNullOrEmpty(input))
            {
                string command = input[0].ToString();
                if (!String.IsNullOrEmpty(input))
                {
                    if (input == "x")
                    {
                        Environment.Exit(0);
                    }
                    else if (input == "a")
                    {
                        //clear the current console screen and print the current room description again
                        Console.Clear();
                        switch (currentRoomNumber)
                        {
                            case 1:
                                PrintRoomDescription1();
                                break;
                            case 2:
                                PrintRoomDescription2();
                                break;
                            case 3:
                                PrintRoomDescription3();
                                break;
                        }
                    }
                    else if (input == "help")
                    {
                        //todo: Currently always returns the error message when help is entered
                        PrintHelp();
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
        
        private static void WriteStory(string text)
        {
            Console.WriteLine();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Thread.Sleep(500);
            Console.WriteLine();
        }
        private static void PrintError()
        {
            Console.WriteLine("That did not work.");
        }
    }    
}