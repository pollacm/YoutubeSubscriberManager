using System;

namespace YoutubeSubscriberManager.Comment
{
    public class Comment
    {
        public string MessengerName { get; set; }
        public string VideoName { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public DateTime StartingTimeSlot { get; set; }
        public DateTime EndingTimeSlot { get; set; }
        public string AdditionalMessengersForTimeSlot { get; set; }
        public ListTypeEnum ListType { get; set; }

        public enum ListTypeEnum
        {
            White,
            Black,
            Yellow,
            Orange,
            Pink,
            Other
        }
    }
}
