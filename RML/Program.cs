using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TubeBuddyScraper;
using YoutubeSubscriberManager.Subscriber;

namespace YoutubeSubscriberManager
{
    //delete list - Dec 2019 - Jan 29
    /*
        Khadija Productions Gameplay,
        Project Gamer Corp,
        Total Mage,
        DMB Does Gaming,
        Games And Fun,
        嘎嘎巫啦啦,
        Aras'ın Dünyası,
        Kidz Coloring Joy,
        Kids Diana Play,
        GameHunter,
        • HİLECİ GENÇ •,
        NGAIZ TV,
        Billy B,
        Clayman G Info,
        Prenses Melisam,
        J Art,
        sha niz channel,
        Gamer Musabbir,
        Random Generation Gaming,
        Odhora Media,
        Mahira Urdu Story,
        Thor Reavenger,
        MEHRİBAN İBRAHİMLİ,
        Recipes By AV,
        Jiban Teknikal,
        GeumSung entertainment 가수금성TV,
        rai rai bvlog,
        Arlene Arcebal CHANNEL,

        --VB Fitness
        --CoryJT,
        --Lunartic Wolf,
        --kids Diana show 2,
        --Kids Damla Show,
        --Retro Toys and Cartoons,
        --Miss Gam Survives,
        --Brods Gaming,
        --NishaPandaBEAST,
        --boywiththehat,
        --Gaming University Conference,
     */
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
        static List<TimeHolder> TimeHolders = new List<TimeHolder>
        {
            new TimeHolder{TimeElement = 0, WatchMinutes = 0m, ViewCount = 0},//7PM
            new TimeHolder{TimeElement = 1, WatchMinutes = 0m, ViewCount = 0},
            new TimeHolder{TimeElement = 2, WatchMinutes = 0m, ViewCount = 0},
            new TimeHolder{TimeElement = 3, WatchMinutes = 0m, ViewCount = 0},
            new TimeHolder{TimeElement = 4, WatchMinutes = 0m, ViewCount = 0},
            new TimeHolder{TimeElement = 5, WatchMinutes = .11m, ViewCount = 0},
            new TimeHolder{TimeElement = 6, WatchMinutes =  14.15m, ViewCount = 1},
            new TimeHolder{TimeElement = 7, WatchMinutes = 1.85m, ViewCount = 4},
            new TimeHolder{TimeElement = 8, WatchMinutes = .68m, ViewCount = 1},
            new TimeHolder{TimeElement = 9, WatchMinutes = .16m, ViewCount = 1},
            new TimeHolder{TimeElement = 10, WatchMinutes = 0.59m, ViewCount = 4},
            new TimeHolder{TimeElement = 11, WatchMinutes = 19.43m, ViewCount = 4},
            new TimeHolder{TimeElement = 12, WatchMinutes = 4.51m, ViewCount = 1},
            new TimeHolder{TimeElement = 13, WatchMinutes = 32.98m, ViewCount = 3},
            new TimeHolder{TimeElement = 14, WatchMinutes = 34.54m, ViewCount = 1},
            new TimeHolder{TimeElement = 15, WatchMinutes = 23.5m, ViewCount = 2},
            new TimeHolder{TimeElement = 16, WatchMinutes = 7.41m, ViewCount = 3},
            new TimeHolder{TimeElement = 17, WatchMinutes = 6.27m, ViewCount = 2},
            new TimeHolder{TimeElement = 18, WatchMinutes = 0m, ViewCount = 0},
            new TimeHolder{TimeElement = 19, WatchMinutes = .79m, ViewCount = 2},
            new TimeHolder{TimeElement = 20, WatchMinutes = 2.83m, ViewCount = 1},
            new TimeHolder{TimeElement = 21, WatchMinutes = 0.12m, ViewCount = 1},
            new TimeHolder{TimeElement = 22, WatchMinutes = 0.91m, ViewCount = 2},
            new TimeHolder{TimeElement = 23, WatchMinutes = 10.78m, ViewCount = 3},
        };
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
            "Gökhan Berber".ToLower(),//short watch
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
            "Yoga Arief".ToLower(), //was always red, now cant tell
            "Jawdan Toys".ToLower(), //cant tell but pretty sure its red
            "depoze komedi".ToLower(),
            "Ross Roams".ToLower(),
            "العقاب تي في AL OKKAB TV".ToLower(),
            "Família da estrada".ToLower(),
            "MAESTROGHOST".ToLower(),
            "MoveMekMiPaZz".ToLower(),
            "Ock gaming".ToLower(),
            "Kevin Breemans".ToLower(),
            "TEKJA GAMEPLAYS".ToLower(),
            "Kitschiko".ToLower(),
            "97Jonnyboy".ToLower(),
            "GomsoonTV 곰순TV".ToLower(),
            "依然对你说".ToLower(),
            "Zhiri Abdo".ToLower(),
            "Viajero Andres".ToLower(),
            "톡스-마을ZOOM".ToLower(),
            "CẢNH ĐẸP QUÊ TÔI MIỀN TÂY".ToLower(),
            "ちづ美チャンネル".ToLower(),
            "Shobana kitchen".ToLower(),
            "Matamu menikmati".ToLower(),
            "Canal Amor a Poesia Oficial".ToLower(),
            "Rafał Szymski".ToLower(),//lied on full watch. .39/12
            "ESSEN TV".ToLower(),
            "DS. Kim".ToLower(),
            "Sanchez YT".ToLower(),
            "BOING".ToLower(),
            "LoveSurfBunny".ToLower(),
            "choub khem".ToLower(),
            "Thomas Scott".ToLower(),
            "Lorna Harpham".ToLower(),
            "Princess Chenny".ToLower(),
            "Tasleem Vlogs".ToLower(),
            "Rupam Datta".ToLower(),
            "다락귀신[ V ]".ToLower(),
            "Village Food Desi".ToLower(),
            "Blue British shorthair cat".ToLower(), //32/32; under 1".ToLower(),
            "英國短毛貓".ToLower(),
            "HRV-Strijelac".ToLower(),
            "Xkprogamer 123".ToLower(),
            "Lunartic Wolf".ToLower(),
            "VB Fitness".ToLower(),
            "Dadang,Lena channel".ToLower(),
            "PSHT Karawang Channel".ToLower(),
            "Kev Gaming XP".ToLower(),
            "EN gaming channel".ToLower(),
            "Bloxy Village".ToLower(),
            "ロバ次郎チャンネル".ToLower(),
            "Thyber Gaming".ToLower(),
            "Vlog Kita".ToLower(),
            "Generasi hebat".ToLower(),
            "다 빛나사랑TV".ToLower(),
            "Bonjour Toujour".ToLower(),//not sure.. grouped with other watches
            "Maktan Gaming".ToLower(),
            "영프로cook".ToLower(),
            "Travel And Cook With Ritu’s Lifestyle".ToLower(),
            "TONYMAX HD".ToLower(),
            "Ng Khâm Official".ToLower(),
            "أ-40- Beats".ToLower(),
            "Paulo 74 Rio".ToLower(),
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
            "viajes lauchas".ToLower(),
            "UnspecGamer".ToLower(),
            "Big Keys".ToLower(),
            "Birgül'ün Yöresel Lezzetleri".ToLower(),
            "KOBOY KNC SUKABUMI".ToLower(), //3.6/32
            "LOOT JAC / AHMAD PAISAL".ToLower(),
            "NnT Daily Game".ToLower(),
            "Aras'ın Dünyası".ToLower(),
            "Kidz Coloring Joy".ToLower(),
            "Thor Reavenger".ToLower(),//8/8 between 2
            "fia sonarean".ToLower(),//possible full between mult
            "Diah 082134778877wa".ToLower(), //4.4/8 split
            "Correteando la Cheve".ToLower(),//4.4/8 split
            "Gökhan Berber".ToLower(), //think short watch. Need to confirm
            "Billy B".ToLower(), //waiting
            "badboy3420".ToLower(), //waiting
            "GeumSung entertainment".ToLower(),//waiting
            "HABIB ART & CRAFT STUDIO".ToLower(),//think full but cant tell
            "Sudda production සුද්දා".ToLower(),//split but think its red
            "THÙY TV".ToLower(),//split but red I think            
            "OLE LAND".ToLower(),//2 views; dont know which; possible full watch
            "Diverse Canal".ToLower(),//possible full; I don't think so though
            "JackyDalshim Letsplays".ToLower(),//was red then 4.68/9
            "KVZoneHD".ToLower(),//full other waiting
            "Damla".ToLower(),//full other waiting
            "Damla".ToLower(),//full other waiting
            "Damla".ToLower(),//full other waiting
            "English Learners Club".ToLower(),//2 watched 15 minutes (out of 10)
            "Rolling Pony".ToLower(),//2 views across 11 minutes
            "Jafmasterflash 7".ToLower(),
            "WickedGoodEverything".ToLower(),//1 view 2 comments
            "Murder Motion TV".ToLower(), //Pretty sure less than a minute but in same bracket as trip watches
            "Terrill".ToLower(),
            "TheAmazingLSB".ToLower(),
            "Lev Kris Coins".ToLower(),
            "أنا وخويا Ana okhoya".ToLower(),
            "Won't Grow Up".ToLower(),
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
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),
            "Damla".ToLower(),

        };

        //I think full
        static List<string> orangelist = new List<string>
        {
            "Ades - Anak Desa Channel".ToLower(),//pretty sure full
            "Tt TV OKE".ToLower(),//think he is full
            "다락귀신[ V ]".ToLower(),//full other waiting
            "Unplugged Gaming".ToLower(),//full other waiting
            "روائع الفن اليماني - بو نواف و فهد".ToLower(),//full other waiting
            "MultiVerse Studio".ToLower(),//full other waiting
            "Rafał Szymski".ToLower(),//full other waiting
            "Hykli".ToLower(),//full other waiting
            "EA Cubing".ToLower(),//full other waiting
            "RedShadow".ToLower(),//full other waiting
            "Crazy Gamer".ToLower(),//full other waiting
            "Ecen's Channel".ToLower(),//8/8 between 2
            "SurxanGames".ToLower(),//full other waiting
            "شمس الدين DZ".ToLower(),//full other waiting
            "Giant Saint".ToLower(),//full other waiting
            "House Zarn Gaming".ToLower(), //Think full but need to validate
            "أكل بيتي مع ساميه".ToLower(),
            "r3voo".ToLower(),
            "Ron's DigiDiary".ToLower(),//waiting
            "Parker2417".ToLower(),//waiting
            "GetAwesome Gaming".ToLower(),//waiting
            "Ys Gaming Dark".ToLower(),//waiting
            "Pelo Gaming".ToLower(),//waiting
            "Flippettirob".ToLower(),//waiting
            "E_ finish the limit".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "fasdfsdafsadfsad".ToLower(),//waiting
            "NDZ Gaming".ToLower(),
            "KASAKU".ToLower(),
            "معلش M3lsh".ToLower(),
            "Me and My Kitchen".ToLower(),//split full between 2
            "love and chic Diandra".ToLower(),//split full between 2
            "WhiskeyBlue10".ToLower(),
            "7orever".ToLower(),
            "M3athead Gaming".ToLower(),
            "Wheelassassin".ToLower(),
            "PS5 Gamer".ToLower(),
            "fasdfsdafsadfsad".ToLower(),
            "fasdfsdafsadfsad".ToLower(),
            "fasdfsdafsadfsad".ToLower(),
        };

        //2 -5 minute watches
        private static List<string> pinklist = new List<string>
        {
            "Rizky Gaming Tube".ToLower(),//1.93/12
            "Saiful Almalasyi".ToLower(),
            "Vendetta Gaming Plus More".ToLower(),
            "다 빛나사랑TV".ToLower(),
            "Our Kitchen".ToLower(),//2.5/12
            "Lujan Gaming".ToLower(),//3/12
            "prince tv".ToLower(),
            "CrazyPicklersgaming".ToLower(),//was red, then 3.5/11
            "PRADO FAMILY".ToLower(),
            "Fermayil Ahmedov".ToLower(),
            "AJIW NZIDOU LKODDAM".ToLower(),
            "VulpesGaming".ToLower(),//2 watched 15 minutes (out of 10)".ToLower(),
            "MARIA JOSELYN AMBASSADOR OF GOD VLOG Rodriguez".ToLower(),
            "SKY TV".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
            "dfsdfsd".ToLower(),
        };

        //"Game Boys".ToLower(), //8/32
        static List<string> whitelist = new List<string>
        {
            "milada มิลา".ToLower(), //FW
            "Runningwolf World of Tanks".ToLower(),//FW
            "Sir Runningwolf".ToLower(),//FW
            "spanked bob".ToLower(),//FW
            "DHV VLOG".ToLower(),//FW
            "Food Idea by Tuhin".ToLower(), //4.5/32
            "MT GAMING5".ToLower(), //15/32, 7/15
            "SK Gowrob".ToLower(),
            "BROWEN".ToLower(), //10/32
            "Ranscan KNRT".ToLower(),//10/10
            "games KNRTdrinkz".ToLower(),
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
            "FTR Motivated Gaming".ToLower(),
            "Bits of Real Panther".ToLower(),
            "Arlene Arcebal CHANNEL".ToLower(),//7/32
            "Salus".ToLower(),
            "Гильдия Геймеров".ToLower(),
            "F2PlayGames".ToLower(),//5/16
            "Mihaela Claudia Puscas".ToLower(), //24/32
            "walterarce7".ToLower(),
            "FredoriaGaming".ToLower(),//8/8
            "Precocious Turtle".ToLower(),//32/32
            "Silomroad HollandAsianVibe".ToLower(),//waiting
            "MercBenz family".ToLower(),//5/9
            "Naomi's Filipino Kitchen and a New Life in France".ToLower(),
            "pAppA 009 [ Edit for your Pleasure ]".ToLower(),
            "Old Nerd Playing Old PC Games".ToLower(),//full other waiting
            "marvelous sweet411".ToLower(),//full other waiting
            "Daisuke Un Visual Gamer UwU".ToLower(),//full other waiting
            "Game Zone World".ToLower(),//full other waiting
            "BloodyMany".ToLower(),//full other waiting
            "gamingwithaji".ToLower(),//full other waiting
            "The Twins Day".ToLower(),//full other waitingp
            "xspysquirrel Gaming".ToLower(),//full other waiting
            "VDM8".ToLower(), //think we watched 6/8 but not sure
            "FredoriaGaming".ToLower(),//waiting
            "Jeann Williams My Reality Tv".ToLower(),//waiting
            "ShowTimeGaming".ToLower(),//full other waiting
            "Baczek Stream".ToLower(),//full other waiting
            "SPECTREBOSS GAMES".ToLower(),//full other waiting
            "Slendecs".ToLower(),//full other waiting
            "ปันยาอ่อน channel".ToLower(),
            "GAMER FAV".ToLower(),
            "Cristi Nicola".ToLower(),
            "Blue British shorthair cat".ToLower(),
            "ImEdwin_".ToLower(), //pretty sure full
            "G V Balajee".ToLower(),
            "Kashan Hussain".ToLower(),
            "Wonder Videos".ToLower(),
            "Bernald Tibia".ToLower(),//2.8/2.8
            "Shivani Devi s".ToLower(), //4.7/12; think she watched 6/8 not sure
            "Zoom Gameplay".ToLower(),
            "Unsab Man".ToLower(),
            "Cooking with Lisa".ToLower(),//full other waiting            
            "WickedGoodEverything".ToLower(),
            "BigHairyKev".ToLower(),
            "GRIPICA Draw Beauty TV - 드로잉 뷰티".ToLower(),
            "Abdul's Media".ToLower(),//2/2
            "EA TRUL DAK LAK QUE TOI".ToLower(),
            "syamsolver channel".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
            "Salus".ToLower(),
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
            var watchers = new List<Watcher>();

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

            var acceptableWatchTimesForCalculation = new List<string>
            {
                "minute",
                "minutes",
                "hour",
                "hours"
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
            
            //ProcessWatchers(driver, rowsToIncrementComments, acceptableWatchTimesForCalculation, watchers);
            LoadSubscribers(driver, rowsToIncrementOnSubPage, subscribers);
            RunSingleVideoLookups(driver, rowsToIncrementOnSubPage, subscribers);
            MultiVideoLookup(driver, rowsToIncrementOnSubPage, subscribers);

            var x = 1;
        }

        private static void MultiVideoLookup(ChromeDriver driver, int rowsToIncrementOnSubPage, List<Subscriber.Subscriber> subscribers)
        {
//active
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            var videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            var currentElement = 0;
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

            //higher views
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

            var subscriberRepo = new SubscriberNameRepo();
            //subscriberRepo.RefreshSubscribers(subscribers);

            //current watch list
            var currentWatched = subscriberRepo.GetSubscribers();

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    if (currentWatched.ToLower().Contains(subscriberName.ToLower()))
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

            //white/orange list/over 50 views
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
                    if ((!whitelist.Contains(subscriberName.ToLower()) && !orangelist.Contains(subscriberName.ToLower())) || subscriber.AverageViewCount < 50)
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

            //white/orange list
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
                    if (!whitelist.Contains(subscriberName.ToLower()) && !orangelist.Contains(subscriberName.ToLower()))
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

            //watched at least one of theirs
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
                    if (subscriber.Watches > 0)
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
        }

        private static void LoadSubscribers(ChromeDriver driver, int rowsToIncrementOnSubPage, List<Subscriber.Subscriber> subscribers)
        {
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
                        var currentViewCount = video.FindElement(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Text.Split(new string[] { " view" }, StringSplitOptions.None)[0]
                            .Split(new string[] { " watching" }, StringSplitOptions.None)[0];
                        subscriber.ViewCounts.Add(GetIntegerViews(currentViewCount));
                        subscriber.AverageViewCount = subscriber.ViewCounts.Sum(Convert.ToInt32) == 0 ? 0 : subscriber.ViewCounts.Sum(Convert.ToInt32) / subscriber.Videos;
                    }

                    subscriber.ListType = GetSubscriberType(subscriber.Name);
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
                        var currentViewCount = video.FindElement(By.XPath("./div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//span[1]")).Text.Split(new string[] { " view" }, StringSplitOptions.None)[0]
                            .Split(new string[] { " watching" }, StringSplitOptions.None)[0];
                        subscriber.ViewCounts.Add(GetIntegerViews(currentViewCount));
                        subscriber.AverageViewCount = subscriber.ViewCounts.Sum(Convert.ToInt32) == 0 ? 0 : subscriber.ViewCounts.Sum(Convert.ToInt32) / subscriber.Videos;
                    }

                    subscriber.ListType = GetSubscriberType(subscriber.Name);
                }
            }

            //var commentedLately = string.Join(",", subscribers.Where(l => !l.CommentedLately).Select(l => l.Name));
        }

        private static void RunSingleVideoLookups(ChromeDriver driver, int rowsToIncrementOnSubPage, List<Subscriber.Subscriber> subscribers)
        {
            ReadOnlyCollection<IWebElement> videos;
//white list single vid
            //driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            //for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            //{
            //    ScrollToBottom(driver);
            //    Thread.Sleep(3000);
            //}

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            var currentElement = 0;
            var subscriberNameRepo = new SubscriberNameRepo();
            var viewedSubscribers = new List<Subscriber.Subscriber>();
            var subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            int index = 0;
            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (!whitelist.Contains(subscriberName.ToLower()) || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 10)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement);
                }

                index++;
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);

            //orange list single vid
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            subscriberNameRepo = new SubscriberNameRepo();
            viewedSubscribers = new List<Subscriber.Subscriber>();
            subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (!orangelist.Contains(subscriberName.ToLower()) || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 10)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement);
                }
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);

            //pink list single vid
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            subscriberNameRepo = new SubscriberNameRepo();
            viewedSubscribers = new List<Subscriber.Subscriber>();
            subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (!pinklist.Contains(subscriberName.ToLower()) || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 10)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement);
                }
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);

            //yellow list single vid
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            subscriberNameRepo = new SubscriberNameRepo();
            viewedSubscribers = new List<Subscriber.Subscriber>();
            subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (!yellowlist.Contains(subscriberName.ToLower()) || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 15)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement);
                }
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);

            //no stamp single vid
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            subscriberNameRepo = new SubscriberNameRepo();
            viewedSubscribers = new List<Subscriber.Subscriber>();
            subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (whitelist.Contains(subscriberName.ToLower()) || yellowlist.Contains(subscriberName.ToLower()) || blacklist.Contains(subscriberName.ToLower()) || orangelist.Contains(subscriberName.ToLower()) ||
                        pinklist.Contains(subscriberName.ToLower())
                        || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 15)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement);
                }
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);

            //black list single vid
            driver.NavigateToUrl("https:/www.youtube.com/feed/subscriptions");
            for (int i = 0; i < rowsToIncrementOnSubPage; i++)
            {
                ScrollToBottom(driver);
                Thread.Sleep(3000);
            }

            videos = driver.FindElementsByXPath("//ytd-grid-video-renderer");
            currentElement = 0;
            subscriberNameRepo = new SubscriberNameRepo();
            viewedSubscribers = new List<Subscriber.Subscriber>();
            subscriberNameString = subscriberNameRepo.GetSubscribers().ToLower();

            foreach (var video in videos)
            {
                var subscriberName = video.FindElement(By.XPath("./div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ytd-channel-name")).Text;
                var subscriber = subscribers.SingleOrDefault(s => s.Name == subscriberName);
                if (subscriber != null)
                {
                    var shrunkSubscriberName = subscriberName.Length <= 12 ? subscriberName.ToLower() : subscriberName.Substring(0, 12).ToLower();
                    if (!blacklist.Contains(subscriberName.ToLower()) || subscriberNameString.Contains(shrunkSubscriberName) || currentElement > 15)
                    {
                        RemoveElement(driver, currentElement);
                    }
                    else
                    {
                        StampElement(driver, subscriberName, currentElement);
                        viewedSubscribers.Add(subscriber);
                        subscriberNameString += $",{subscriberName}";

                        currentElement++;
                    }
                }
                else
                {
                    RemoveElement(driver, currentElement); 
                }
            }

            subscriberNameRepo.RefreshSubscribers(viewedSubscribers);
        }

        private static void ProcessWatchers(ChromeDriver driver, int rowsToIncrementComments, List<string> acceptableWatchTimesForCalculation, List<Watcher> watchers)
        {
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
            var timeCalculator = new TimeCalculator(TimeHolders);
            ProcessComments(comments, acceptableWatchTimesForCalculation, watchers, timeCalculator);

            driver.NavigateToUrl("https://studio.youtube.com/channel/UCUDTfpBksfE4KqLYjG9u00g/comments/spam?utm_campaign=upgrade&utm_medium=redirect&utm_source=%2Fcomments&filter=%5B%5D");
            Thread.Sleep(3000);
            ScrollToBottom(driver);
            Thread.Sleep(3000);

            comments = driver.FindElementsByXPath("//body//ytcp-comment-thread");
            ProcessComments(comments, acceptableWatchTimesForCalculation, watchers, timeCalculator);

            foreach (var watcher in watchers)
            {
                //watcher.GuessedWatchTime
                //watcher.AverageWatchTime
                //watcher.MaxWatchTime

                timeCalculator.CalculateTimeInfo(watcher, watchers);
            }
        }

        private static Subscriber.Subscriber.ListTypeEnum GetSubscriberType(string name)
        {
            var partialName = name.Length > 12 ? name.Substring(0, 12).ToLower() : name.ToLower();
            Subscriber.Subscriber.ListTypeEnum subscriberType;
            if (whitelist.Any(l => l.Contains(partialName)))
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.White;
            }
            else if (orangelist.Any(l => l.Contains(partialName)))
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.Orange;
            }
            else if (yellowlist.Any(l => l.Contains(partialName)))
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.Yellow;
            }
            else if (blacklist.Any(l => l.Contains(partialName)))
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.Black;
            }
            else if (pinklist.Any(l => l.Contains(partialName)))
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.Pink;
            }
            else
            {
                subscriberType = Subscriber.Subscriber.ListTypeEnum.Other;
            }

            return subscriberType;
        }

        private static void ProcessComments(ReadOnlyCollection<IWebElement> comments, List<string> acceptableWatchTimesForCalculation, List<Watcher> watchers, TimeCalculator timeCalculator)
        {
            foreach (var comment in comments)
            {
                if (comment.FindElements(By.XPath("./ytcp-comment[@id='comment']//yt-formatted-string[@class='author-text style-scope ytcp-comment']")).Count == 1)
                {
                    var commenterName = comment.FindElement(By.XPath("./ytcp-comment[@id='comment']//yt-formatted-string[@class='author-text style-scope ytcp-comment']")).Text;
                    var watcher = new Watcher();
                    watcher.WatcherName = commenterName;

                    var videoName = comment.FindElement(By.XPath("./ytcp-comment[@id='comment']//div//ytcp-comment-video-thumbnail//a//yt-formatted-string")).Text;
                    var shrunkVideoName = videoName.Length > 12 ? videoName.Substring(0, 12) : videoName;

                    watcher.Video = Videos.MyVideos.Single(v => v.Name.Contains(shrunkVideoName));
                    watcher.VideoName = videoName;
                    watcher.Comment = comment.FindElement(By.XPath("./ytcp-comment[@id='comment']//div//div[@id='content']//ytcp-comment-expander//div//yt-formatted-string")).Text;
                    watcher.ListType = GetSubscriberType(commenterName);

                    var watchTimeAmount = comment.FindElement(By.XPath("./ytcp-comment[1]/div[1]/div[1]/div[2]/div[1]/yt-formatted-string[1]")).Text;
                    if (watchTimeAmount.Contains("days") || watchTimeAmount.Contains("weeks"))
                    {
                        break;
                    }

                    foreach (var acceptableWatchTime in acceptableWatchTimesForCalculation)
                    {
                        if (watchTimeAmount.Contains(acceptableWatchTime))
                        {
                            watcher.TimeHolder = timeCalculator.GetTimeHolderFromString(watchTimeAmount);
                            watcher.TimeHolderNumber = watcher.TimeHolder.TimeElement; 
                            watcher.TimeHolderMaxWatchMinutes = watcher.TimeHolder.WatchMinutes;
                            watcher.FirstWatchMinutes = watcher.TimeHolder.WatchMinutes;
                            watcher.TimeHolderMaxViewCount = watcher.TimeHolder.ViewCount;
                            watcher.FirstViewCount = watcher.TimeHolder.ViewCount;

                            var nextTimeHolder = timeCalculator.GetNextTimeHolderFromString(watchTimeAmount);
                            watcher.TimeHolderMaxWatchMinutes += nextTimeHolder.WatchMinutes;
                            watcher.SecondWatchMinutes += nextTimeHolder.WatchMinutes;
                            watcher.TimeHolderMaxViewCount += nextTimeHolder.ViewCount;
                            watcher.SecondViewCount += nextTimeHolder.ViewCount;

                            watchers.Add(watcher);

                            break;
                        }
                    }

                    //var commenter = subscribers.SingleOrDefault(s => s.Name == commenterName);
                    //if (commenter != null)
                    //{
                    //    var watchTime = comment.FindElement(By.XPath("./ytcp-comment[1]/div[1]/div[1]/div[2]/div[1]/yt-formatted-string[1]")).Text;
                    //    foreach (var acceptableWatchTime in acceptableWatchTimes)
                    //    {
                    //        if (watchTime.Contains(acceptableWatchTime))
                    //        {
                    //            commenter.CommentedLately = true;
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }
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
            if (orangelist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid orange\";");
            if (yellowlist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid yellow\";");
            if (pinklist.Contains(subscriberName.ToLower()))
                jse.ExecuteScript($"return document.getElementsByTagName('ytd-grid-video-renderer')[{index}].style.border = \"5px solid pink\";");
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
