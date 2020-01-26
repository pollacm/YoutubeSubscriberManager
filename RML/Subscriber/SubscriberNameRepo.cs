using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeSubscriberManager.Subscriber
{
    public class SubscriberNameRepo
    {
        private readonly string jsonFile = "../../SubscriberName.txt";
        public void RefreshSubscribers(List<Subscriber> subscribers)
        {
            var subscriberNames = GetSubscribers() + "," + string.Join(",", subscribers.Select(s => s.Name));

            using (StreamWriter file = new StreamWriter(jsonFile))
            {
                file.Write(subscriberNames);
            }
        }
        public string GetSubscribers()
        {   
            using (StreamReader file = new StreamReader(jsonFile))
            {
                return file.ReadToEnd();
            }
        }
    }
}
