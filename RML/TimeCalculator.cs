using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSubscriberManager
{
    public class TimeCalculator
    {
        private readonly List<TimeHolder> TimeHolders;

        public TimeCalculator(List<TimeHolder> timeHolders)
        {
            TimeHolders = timeHolders;
        }

        public TimeHolder GetHoursBackFromString(string timeString)
        {
            if (timeString.Contains(" minutes"))
            {
                return TimeHolders.Single(t => t.TimeElement == 0);
            }

            if (timeString.Contains(" hours"))
            {
                var parsedTime = int.Parse(timeString.Split(' ')[0].Trim());
                return TimeHolders.Single(t => t.TimeElement == parsedTime);
            }

            return null;
        }

        public void CalculateTimeInfo(Watchers watcher, List<Watchers> watchers)
        {
            var totalMinutes = 0m;
            var totalViews = 0;

            totalMinutes += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement).WatchMinutes;
            totalViews += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement).ViewCount;
            if (watcher.TimeHolder.TimeElement > 0)
            {
                totalMinutes += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement - 1).WatchMinutes;
                totalViews += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement - 1).ViewCount;
            }

            var whiteListWatchersForTime = 0;
            whiteListWatchersForTime += TimeHolders.Count(t => t.TimeElement == watcher.TimeHolder.TimeElement && watcher.Subscriber != null
                                        && watcher.Subscriber.ListType == Subscriber.Subscriber.ListTypeEnum.White);

            var whiteListWatchTime = 0m;
            whiteListWatchTime = watchers.Where(w => w.TimeHolder != null && w.TimeHolder.TimeElement == watcher.TimeHolder.TimeElement && w.Video.Name == watcher.Video.Name
                                                     && w.Subscriber.ListType == Subscriber.Subscriber.ListTypeEnum.White).Sum(w => w.Video.Time);
            if (watcher.TimeHolder.TimeElement > 0)
            {
                whiteListWatchersForTime += TimeHolders.Count(t => t.TimeElement == watcher.TimeHolder.TimeElement - 1 && watcher.Subscriber != null
                                            && watcher.Subscriber.ListType == Subscriber.Subscriber.ListTypeEnum.White);

                whiteListWatchTime = watchers.Where(w => w.TimeHolder != null && w.TimeHolder.TimeElement == (watcher.TimeHolder.TimeElement - 1) && w.Video.Name == watcher.Video.Name
                                                         && w.Subscriber.ListType == Subscriber.Subscriber.ListTypeEnum.White).Sum(w => w.Video.Time);
            }

            watcher.AverageWatchTime = totalMinutes != 0 && totalViews != 0 ? totalMinutes / totalViews : 0;
            watcher.GuessedWatchTime = totalMinutes != 0 && totalViews != 0 && totalViews - whiteListWatchersForTime > 0 ? 
                                      (totalMinutes - whiteListWatchTime) / (totalViews - whiteListWatchersForTime) : 0;
            watcher.MaxWatchTime = totalMinutes > watcher.Video.Time ? watcher.Video.Time : totalMinutes;
        }
    }
}
