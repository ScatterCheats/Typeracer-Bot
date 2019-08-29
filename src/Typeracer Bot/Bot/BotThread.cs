using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Typeracer_Bot.Variables;

namespace Typeracer_Bot.Bot
{
    public class BotThread
    {
        private ChromeDriver webDriver;
        

        public BotThread(ChromeDriver driver)
        {
            webDriver = driver;
        }

        [Obsolete]
        public void WaitForRaceStart()
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(int.MaxValue));
            retry:
            try
            {
                var gameStatusLabel = wait.Until(ExpectedConditions.ElementExists(By.ClassName("gameStatusLabel")));
                wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(int.MaxValue));
                wait.Until(ExpectedConditions.TextToBePresentInElement(gameStatusLabel, "The race is on! Type the text below:"));
            }
            catch (UnhandledAlertException) { Thread.Sleep(4);  goto retry; }
            FinishRace();
        }

        private void FinishRace()
        { 
            IWebElement inputTextbox = webDriver.FindElement(By.XPath(XPaths.inputTextbox));
            IWebElement textContainer = webDriver.FindElement(By.XPath(XPaths.textContainer));

            if (!Configuration.instantMode)
            {
                try
                {
                    inputTextbox.SendKeys(textContainer.Text);
                }
                catch (ElementNotInteractableException) { }
            }
            else
            {
                string jscode = $"(document.evaluate(\"{XPaths.inputTextbox}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue).value = \"{textContainer.Text}\";";
                try
                {
                    webDriver.ExecuteAsyncScript(jscode);
                }
                catch (WebDriverTimeoutException) { }
            }
            Thread.Sleep(1000);
            WaitForRaceStart();
        }


    }
}
