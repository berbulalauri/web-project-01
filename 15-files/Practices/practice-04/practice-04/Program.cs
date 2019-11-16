using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace practice_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool whileloop = true;
            string pathFinder = "";
            Console.Write(">");

            while (whileloop)
            {

                try
                {
                    var userCmd = Console.ReadLine();
                    List<string> listOfDouble = userCmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    int listLength = listOfDouble.Count;

                    if (listOfDouble[0] == "cd") { pathFinder = listOfDouble[listLength - 1]; Console.Write($"{pathFinder}>"); }

                    if (listOfDouble[0] == "dir") { consoleClass(pathFinder); txtWriterClass(pathFinder); Console.Write($"{pathFinder}>"); }

                    else if (listOfDouble[0] == "mkdir")
                    {
                        string subPath = $"{pathFinder}{listOfDouble[1]}";
                        if (!Directory.Exists(subPath)) Directory.CreateDirectory(subPath);
                        Console.Write($"{pathFinder}>");
                    }
                    else if (listOfDouble[0] == "rmdir")
                    {
                        string subPath = $"{pathFinder}{listOfDouble[1]}";
                        if (Directory.Exists(subPath)) Directory.Delete(subPath);

                        Console.WriteLine($" {listOfDouble[1]} Folder Has Removed! ");
                        Console.Write($"{pathFinder}>");
                    }

                    else if (listOfDouble[0] == "rename")
                    {

                        string subPath = $"{pathFinder}{listOfDouble[1]}";
                        string newPath = $"{pathFinder}{listOfDouble[2]}";

                        if (Directory.Exists(subPath)) Directory.Move(subPath, newPath);

                        Console.WriteLine($"Renamed From {listOfDouble[1]} To {listOfDouble[2]}");
                        Console.Write($"{pathFinder}>");

                    }else if (listOfDouble[0] == "touch")
                    {
                        string subPath = $"{pathFinder}{listOfDouble[1]}";
                        string textToAdd = "new file text goes here";

                        if (!File.Exists(subPath))
                        {
                            using (StreamWriter writer = new StreamWriter(subPath, true))
                            {
                                writer.Write(textToAdd);
                            }
                            Console.WriteLine($"New File {listOfDouble[1]} has been created! ");
                            Console.Write($"{pathFinder}>");

                        } else { Console.WriteLine($"This file Already exist!! {listOfDouble[0]}"); }

                    }
                    else if (listOfDouble[0] == "open")
                    {

                        string subPath = $"{pathFinder}{listOfDouble[1]}";

                        string[] lines = System.IO.File.ReadAllLines(subPath);
                        foreach (string line in lines)
                        {
                            Console.WriteLine("\t" + line);
                        }
                        Console.Write($"{pathFinder}>");

                    }else if (listOfDouble[0] == "rm")
                    {
                        string subPath = $"{pathFinder}{listOfDouble[1]}";

                        if (File.Exists(subPath))
                        {
                            File.Delete(subPath);
                        }
                        Console.WriteLine($"File {listOfDouble[1]} has been deleted successfully");
                        Console.Write($"{pathFinder}>");
                    }
                    else if (listOfDouble[0] == "exit")
                    {
                        whileloop = false;
                    }
                    if (listOfDouble[0] != "rm" && listOfDouble[0] != "open" && listOfDouble[0] != "touch" && listOfDouble[0] != "cd" && listOfDouble[0] != "dir" && listOfDouble[0] != "mkdir" && listOfDouble[0] != "rmdir" && listOfDouble[0] != "rename" && listOfDouble[0] != "exit")
                    {
                        Console.WriteLine($"Your Command is Wrong, Please Try Again!");
                        Console.Write($"{pathFinder}>");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static void txtWriterClass(string dir)
        {
            StreamWriter writer;
            try
            {
                FileStream file = new FileStream("../../../printConsole.txt", FileMode.OpenOrCreate, FileAccess.Write);
                var standardOutput = Console.Out;
                using (writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);

                    foreach (string f in Directory.GetFiles(dir))
                    {
                        FileInfo fi = new FileInfo(f);
                        var created = fi.CreationTime;
                        var lastmodified = fi.LastWriteTime;
                        Console.WriteLine($"{created}\t{lastmodified}\t{Path.GetFileName(f)}");

                    }
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        FileInfo fi = new FileInfo(d);
                        var created = fi.CreationTime;
                        var lastmodified = fi.LastWriteTime;
                        Console.WriteLine($"{created}\t{lastmodified}\t{Path.GetFileName(d)}");
                    }
                    Console.SetOut(standardOutput);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void consoleClass(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    FileInfo fi = new FileInfo(f);
                    var created = fi.CreationTime;
                    var lastmodified = fi.LastWriteTime;
                    Console.WriteLine($"{created}\t{lastmodified}\t{Path.GetFileName(f)}");

                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    FileInfo fi = new FileInfo(d);
                    var created = fi.CreationTime;
                    var lastmodified = fi.LastWriteTime;
                    Console.WriteLine($"{created}\t{lastmodified}\t{Path.GetFileName(d)}");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}