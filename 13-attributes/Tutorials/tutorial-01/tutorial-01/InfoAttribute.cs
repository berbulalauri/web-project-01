using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tutorial_01
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true, Inherited =false)]
    public class InfoAttribute : Attribute
    {
        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public List<string> Reviewers { get; set; }

        public InfoAttribute(string author, int revision,string desc)
        {
            Author = author;
            Revision = revision;
            Description = desc;
            Console.WriteLine($"Author: {Author}, Revision: {Revision}, Desc:{Description}");
        }
    }
}
