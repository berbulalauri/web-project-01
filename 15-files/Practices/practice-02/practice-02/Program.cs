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
                    
                    else if (listOfDouble[0] == "exit")
                    {
                        whileloop = false;
                    }
                    if (listOfDouble[0] != "cd" && listOfDouble[0] != "dir" && listOfDouble[0] != "exit")
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
                FileStream file = new FileStream("../../../practice2.txt", FileMode.OpenOrCreate, FileAccess.Write);
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