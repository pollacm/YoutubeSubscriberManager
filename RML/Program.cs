using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TubeBuddyScraper;

namespace YoutubeSubscriberManager
{
    /*
     --https://www.youtube.com/channel/UCsmcy2P_3tvuCX53do_w6uw //too many views
     --https://www.youtube.com/channel/UCtdowDqHNtzfJvN7Vw33dHw //too many views
     --https://www.youtube.com/channel/UCastU-s3Mcx4Qa67iIQOIpg //cat


    full
    https://www.youtube.com/channel/UCwoQf3bs7JVTMJe73YMnmVg/featured
    https://www.youtube.com/channel/UCwXDNm__lLFZuRoyAHhTH3w/videos
    https://www.youtube.com/channel/UCJHS5Gi4EVuRg7ezLNlnVFw/videos
    https://www.youtube.com/channel/UC93uR6jk-TUj5yG8HVrRKcQ/videos

    ind group
    https://www.youtube.com/channel/UCMGuFQWO1h5nyGWyPbx25Uw/videos
    https://www.youtube.com/channel/UC7y7wYXCwRIqyFSOtz_DcuQ
    https://www.youtube.com/channel/UC42i6AVmftaGjWxPuiLvAkw
    https://www.youtube.com/channel/UC9NYbpglaiw4dKfNC4rCk9w
    https://www.youtube.com/channel/UCgAH3vaJUi41HuXdI-70OAw/videos
    https://www.youtube.com/channel/UCLnwmL2OVsJF-eG-BmVoVkg
    https://www.youtube.com/channel/UCQpCVGExYhUYDCRZoCpmqGA
    https://www.youtube.com/channel/UC2luVo3LfuQaYw1a2ctg79Q/videos

    https://www.youtube.com/channel/UCjF192kLLaPuXX5ODXjbmkQ
    https://www.youtube.com/channel/UCm_Fx1ZgL4AXbcBBpnP6FBA
    https://www.youtube.com/channel/UCig_crSpZFaeW8NSkijSbGg
    https://www.youtube.com/channel/UCb1G-EvDpkER6Edq4Cd8ktw/videos
    https://www.youtube.com/channel/UCVM_zJM3SIwpkbp34oK89BQ/videos
    https://www.youtube.com/channel/UCcaIbsvVEVitU4e4BxtOXpQ/videos
    https://www.youtube.com/channel/UCcaIbsvVEVitU4e4BxtOXpQ/videos
    https://www.youtube.com/channel/UCXM7C1JQtmUoN6tiZL_S-kg/videos

    */
    internal class Program
    {
        //less than a minute watches
        static List<string> blacklist = new List<string>
        {
            // = 30 second watch
            //* = need to watch a vid and see if they respond
            "TOMXGAMERS".ToLower(), //
            "KHADIJA PRODUCTIONS Tutorials".ToLower(),//
            "KHADIJA PRODUCTIONS Gameplay".ToLower(),//
            "I Am Lif3ofdreads".ToLower(),//
            "Xander Zone".ToLower(),//
            "Criminal 2020".ToLower(),
            "GameHunter".ToLower(),
            "Aryan Satya".ToLower(),
            "Dude Gamer".ToLower(),
            "Teele Loves Jobu".ToLower(),
            "PS5 Gamer".ToLower(),
            "CHILLSCISSORS".ToLower(),//
            "Timothy B. Salinas".ToLower(),
            "Zio bugio".ToLower(),
            "Mister Omega".ToLower(),
            "JeremiahGR".ToLower(),
            "The Nintendo Network".ToLower(),
            "SurgeTV".ToLower(),//*
            "CoryJT".ToLower(),//
            "Dan Hundred Bankss Entertainment".ToLower(),
            "Lady Judged".ToLower(),
            "Noizey Plays".ToLower(),
            "Zerasino Reboot".ToLower(),//*
            "Optic Ninja".ToLower(),
            "CSN_CityGirl".ToLower(),
            "Tat Test Dummies".ToLower(),
            "I'm Norman!".ToLower(),
            "Predator Zone Crazy".ToLower(),
            "Orjane Cristobal".ToLower(),
            "SHOWTIME ULTRA".ToLower(),
            "Marshallaw".ToLower(),
            "NickMortuus".ToLower(),
            "Publicgame".ToLower(),
            "gallegos s.".ToLower(),
            "Saurabh Sawariya Official".ToLower(),
            "NK RAJASTHANI VIDEO".ToLower(),
            "YouNot_Game".ToLower(),
            "tbs-prod".ToLower(),
            "Ethan".ToLower(),
            "BPat Beats".ToLower(),
            "BİLGİ VE EĞLENCE DÜNYASI".ToLower(),
            "Timothy B. Salinas".ToLower(),
            "Afro Black".ToLower(),
            "NCshredder Gaming".ToLower(),
            "Lưu Quang Minh".ToLower(),
            "XScaleton Gaming".ToLower(),
            "Game Boys".ToLower(),
            "嘎嘎巫啦啦".ToLower(),
            "的的Vinky".ToLower(),
            "kids tv".ToLower(),
            "Machina Hattab".ToLower(),
            "Gökhan Berber".ToLower(),//waiting
            "Yoga Arief".ToLower(),
            "Faith Fridayigbinosun".ToLower(),//waiting full other
            "Coco Chimmy".ToLower(),
            "om ryan".ToLower(),
            "HiTechKing".ToLower(),
            "Prenses Melisam".ToLower(),
            "Poem By Asha".ToLower(),//waiting full other
            "ESCUELA السكويلة".ToLower(),
            "Shobana kitchen".ToLower(),
            "Nurlana Нурлана".ToLower(),
            "Tasty food N talks".ToLower(),
            "Lavz art".ToLower(),
            "The gOod One".ToLower(),
            "DS. Kim".ToLower(),
            "moonlight kidz games".ToLower(),
            "VIAJERO ANDRÉS".ToLower(),
            "理科女人:紅葉的天空".ToLower(),
            "Lisa Le".ToLower(),
            "NEW GAMER 13".ToLower(),
            "NGAIZ TV".ToLower(),
            "ALI. BEK. TV".ToLower(),
            "Ishu Ki Rasoi".ToLower(),
            "Usha misra ka Hamara kitchen & Blog".ToLower(),
            "Brods Gaming".ToLower(),
            "LEXSEB GAMING".ToLower(),
            "Globetrot with Neel Ashar".ToLower(),//lied on FV; .4/8
            "BANGLA GAMING TRICK".ToLower(),
            "Dr.JoshDaRealGamer".ToLower(),
            "ApnaAvi".ToLower(),
            "kids Diana show 2".ToLower(),
            "NCshredder 【YT".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
            "Orjane".ToLower(),
        };

        private static List<string> yellowlist = new List<string>
        {
            "Damla Abulfazli".ToLower(),
            "Abdul's Media".ToLower(),//2/2
            "viajes lauchas".ToLower(),
            "UnspecGamer".ToLower(),
            "Big Keys".ToLower(),
            "Birgül'ün Yöresel Lezzetleri".ToLower(),
            "KOBOY KNC SUKABUMI".ToLower(), //3.6/32
            "LOOT JAC / AHMAD PAISAL".ToLower(),
            "NnT Daily Game".ToLower(),
            "Aras'ın Dünyası".ToLower(),
            "Kidz Coloring Joy".ToLower(),
            "Ecen's Channel".ToLower(),//8/8 between 2
            "Thor Reavenger".ToLower(),//8/8 between 2
            "fia sonarean".ToLower(),//possible full between mult
            "Diah 082134778877wa".ToLower(), //4.4/8 split
            "Correteando la Cheve".ToLower(),//4.4/8 split
            "Gökhan Berber".ToLower(), //think short watch. Need to confirm
            "Billy B".ToLower(), //waiting
            "Terrill".ToLower(), //waiting
            "Shivani Devi s".ToLower(), //waiting
            "Naomi's Filipino Kitchen and a New Life in France".ToLower(),//waiting
            "GAMER FAV".ToLower(), //waiting
            "badboy3420".ToLower(), //waiting
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),

        };

        //"Game Boys".ToLower(), //8/32
        static List<string> whitelist = new List<string>
        {
            "milada มิลา".ToLower(), //FW
            "Runningwolf World of TanksAam".ToLower(),//FW
            "spanked bob".ToLower(),//FW
            "DHV VLOG".ToLower(),//FW
            "Food Idea by Tuhin".ToLower(), //4.5/32
            "MT GAMING5".ToLower(), //15/32, 7/15
            "SK Gowrob".ToLower(),
            "BROWEN".ToLower(), //10/32
            "Ranscan KNRT".ToLower(),//10/10
            "Salus Vindex".ToLower(),//4.5/10, 1.75k subs
            "Keyser Reveal".ToLower(),//3.5/10, 11k subs
            "HAPPY TIME".ToLower(),//7.5/32
            "Hot Fried Griyo and Peeklees".ToLower(), //KOULWAH 2
            "CREEPY KOULWAH".ToLower(),
            "DEGRA".ToLower(),
            "Improved Gaming".ToLower(),//9.5/9.5
            "Djawek Game Company".ToLower(), //4.5/8
            "Miss Gam Survives".ToLower(), //9.5/9.5
            "No_Talent_Guy".ToLower(),
            "Nfamiz Jay".ToLower(),
            "Select Start Save".ToLower(),
            "GamingSiege Ghost".ToLower(),
            "Gaming University Conference".ToLower(),
            "Silent Scoperzzz".ToLower(),
            "Work Commute".ToLower(),
            "Retro Toys and Cartoons".ToLower(),//2.8/2.8
            "Terese Benge".ToLower(),//9.5/9.5
            "ŞAHİN TAKIMI".ToLower(),
            "Our Kitchen".ToLower(),//6.7/8
            "GAME WFK".ToLower(),//8/8
            "Zhang萌萌的咪儿".ToLower(),//4/8
            "Phynoxtv".ToLower(),
            "K2Z U".ToLower(), //4.6/10
            "Friendship Education".ToLower(),
            "F2PlayGames".ToLower(),
            "Гильдия Геймеров".ToLower(),//6/8 then .22 so I thought, YT slow
            "Febina's fabulous life".ToLower(),
            "Supportive Gamers Community".ToLower(), //2.7/2.7; 10/10
            "kenken TV Quang Thanh".ToLower(),//4.7/8
            "fadaa zahira".ToLower(),//7.69/15.. then 2/14, 1.2/10, 1.5/10, 12.9/12.9
            "Blue British shorthair cat".ToLower(), //32/32
            "FTR Motivated Gaming".ToLower(),
            "Bits of Real Panther".ToLower(),
            "Arlene Arcebal CHANNEL".ToLower(),//7/32
            "Salus".ToLower(),
            "Гильдия Геймеров".ToLower(),
            "F2PlayGames".ToLower(),//5/16
            "Mihaela Claudia Puscas".ToLower(), //24/32
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),

        };
        private static void Main(string[] args)
        {

            var appStartTime = DateTime.Now.Date;
            
            var acceptableWatchTimes = new List<string>
            {
                "minutes",
                "hours",
                "days",
                "minute",
                "hour",
                "day",
                "1 week",
                "2 weeks",
                "3 weeks"
            };
            var rowsToIncrementOnSubPage = 4;
            var rowsToIncrementComments = 8;

            //String pathToProfile = @"C:\Users\cxp6696\ChromeProfiles\User Data";
            String pathToProfile = @"C:\Users\Owner\ChromeProfiles\User Data";
            //string pathToChromedriver = @"C:\Users\cxp6696\source\repos\TubeBuddyScraper\packages\Selenium.WebDriver.ChromeDriver.77.0.3865.4000\driver\win32\chromedriver.exe";
            string pathToChromedriver = @"C:\Users\Owner\source\repos\TubeBuddyScraper\packages\Selenium.WebDriver.ChromeDriver.77.0.3865.4000\driver\win32\chromedriver.exe";
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("user-data-dir=" + pathToProfile);
            Environment.SetEnvironmentVariable("webdriver.chrome.driver", pathToChromedriver);

            var subscribers = new List<Subscriber.Subscriber>();
            ChromeDriver driver = new ChromeDriver(options);
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            Thread.Sleep(3000);

            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            var videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber == null)
                {
                    subscriber = new Subscriber.Subscriber();
                    subscriber.Name = subscriberName;
                    var watched = video.FindElements(By.XPath("./div[1]/ytd-thumbnail[1]/a[1]/div[1]/ytd-thumbnail-overlay-resume-playback-renderer")).Any();
                    if (watched)
                        subscriber.Watches++;

                    subscriber.Videos = 1;
                    if (video.FindElements(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Any())
                    {
                        var currentViewCount = video.FindElement(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Text.Split(new string[] { " view" }, StringSplitOptions.None)[0].Split(new string[] { " watching" }, StringSplitOptions.None)[0];
                        subscriber.ViewCounts.Add(GetIntegerViews(currentViewCount));
                        subscriber.AverageViewCount = subscriber.ViewCounts.Sum(Convert.ToInt32) == 0 ? 0 : subscriber.ViewCounts.Sum(Convert.ToInt32) / subscriber.Videos;
                    }
                    
                    subscribers.Add(subscriber);
                }
                else
                {
                    var watched = video.FindElements(By.XPath("./div[1]/ytd-thumbnail[1]/a[1]/div[1]/ytd-thumbnail-overlay-resume-playback-renderer")).Any();
                    if (watched)
                        subscriber.Watches++;

                    subscriber.Videos++;
                    if (video.FindElements(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Any())
                    {
                        var currentViewCount = video.FindElement(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Text.Split(new string[] { " view" }, StringSplitOptions.None)[0].Split(new string[] { " watching" }, StringSplitOptions.None)[0];
                        subscriber.ViewCounts.Add(GetIntegerViews(currentViewCount));
                        subscriber.AverageViewCount = subscriber.ViewCounts.Sum(Convert.ToInt32) == 0 ? 0 : subscriber.ViewCounts.Sum(Convert.ToInt32) / subscriber.Videos;
                    }
                }
            }

            driver.NavigateToUrl("https:/studio.youtube.com/channel/UCUDTfpBksfE4KqLYjG9u00g/comments/inbox?utm_campaign=upgrade&utm_medium=redirect&utm_source=%2Fcomments&filter=%5B%5D");
            SelectElement selectBox = new SelectElement(driver.FindElementByXPath("//ytcp-comments-filter[@id='filter-bar']//select[@class='tb-comment-filter-studio-select-auto-load tb-comment-filter-studio-select']"));
            selectBox.SelectByText("100 results");
            var button = driver.FindElementByXPath("//ytcp-comments-filter[@id='filter-bar']//button[@class='tb-btn tb-btn-grey tb-comment-filter-studio-go'][contains(text(),'Go')]");
            button.Click();
            Thread.Sleep(10000);

            for (int i = 0; i < rowsToIncrementComments; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            var comments = driver.FindElementsByXPath("//body//ytcp-comment-thread");
            //foreach (var comment in comments)
            //{
            //    if (comment.FindElements(By.XPath("./ytcp-comment[@id='comment']//yt-formatted-string[@class='author-text style-scope ytcp-comment']")).Count == 1)
            //    {
            //        var commenterName = comment.FindElement(By.XPath("./ytcp-comment[@id='comment']//yt-formatted-string[@class='author-text style-scope ytcp-comment']")).Text;
            //        var commenter = subscribers.SingleOrDefault(s => s.Name == commenterName);
            //        if (commenter != null)
            //        {
            //            var watchTime = comment.FindElement(By.XPath("./ytcp-comment[1]/div[1]/div[1]/div[2]/div[1]/yt-formatted-string[1]")).Text;
            //            foreach (var acceptableWatchTime in acceptableWatchTimes)
            //            {
            //                if (watchTime.Contains(acceptableWatchTime))
            //                {
            //                    commenter.CommentedLately = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}

            //higher views
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            var currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (subscriber.AverageViewCount < 75)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //white/yellow list/over 50 views
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if ((!whitelist.Contains(subscriberName.ToLower()) && !yellowlist.Contains(subscriberName.ToLower())) || subscriber.AverageViewCount < 50)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //white/yellow list
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (!whitelist.Contains(subscriberName.ToLower()) && !yellowlist.Contains(subscriberName.ToLower()))
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            

            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            //Current supporters
            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (blacklist.Contains(subscriberName.ToLower()) || (!subscriber.CommentedLately || subscriber.Watches > 2))
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //white list
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (!whitelist.Contains(subscriberName.ToLower()))
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //blacklist or haven't returned watch
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (blacklist.Contains(subscriberName.ToLower()) || subscriber.Watches > 0)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //non-supporters
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (subscriber.CommentedLately)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            //blacklist
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (!blacklist.Contains(subscriberName.ToLower()))
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        currentElement++;
                    }
                }
            }

            var x = 1;
        }

        private static void RemoveElement(ChromeDriver driver, int index)
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].remove();");
        }

        private static void StampElement(ChromeDriver driver, string subscriberName, int index)
        {
            var jse = (IJavaScriptExecutor)driver;

            if(blacklist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid red\";");
            if (whitelist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid green\";");
            if (yellowlist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid yellow\";");
        }

        private static void ScrollToBottom(ChromeDriver driver)
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, 100000);");
        }

        private static double GetIntegerViews(string views)
        {
            if (views == "No" || views.Contains("Premiere") || views.Contains("Scheduled") || views.Contains("%"))
                return 0;
            var integerViews = double.Parse(views.Split(new string[] {"K"}, StringSplitOptions.None)[0].Split(new string[] { "M" }, StringSplitOptions.None)[0]);
            if (views.Contains("K"))
            {
                integerViews *= 1000;
            }
            if (views.Contains("M"))
            {
                integerViews *= 1000000;
            }

            return integerViews;
        }
        
    }
}
