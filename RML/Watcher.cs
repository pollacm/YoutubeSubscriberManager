using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSubscriberManager
{
    public class Watcher
    {
        public string WatcherName { get; set; }
        public string VideoName { get; set; }
        public int TimeHolderNumber { get; set; }
        public decimal TimeHolderMaxWatchMinutes { get; set; }
        public int TimeHolderMaxViewCount { get; set; }
        public decimal FirstWatchMinutes { get; set; }
        public int FirstViewCount { get; set; }
        public decimal SecondWatchMinutes { get; set; }
        public int SecondViewCount { get; set; }
        public int WhiteWatches { get; set; }
        public Subscriber.Subscriber.ListTypeEnum ListType { get; set; }
        public string Comment { get; set; }
        public int HoursBack { get; set; }
        public decimal GuessedWatchTime { get; set; }
        public decimal AverageWatchTime { get; set; }
        public decimal MaxWatchTime { get; set; }
        public Video Video { get; set; }
        public TimeHolder TimeHolder { get; set; }
    }
}
