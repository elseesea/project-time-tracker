using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class ProjectClient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Project> Projects { get; set; }

        public ProjectClient ()
        {

        }

        public ProjectClient (string name)
        {
            Name = name;
        }

    } // class

} // namespace
