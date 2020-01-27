using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSubscriberManager
{
    public class Watchers
    {
        public Subscriber.Subscriber Subscriber { get; set; }
        public Video Video { get; set; }
        public string Comment { get; set; }
        public int HoursBack { get; set; }
        public decimal GuessedWatchTime { get; set; }
        public decimal AverageWatchTime { get; set; }
        public decimal MaxWatchTime { get; set; }
        public TimeHolder TimeHolder { get; set; }
    }
}
