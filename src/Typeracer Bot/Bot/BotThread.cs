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
        

        public BotThread(ChromeDriver driver)
        {
            webDriver = driver;
        }

        [Obsolete]
        public void WaitForRaceStart()
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(int.MaxValue));
            var gameStatusLabel = wait.Until(ExpectedConditions.ElementExists(By.ClassName("gameStatusLabel")));
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(int.MaxValue));
            wait.Until(ExpectedConditions.TextToBePresentInElement(gameStatusLabel, "The race is on! Type the text below:"));
            FinishRace();
        }

        private void FinishRace()
        { 
            IWebElement firstLetterSpan = webDriver.FindElement(By.XPath(XPaths.firstLetterPath));
            IWebElement remainingTextSpan = webDriver.FindElement(By.XPath(XPaths.remainingText));
            IWebElement inputTextboxElement = webDriver.FindElement(By.XPath(XPaths.inputTextbox));
            string text = firstLetterSpan.Text + remainingTextSpan.Text;
            inputTextboxElement.SendKeys(text);

        }


    }
}
