using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student
            {
                Number=22,
                Name="berdia"
            };
            var ass = Assembly.GetExecutingAssembly();

            ass.GetTypes().ToList().ForEach(a => {
                Console.WriteLine(a.Name);
                a.GetMethods().ToList().ForEach(
                    b =>
                    {
                        Console.WriteLine("--> method {0} is {1}",b.Name,(b.IsPublic ? "Public" : "private"));
                        b.GetParameters().ToList().ForEach(
                            g =>
                            {
                                Console.WriteLine($"--> parameters: {g.Name} with types {g.ToString()}");
                            });
                    });
            } ); 


        }
    }
    class Student
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public void DisplayData()
        {
            Console.WriteLine($"data: {Number} {Name}");
        }
    }
}
