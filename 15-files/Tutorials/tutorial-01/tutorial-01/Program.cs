using System;
using System.IO;
using System.Text;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringdata = @"Y'all act like you never seen a white person before
Jaws all on the floor like Pam like Tommy just burst in the door
And started whoopin' her ass worse than before
They first were divorced, throwin' her over furniture (Agh!)";

            FileInfo readableFile = new FileInfo(@"../../../tutorialresult.txt");
            try
            {
                using (FileStream fileStream = readableFile.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    var data = Encoding.Default.GetBytes(stringdata);
                    fileStream.Write(data, 10, data.Length);

                }
                //using StreamWriter sw = new StreamWriter(fileinfo.FullName);
                /*                foreach (var ch in stringdata)
                                {
                                    sw.Write(ch);
                                }
                */


                Console.WriteLine("finish writing file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something going wrong {ex.Message}");
            }


        }
    }
}
