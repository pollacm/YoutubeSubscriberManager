﻿using System;
using System.IO;

namespace TubeBuddyScraper.Slack
{
    public class AccessToken
    {
        private const string FilePath = @"E:\Dropbox\Private\Fantasy\TRL\SlackWebHook.txt";
        public string GetAccessTokenFromFile()
        {
            var accessToken = string.Empty;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    // Read the stream to a string, and write the string to the console.
                    accessToken = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return accessToken;
        }
    }
}