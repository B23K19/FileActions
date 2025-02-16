using System;
using System.IO;

class FileReadWrite
{
    public static void Main(string[] args)
    {

        Console.WriteLine("\t\t\t___________WriteOrRead Text file____________");
        Console.WriteLine("Do you want to read from a text file or create a file?");
        Console.WriteLine("1. Read from a file");
        Console.WriteLine("2. Write to a file");

        Console.WriteLine("\nEnter your choice: write 1 or 2");
        string choice = Console.ReadLine();

        string directory = "Directory that has the text files";
        if (choice == "1")
        {
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, "*.txt");
                if (files.Length == 0)
                {
                    Console.WriteLine("There are no files in the directory");
                    return;
                }
                else
                {
                    Console.WriteLine("The files in the directory are:");
                    foreach (string file in files)
                    {
                        Console.WriteLine($"\nFile:{Path.GetFileName(file)}");
                        Console.WriteLine($"{File.ReadAllText(file)}");
                    }
                }
            }
            else
            {
                Console.WriteLine("The directory does not exist");
            }
        }
        else if (choice == "2")
        {
            Console.WriteLine("\nEnter the file name you want to create:");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                if (!fileName.EndsWith(".text", StringComparison.OrdinalIgnoreCase))
                {
                    fileName += ".txt";
                }
                File.Create(fileName).Close();
                Console.WriteLine($"\nThe file {fileName} was successfully created");
            }
            else
            {
                Console.WriteLine($"\nThe file {fileName} already exists");
            }

            Console.WriteLine("Enter the text you want into your file:");
            string text = Console.ReadLine();
            File.WriteAllText(fileName, text);

            Console.WriteLine($"\nText successfully written to {fileName}");
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }

    }


}