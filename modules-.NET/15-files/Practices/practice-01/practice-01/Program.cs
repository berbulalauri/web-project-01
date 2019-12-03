using System;
using System.IO;
using System.Runtime.CompilerServices;

class Test
{
    public static void Main()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("1. HELP     Commands list");
        Console.WriteLine("2. DISK     Displays detailed disks information");
        Console.WriteLine("3. EXIT     Exit");
        Console.WriteLine("===========================================");

        bool isTrue = true;
        while (isTrue)
        {
            Console.Write(">");
            var userInput = Console.ReadLine();

            if (userInput == "help")
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("HELP     Commands list");
                Console.WriteLine("DISK     Displays detailed disks information");
                Console.WriteLine("EXIT     Exit");
                Console.WriteLine("===========================================");
            }
            else if(userInput == "disk")
            {
                consoleWriter();
                txtWriteMethod();
            } else if(userInput == "exit")
            {
                isTrue = false;
            }
        }
    }

    public static void consoleWriter()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Name {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType); 
                if (d.IsReady == true)
                {
                    Console.WriteLine("File system: {0}", d.DriveFormat);
                    Console.WriteLine("Total size of drive:   {0, 15} bytes ",d.TotalSize);
                    Console.WriteLine("Total available space: {0, 15} bytes\n",d.TotalFreeSpace);
                }
            }
    }  
    public static void txtWriteMethod()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
            StreamWriter writer;
 
            FileStream file = new FileStream("../../../practice1.txt", FileMode.OpenOrCreate, FileAccess.Write);
            var standardOutput = Console.Out;
            using (writer = new StreamWriter(file))
            {
                    Console.SetOut(writer);

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Name {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType); 
                if (d.IsReady == true)
                {
                    Console.WriteLine("File system: {0}", d.DriveFormat);
                    Console.WriteLine("Total size of drive:   {0, 15} bytes ",d.TotalSize);
                    Console.WriteLine("Total available space: {0, 15} bytes\n",d.TotalFreeSpace);
                }
            }
                Console.SetOut(standardOutput);
            }
    }
}
