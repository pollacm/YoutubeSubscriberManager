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

        public TimeHolder GetTimeHolderFromString(string timeString)
        {
            if (timeString.Contains(" minute"))
            {
                return TimeHolders.Single(t => t.TimeElement == 0);
            }

            if (timeString.Contains(" hour"))
            {
                var parsedTime = int.Parse(timeString.Split(' ')[0].Trim());
                return TimeHolders.Single(t => t.TimeElement == parsedTime);
            }

            return null;
        }

        public TimeHolder GetNextTimeHolderFromString(string timeString)
        {
            var timeHolder = new TimeHolder();

            if (timeString.Contains(" minute"))
            {
                timeHolder = TimeHolders.Single(t => t.TimeElement == 1);
            }

            if (timeString.Contains(" hour"))
            {
                var parsedTime = int.Parse(timeString.Split(' ')[0].Trim());
                if (parsedTime < 23)
                {
                    timeHolder = TimeHolders.Single(t => t.TimeElement == parsedTime + 1);
                }
            }

            return timeHolder;
        }

        public void CalculateTimeInfo(Watcher watcher, List<Watcher> watchers)
        {
            //var totalMinutes = 0m;
            var watchForFirstTime = 0m;
            var watchForSecondTime = 0m;
            //var totalViews = 0;
            var viewsForFirstTime = 0;
            var viewsForSecondTime = 0;
            //var whiteListWatchersForTime = 0;
            var firstWhiteListWatchersForTime = 0;
            var secondWhiteListWatchersForTime = 0;

            //var whiteListWatchTime = 0m;
            var firstWhiteListWatchTime = 0m;
            var secondWhiteListWatchTime = 0m;

            watchForFirstTime += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement).WatchMinutes;
            //totalMinutes += watchForFirstTime;
            viewsForFirstTime += TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement).ViewCount;
            //totalViews += viewsForFirstTime;

            watcher.WhiteWatches = 0;
            firstWhiteListWatchersForTime = TimeHolders.Count(t => t.TimeElement == watcher.TimeHolder.TimeElement && watcher.ListType == Subscriber.Subscriber.ListTypeEnum.White);
            watcher.WhiteWatches += firstWhiteListWatchersForTime;

            if (watchers.Any(w => w.TimeHolder != null && w.TimeHolder.TimeElement == watcher.TimeHolder.TimeElement && w.Video.Name == watcher.Video.Name && w.ListType == Subscriber.Subscriber.ListTypeEnum.White))
            {
                firstWhiteListWatchTime = watchers.Where(w => w.TimeHolder != null && w.TimeHolder.TimeElement == watcher.TimeHolder.TimeElement && w.ListType == Subscriber.Subscriber.ListTypeEnum.White).Sum(w => w.Video.Time / 2);
            }

            if (watcher.TimeHolder.TimeElement < 23)
            {
                watchForSecondTime = TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement + 1).WatchMinutes;
                //totalMinutes += watchForSecondTime;
                viewsForSecondTime = TimeHolders.Single(t => t.TimeElement == watcher.TimeHolder.TimeElement + 1).ViewCount;
                //totalViews += viewsForSecondTime;

                secondWhiteListWatchersForTime += TimeHolders.Count(t => t.TimeElement == watcher.TimeHolder.TimeElement + 1 && watcher.ListType == Subscriber.Subscriber.ListTypeEnum.White);
                watcher.WhiteWatches += secondWhiteListWatchersForTime;
                if (watchers.Any(w => w.TimeHolder != null && w.TimeHolder.TimeElement == watcher.TimeHolder.TimeElement + 1 && w.Video.Name == watcher.Video.Name && w.ListType == Subscriber.Subscriber.ListTypeEnum.White))
                {
                    secondWhiteListWatchTime += watchers.Where(w => w.TimeHolder != null && w.TimeHolder.TimeElement == watcher.TimeHolder.TimeElement + 1 && w.ListType == Subscriber.Subscriber.ListTypeEnum.White).Sum(w => w.Video.Time / 2);
                }
            }
            
            //if (watcher.TimeHolder.TimeElement > 0)
            //{
            //    whiteListWatchersForTime += TimeHolders.Count(t => t.TimeElement == watcher.TimeHolder.TimeElement + 1 && watcher.ListType == Subscriber.Subscriber.ListTypeEnum.White);

            //    whiteListWatchTime += watchers.Where(w => w.TimeHolder != null && w.TimeHolder.TimeElement == (watcher.TimeHolder.TimeElement - 1) && w.Video.Name == watcher.Video.Name
            //                                             && w.Subscriber != null && w.ListType == Subscriber.Subscriber.ListTypeEnum.White).Sum(w => w.Video.Time);
            //}

            var firstAverage = 0m;
            if (viewsForFirstTime > 0)
            {
                firstAverage = watchForFirstTime / viewsForFirstTime;
            }
            var secondAverage = 0m;
            if (viewsForSecondTime > 0)
            {
                secondAverage = watchForSecondTime / viewsForSecondTime;
            }

            watcher.AverageWatchTime = firstAverage + secondAverage > 0 ? (firstAverage + secondAverage) / 2 : 0;

            if (watchForFirstTime > watcher.Video.Time || watchForSecondTime > watcher.Video.Time)
            {
                watcher.MaxWatchTime = watcher.Video.Time;
            }
            else
            {
                watcher.MaxWatchTime = watchForFirstTime > watchForSecondTime ? watchForFirstTime : watchForSecondTime;
            }
            
            if (watcher.ListType == Subscriber.Subscriber.ListTypeEnum.White)
            {
                watcher.GuessedWatchTime = watcher.MaxWatchTime;
            }
            else
            {
                var firstWatchGuess = firstWhiteListWatchTime != 0 && firstWhiteListWatchersForTime != 0 && watchForFirstTime - firstWhiteListWatchersForTime > 0 ? (watchForFirstTime - firstWhiteListWatchTime) / (viewsForFirstTime - firstWhiteListWatchersForTime) : 0;
                var secondWatchGuess = secondWhiteListWatchTime != 0 && secondWhiteListWatchersForTime != 0 && watchForSecondTime - secondWhiteListWatchersForTime > 0 ? (watchForSecondTime - secondWhiteListWatchTime) / (viewsForSecondTime - secondWhiteListWatchersForTime) : 0;
                watcher.GuessedWatchTime = firstWatchGuess > secondWatchGuess ? firstWatchGuess : secondWatchGuess;
            }
        }
    }
}
