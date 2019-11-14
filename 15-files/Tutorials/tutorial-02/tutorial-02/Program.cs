using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo file=new FileInfo(@"../../../tutorialresult.txt");
            Console.WriteLine(file);
            try
            {
                List<string> list = new List<string>();
                var fs = file.OpenRead();
                using(var streamreader=new StreamReader(fs))
                {
                    string line;
                    while((line = streamreader.ReadLine()) != null)
                    {
                        list.Add(line);
                    };
                    list.ForEach(Console.Write);
                }

            } catch( Exception ex)
            {

            }
        }
    }
}
