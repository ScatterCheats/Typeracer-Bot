﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Typeracer_Bot.Bot;

namespace Typeracer_Bot
{
    public partial class ConfigForm : Form
    {

        public static ChromeDriver chrome;
        public BotThread botThread_obj;
        Thread bothread;

        public ConfigForm()
        {
            InitializeComponent();
            InitializeWebDriver();
        }

        private void InitializeWebDriver()
        {
            ChromeDriverService driverBuilder = null;
            ChromeOptions options = null;
            try
            {
                driverBuilder = ChromeDriverService.CreateDefaultService();
                driverBuilder.HideCommandPromptWindow = true;

                options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");
                options.AddExcludedArguments(new List<string>() { "enable-automation" });
                options.AddArguments("--disable-extensions");
                options.PageLoadStrategy = PageLoadStrategy.None;

            }
            catch (ArgumentException)
            {
                options = new ChromeOptions();
            notfound:
                MessageBox.Show("Chrome not found. Please specify your Google Chrome Path.", "Error", MessageBoxButtons.OK);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Chrome Binary|chrome.exe";
                ofd.InitialDirectory = "C:\\";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    options.BinaryLocation = ofd.FileName;
                }
                else
                {
                    goto notfound;
                }
                options.AddArgument("--start-maximized");
                options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");
                options.AddExcludedArguments(new List<string>() { "enable-automation" });
                options.AddArguments("--disable-extensions");
                options.PageLoadStrategy = PageLoadStrategy.None;

                driverBuilder = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory());
                driverBuilder.HideCommandPromptWindow = true;
            }
            catch
            {
                MessageBox.Show("Unknown Error occured");
                Application.Exit();
            }
            chrome = new ChromeDriver(driverBuilder, options);
            botThread_obj = new BotThread(chrome);
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bothread.Abort();
                chrome.Quit();
            }
            catch { }
        }

        private void SetupTyperacer()
        {
            MessageBox.Show("The Bot will activate once you get into a race. Don't forget to enable it!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            chrome.Navigate().GoToUrl("https://play.typeracer.com/");
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            SetupTyperacer();
        }

        private void EnabledCB_CheckedChanged(object sender, EventArgs e)
        {
            if (enabledCB.Checked)
            {
                bothread = new Thread(new ThreadStart(botThread_obj.WaitForRaceStart));
                bothread.Start();
            }
            else
            {
                bothread.Abort();
            }
        }

        private void InstantModeCB_CheckedChanged(object sender, EventArgs e)
        {
            if (instantModeCB.Checked)
            {
                infoLabel1.Enabled = false;
                wpmNup.Enabled = false;
                Configuration.instantMode = true;
            }
            else
            {
                infoLabel1.Enabled = true;
                wpmNup.Enabled = true;
                Configuration.instantMode = false;
            }
        }

        private void WpmNup_ValueChanged(object sender, EventArgs e)
        {
            Configuration.wpm = (int)wpmNup.Value;
        }

        private void AutoraceCB_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.autorace = autoraceCB.Checked;
        }
    }
}
