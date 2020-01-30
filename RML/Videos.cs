using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSubscriberManager
{
    public static class Videos
    {
        public static List<Video> MyVideos = new List<Video>
        {
            new Video{Name = "HE DIDN'T MAKE IT | Oddworld: New 'n' Tasty! Walkthrough - Part 1", Time = 22.51m},
            new Video{Name = "WE GOTTA DO BETTER | Resident Evil 2 One Shot Demo", Time = 21.23m},
            new Video{Name = "WE GOTTA MAKE IT COUNT CLAIRE!!! | Resident Evil 2 Remake - Episode 1", Time = 23.70m},
            new Video{Name = "ToeJam & Earl: Back in the Groove! Gameplay | A POEM FOR LATISHA", Time = 18.60m},
            new Video{Name = "Matanga (Indie Horror Game) - HIT HIM WITH THE BRICK", Time = 12.96m},
            new Video{Name = "THE GLASS STAIRCASE (Puppet Combo) - TAKE THE PILLS HELEN [Part 1]", Time = 12.91m},
            new Video{Name = "MAKE SURE IT'S CLOSED [Horror Gameplay] | ONE, TWO, HE'S COMING FOR YOU (Ending)", Time = 2.81m},
            new Video{Name = "OUTSIDE THE HOME (GAME) - Never Open The Door [ENDING]", Time = 15.36m},
            new Video{Name = "FRIDAY THE 13TH THE GAME Story Mode - PRETTY BLUE EYES - Single Player Campaign [PART 1]", Time = 10.53m},
            new Video{Name = "INSULATION HORROR GAME [ENDING] - Who's Baby Is This???", Time = 32.41m},
            new Video{Name = "START SURVEY? GAME [ENDING] - He's Watching You - Be Afraid", Time = 8.65m},
            new Video{Name = "CLENCHED THE GAME - Clenching Them Cheeks", Time = 7.13m},
            new Video{Name = "TV NIGHT GAME - We Shouldnt Be Here", Time = 9.00m},
            new Video{Name = "PARALYZIS HORROR GAME - Somebody Wake Me Up!", Time = 7.98m},
            new Video{Name = "SANTA IS A CYBORG - Slay Bells | Gameplay [ENDING]", Time = 11.50m},
        };
    }

    public class Video
    {
        public string Name { get; set; }
        public decimal Time { get; set; }
    }
}
