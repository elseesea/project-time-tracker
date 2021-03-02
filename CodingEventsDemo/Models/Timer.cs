using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Timer
    {
        public int Id { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public Models.Task Task { get; set; }

        public int TaskId { get; set; }

        public Timer(DateTime beginTime, DateTime endTime)
        {
            BeginTime = beginTime;
            EndTime = endTime;
        }

        public Timer()
        {

        }
    } // class

} // namespace
