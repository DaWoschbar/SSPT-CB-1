namespace Uebung_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Checkname - Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Last character in name: {name[name.Length - 1]}");

            NameLength(name);
            CheckSpace(name);
            NameToUppercase(name);
        }

        private static void NameLength(string name)
        {
            Console.WriteLine($"Length: {name.Length}");
        }
        private static void CheckSpace(string name)
        {
            if (name.Contains(" "))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == ' ')
                    {
                        Console.WriteLine($"Spaces: yes, at position {i + 1}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Spaces: nope");
            }
        }
        private static void NameToUppercase(string name)
        {
            Console.WriteLine($"Full name in uppercase: {name.ToUpper().Replace(" ", "")}");
        }
    }
}