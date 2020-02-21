using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YoutubeSubscriberManager.Comment
{
    public class CommentRepo
    {
        private readonly string jsonFile = "../../Comments.txt";
        public void RefreshComments(List<Comment> incomingComments)
        {
            var comments = GetComments();
            foreach (var incomingComment in incomingComments)
            {
                var matchingComment = comments.FirstOrDefault(c => c.MessengerName == incomingComment.MessengerName &&
                                                                   c.Message == incomingComment.Message &&
                                                                   c.VideoName == incomingComment.VideoName);
                if (matchingComment != null/* && matchingComment.AdditionalMessengersForTimeSlot == string.Empty*/)
                {
                    matchingComment.AdditionalMessengersForTimeSlot = incomingComment.AdditionalMessengersForTimeSlot;
                }

                if (matchingComment == null)
                {
                    comments.Add(incomingComment);
                }
            }
            comments.RemoveAll(c => c.StartingTimeSlot < DateTime.Now.AddDays(-90));
            comments = comments.OrderByDescending(c => c.StartingTimeSlot).ThenByDescending(c => c.Time).ToList();

            var json = JsonConvert.SerializeObject(comments);
            using (StreamWriter file = new StreamWriter(jsonFile))
            {
                file.Write(json);
            }
        }
        public List<Comment> GetComments()
        {   
            using (StreamReader file = new StreamReader(jsonFile))
            {
                return JsonConvert.DeserializeObject<List<Comment>>(file.ReadToEnd());
            }
        }

        public string GetLastComments(List<Comment> comments, string commenterName, int numberOfComments)
        {
            return string.Join(" ||| ", comments.Where(c => c.MessengerName == commenterName).Take(numberOfComments));
        }

        public List<Comment> GetEligableVideosUpdateOfMessengers()
        {
            return GetComments().Where(c => c.StartingTimeSlot > DateTime.Now.AddHours(-5)).ToList();
        }

        public void SetMatchingCommenterNamesForTimeSlot(List<Comment> comments, Comment comment)
        {
            //var comment = GetLastCommentToSetTimeSlots(comments, commenterName);
            var commentList = string.Empty;

            if (comment != null)
            {

                var commentsInSameTimeSlot = comments.Where(c => c.StartingTimeSlot == comment.StartingTimeSlot && c.EndingTimeSlot == comment.EndingTimeSlot &&
                                                                 c.MessengerName != comment.MessengerName && 
                                                                 c.AdditionalMessengersForTimeSlot != comment.AdditionalMessengersForTimeSlot);
                
                foreach (var commentInSameTimeSlot in commentsInSameTimeSlot)
                {
                    commentList += $"{commentInSameTimeSlot.MessengerName} ({commentInSameTimeSlot.ListType.ToString()}); ";
                }

                if(string.IsNullOrEmpty(comment.AdditionalMessengersForTimeSlot))
                    comment.AdditionalMessengersForTimeSlot = commentList;
            }
        }

        //public Comment GetLastCommentToSetTimeSlots(List<Comment> comments, string commenterName)
        //{
        //    return comments.FirstOrDefault(c => c.MessengerName == commenterName && c.AdditionalMessengersForTimeSlot == string.Empty);
        //}
    }
}
