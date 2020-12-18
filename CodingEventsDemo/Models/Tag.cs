using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Tag
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public Tag ()
        {

        }

        public Tag (string name)
        {
            Name = name;
        }
    } // class
} // namespace
