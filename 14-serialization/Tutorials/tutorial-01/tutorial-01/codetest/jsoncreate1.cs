using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string _holiday = "../../../readfile.json";
            Holiday holiday = new Holiday
            {
                Date = DateTime.Now,
                Designation = "holiday tutorils",
                firstData = "my name",
                secondData = "my surname",
                IsDayOff = false

            };
            Console.WriteLine($"hoilday object was created : ");
            Console.WriteLine($"{holiday}");

            //Stream stream = null;
            Stream writeStream = null;
            Stream readStream = null;


            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (StreamWriter file = File.CreateText(_holiday)) 
              //using (writeStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    //string json = JsonConvert.SerializeObject(holiday);
                    //Console.WriteLine(json);

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, holiday);

                    //binaryFormatter.Serialize(writeStream, holiday);
                    //Console.WriteLine($"object was serialized in {_holiday}");
                }
                // writeStream?.Close();

                Console.WriteLine("Ser completed\n de start!");
                // read file into a string and deserialize JSON to a type
                Holiday Holiday1 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(_holiday));

                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(_holiday))
                {
                    Console.WriteLine("de start!");
                    JsonSerializer serializer = new JsonSerializer();
                    Holiday movie2 = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                    Console.WriteLine(movie2);
                }

                //using (readStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Read))
                //{
                //    var holidayFromJson = JsonConvert.DeserializeObject<Holiday>(json);
                //    Console.WriteLine($"object json: {holidayFromJson}");

                //    Holiday holidayBinnary = (Holiday)binaryFormatter.Deserialize(readStream);
                //    Console.WriteLine($"object was Deserialized from {_holiday}");
                //    Console.WriteLine(holidayBinnary);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong {ex.Message}");

            }
        }
    }
    [Serializable]
    public class Holiday
    {
        public DateTime Date { get; set; }
        public string Designation { get; set; }
        public string firstData { get; set; }
        public string secondData { get; set; }
        public bool IsDayOff { get; set; }

        public override string ToString()
        {
            return $"\nmy Second data:{secondData}\nmy fist data:{firstData}\ndata: {Date}\n Designation: {Designation}\n dayoff: {IsDayOff}";
        }

    }
}



/*
 using System;
using System.Collections.Generic;

namespace project_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,((int, int, int), (int, int, int))> openWith = new Dictionary<int, ((int, int, int), (int, int, int))>();
            Dictionary<int,((int, int, int, int), (int, int, int, int))> openWith1 = new Dictionary<int, ((int, int, int, int), (int, int, int, int))>();

            //openWith[0] = ((1, 1, 1, 1, 1), (1, 1));
            //openWith1[0] = ((1, 1, 1, 1, 1), (1,1, 1));
            //openWith1[1] = ((1, 2, 1, 1, 1), (1,1, 1));

            //Console.WriteLine(openWith1[1]);
            //openWith1[1] = openWith[0];
            //Console.WriteLine(openWith1[1]);

             var openWith3 = new Dictionary<int, ((int, int, int, int), (int, int, int, int))>();

            openWith3[0] = ((11, 22, 33, 44), (55, 66, 77, 888));
            Console.WriteLine(openWith3[0].Item1.Item3);
            Console.WriteLine(openWith3[0].Item2.Item3);
        }
    }
}

 */
