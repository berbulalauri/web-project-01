using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Holiday holiday = new Holiday
            {
                Date = DateTime.Now,
                Designation = "holiday tutorils",
                IsDayOff = false

            };

            string json = JsonConvert.SerializeObject(holiday);
            Console.WriteLine(json);
            var holidayFromJson = JsonConvert.DeserializeObject<Holiday>(json);
            Console.WriteLine($"object json: {holidayFromJson}");

        }
    }
    [Serializable]
    public class Holiday
    {
        public DateTime Date { get; set; }
        public string Designation { get; set; }
        public bool IsDayOff { get; set; }

        public override string ToString()
        {
            return $"data: {Date}\n Designation: {Designation}\n dayoff: {IsDayOff}";
        }

    }
}
