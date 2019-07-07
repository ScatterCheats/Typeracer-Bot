using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Typeracer_Bot.Variables;

namespace Typeracer_Bot.Bot
{
    public class BotThread
    {
        private ChromeDriver webDriver;
        private bool ongoingRace = false;

        public BotThread(ChromeDriver driver)
        {
            webDriver = driver;
        }

        [Obsolete]
        public void WaitForRaceStart()
        {
            while (true)
            {

                if (!ongoingRace)
                {
                    try
                    {
                        if (webDriver.ExecuteAsyncScript("document.evaluate('//table/tbody/tr[2]/td/table/tbody/tr[2]/td/input', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;").ToString() != null)
                            FinishRace();
                    }
                    catch
                    {

                    }
                }
                Task.Delay(500);
            }

        }

        private void FinishRace()
        {
            ongoingRace = true;
            
            IWebElement firstLetterSpan = webDriver.FindElement(By.XPath(XPaths.firstLetterPath));
            IWebElement remainingTextSpan = webDriver.FindElement(By.XPath(XPaths.remainingText));
            IWebElement inputTextboxElement = webDriver.FindElement(By.XPath(XPaths.inputTextbox));

            string text = firstLetterSpan.Text + remainingTextSpan.Text;

            try
            {
                while (!webDriver.FindElement(By.XPath(XPaths.timer)).Text.Contains("Go"))
                {
                    Thread.Sleep(100);
                }
                
            }
            catch
            {

            }

            inputTextboxElement.SendKeys(text);

        }


    }
}
