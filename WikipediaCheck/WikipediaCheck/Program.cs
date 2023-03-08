using System.Net;

namespace WikipediaCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wikipedia Check");
            try
            {
                while (true)
                {
                    Console.WriteLine("Geben Sie einen zu Suchenden Namen ein. Achtung große Anfangsbuchstaben!");
                    string input = Console.ReadLine() ?? "";

                    if (!String.IsNullOrEmpty(input))
                    {
                        input = input.Replace(" ", "_");
                        string content;

                        try
                        {
                            content = new WebClient().DownloadString($"https://de.wikipedia.org/wiki/{input}");

                        }
                        catch (WebException ex)
                        {

                            Console.WriteLine("Zu dem eingegebenen Namen existiert kein Eintrag!"); 
                            continue;
                        }

                        foreach (string line in content.Split("\n"))
                        {
                            if (line.Contains("footer-info-lastmod"))
                            {
                                Console.WriteLine(line.Replace("<li id=\"footer-info-lastmod\">", "").Replace("</li>", ""));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh no something went wrong, closing programm \n Error:");
                throw new Exception(ex.Message);
            }
        }
    }
}