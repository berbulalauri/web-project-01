using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Models
{
    public class Car
    {
        public string Id { get; set; }
        public string _id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
