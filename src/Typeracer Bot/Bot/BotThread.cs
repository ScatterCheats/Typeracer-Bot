using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Typeracer_Bot.Variables;

namespace Typeracer_Bot.Bot
{
    public class BotThread
    {
        private ChromeDriver webDriver;
        bool accountPopupClosed = false;

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
                var gameStatusLabel = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("gameStatusLabel")));
                if(!gameStatusLabel.Text.Contains("text below:")){ Thread.Sleep(10); goto retry; }
            }
            catch (UnhandledAlertException) { Thread.Sleep(4);  goto retry; }
            FinishRace();
        }

        [Obsolete]
        private void FinishRace()
        { 
            IWebElement inputTextbox = webDriver.FindElement(By.XPath(XPaths.inputTextbox));
            IWebElement textContainer = webDriver.FindElement(By.XPath(XPaths.textContainer));

            if (!Configuration.instantMode)
            {
                try
                {
                    string text = textContainer.Text;
                    int msDelay;
                    int cpm = Configuration.wpm * 6; // 1 word = 5 characters
                    msDelay = (int)Math.Round(60d / cpm * 1000, 0); //60 seconds divided by letters per minute times 1000 for ms
                    Console.WriteLine();
                    foreach(char c in text)
                    {
                        inputTextbox.SendKeys(c.ToString());
                        Thread.Sleep(msDelay);
                    }
                    inputTextbox.Click();
                }
                catch (ElementNotInteractableException) { }
                catch (UnhandledAlertException) { }
            }
            else
            {
                string jscode = $"(document.evaluate(\"{XPaths.inputTextbox}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue).value = \"{textContainer.Text}\";";
                try
                {
                    webDriver.ExecuteAsyncScript(jscode);
                    inputTextbox.Click();
                }
                catch (WebDriverTimeoutException) { }
                catch (UnhandledAlertException) { }
            }
            Thread.Sleep(300);
            if (Configuration.autorace)
            {
                try
                {
                    webDriver.FindElement(By.ClassName("raceAgainLink")).Click();
                    if (!accountPopupClosed)
                    {
                        try
                        {
                            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(1));
                            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='No thanks :(']"))).Click();
                            accountPopupClosed =true;
                        }
                        catch (WebDriverTimeoutException) { }
                    }
                }
                catch (UnhandledAlertException) { }
            }
            WaitForRaceStart();
        }


    }
}
