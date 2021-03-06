﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace BLL.Services
{
    public static class FrequencyTimer
    {
        public static void Start(Feed feed)
        {
            Timer frequencyTimer = new Timer();
            frequencyTimer.Elapsed += (sender,e) => TimerElapsedHandler(feed);
            frequencyTimer.Interval = feed.Frequency.Minutes * 60 * 1000;
            frequencyTimer.Enabled = true;
            frequencyTimer.AutoReset = true;
        }

        private static void TimerElapsedHandler(Feed feed)
        {
            List<Episode> listOfEpisodes = FeedManager.GetEpisodes(feed.Url);
            feed.Episodes = listOfEpisodes;
        }
    }
}
