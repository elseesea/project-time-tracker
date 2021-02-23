using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string aspnetusersId { get; set; } // This is foreign key to aspnetusers.Id

        public ProjectClient Client { get; set; }

        public int ClientId { get; set; } // This is foreign key to clients table

        public Project(string description, string currentUserID)
        {
            Description = description;
            aspnetusersId = currentUserID;
        }

        public Project()
        {

        }

    } // class
} // namespace
