using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typeracer_Bot.Variables
{
    public static class XPaths
      {

        public static string inputTextbox = "//table/tbody/tr[2]/td/table/tbody/tr[2]/td/input";
        public static string textContainer = "//table[contains(concat(' ', normalize-space(@class), ' '), ' gameView ')]/tbody/tr[2]/td/table/tbody/tr[1]/td/table/tbody/tr[1]/td/div/div";

    }
}
