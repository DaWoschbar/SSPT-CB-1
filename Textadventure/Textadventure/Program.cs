namespace Textadventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintIntroduction();
            PrintHelp();
            PrintRoomDescription1();

            while (true) 
            { 

            }

            
        }

        private static void PrintHelp()
        {
            Console.WriteLine("\n");
            Console.WriteLine("a\t... describe the current room");
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
            string storytext = """
                You are a treasure hunter on a mission to find the Golden Key, an ancient artifact that unlocks a legendary treasure trove. 
                Legend has it that the key is hidden deep within a labyrinthine castle, guarded by traps and puzzles. 
                Your mission is to navigate through the castle, solve the puzzles, and find the Golden Key.
                """;

            Console.WriteLine(storytext);

            Console.WriteLine("Good luck on your quest!");

        }

        private static void PrintRoomDescription1()
        {
            PrintFancyHeading("The Entrance Hall");
            Console.WriteLine("""
                You enter the castle through a grand entrance hall. 
                In the center of the room is a large statue of a knight, holding a sword.
                To the left of the statue is a table with a locked chest on it. 
                To the right is a door leading to the next room.
                """);

            Console.WriteLine("""
                Find the key to the chest. The key is hidden somewhere in the room. 
                Once you unlock the chest, you find a piece of parchment with a riddle on it.
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
            Console.WriteLine($"################# {text} #################");
        }
        private static void PrintError()
        {
            Console.WriteLine("That did not work.");
        }
    }
}