using System.IO;

namespace Uebung10
{
    internal class Program
    {
        //Constants required for the programm
        private const string todoFilePath = "todos.txt";
        private const string quit = "quit";
        private const string delete = "delete";

        //Global list which will be used to write to the file 
        private static List<string> _todoList = new List<string>();

        //string to print additional messages
        private static string _actionMessage = "";

        static void Main(string[] args)
        {
            try 
            {
                CreateBackupCopy();
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Your personal Todo List");
                    ReadFromTodosFile();
                    Console.WriteLine();

                    if (_actionMessage != "")
                    {
                        Console.WriteLine(_actionMessage);
                        _actionMessage = "";
                    }

                    PrintList();
                    Console.WriteLine("Enter the things you want to do:");

                    PrintOptions();
                    string input = Console.ReadLine() ?? "";

                    bool exit = CheckOptions(input);

                    if (exit)
                    {
                        Environment.Exit(0);
                    }

                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Oh no! Something unknonw happend ");
                Console.WriteLine(ex.Message);
            }

        }

        private static bool CheckOptions(string options)
        {
            try
            {
                switch (options)
                {
                    case quit:
                        return true;

                    case delete:
                        DeleteTodosFile();
                        return false;

                    default:
                        AddTodoToList(options);
                        return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private static void AddTodoToList(string input)
        {
            try
            {
                if (!_todoList.Contains(input))
                {
                    _todoList.Add(input);
                    AddToFile(input);
                    return;
                }

                _actionMessage = "Task already in List.";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static void AddToFile(string todo)
        {
            try
            {
                //Creating file if it doesn't exist yet
                if (!File.Exists(todoFilePath))
                {
                    File.CreateText(todoFilePath);  
                }

                using (StreamWriter sw = File.AppendText(todoFilePath))
                {
                    sw.WriteLine(todo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void ReadFromTodosFile()
        {
            try
            {
                if(File.Exists(todoFilePath))
                {

                    _todoList.Clear();
                    using (StreamReader sr = File.OpenText(todoFilePath))
                    {
                        string todo;
                        while ((todo = sr.ReadLine()) != null)
                        {
                            _todoList.Add(todo);
                        }
                    }
                    Console.WriteLine("Successfully loaded todos.txt");
                }
                else
                {
                    Console.WriteLine("todos.txt file not found - continuing without todos.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void DeleteTodosFile()
        {
            try
            {
                if(File.Exists(todoFilePath))
                {
                    File.Delete(todoFilePath);
                    _actionMessage = "Successfully deleted todos.txt";
                    _todoList.Clear();
                }
                else 
                {
                    Console.WriteLine("todos.txt file does not exist - nothing to delete.");
                }
            }
            catch 
            { 
            
            }   
        }

        private static void CreateBackupCopy()
        {
            try
            {
                if (File.Exists(todoFilePath))
                {
                    //the boolean at the end is responsible to overwrite older backups 
                    File.Copy(todoFilePath, "todos.bck", true);
                    _actionMessage = "Successfully created backup file tods.bck";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        private static void PrintList()
        {
            try
            {
                if (_todoList.Count > 0)
                {
                    Console.WriteLine("\tIndex\tTask");

                    for (int i = 0; i < _todoList.Count; i++)
                    {
                        Console.WriteLine($"\t{i}\t{_todoList[i]}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void PrintOptions()
        {
            try
            {
                Console.WriteLine("\tdelete \t\tdeletes todos.txt file and clears your todos");
                Console.WriteLine("\tquit\t\tquit the program");
                Console.WriteLine("Type anything here to add a new todo:");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}