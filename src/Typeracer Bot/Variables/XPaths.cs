﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typeracer_Bot.Variables
{
    public static class XPaths
    {
        public static string firstLetterPath = "//table/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[1]/td/div/div/span[1]";
        public static string remainingText = "//table/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[1]/td/div/div/span[2]";
        
        public static string inputTextbox = "//table/tbody/tr[2]/td/table/tbody/tr[2]/td/input";
        public static string timer = "/html/body/div[5]/div/table/tbody/tr/td/table/tbody/tr/td[2]/div";
        public static string checkElement = "//table/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[2]/td/a";
        
    }
}