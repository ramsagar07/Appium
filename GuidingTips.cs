using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service.Options;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class GuidingTips
    {
        AndroidDriver<AndroidElement> driver;
        public GuidingTips(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        By ok = By.XPath("//android.widget.TextView[@content-desc='NudgingArchiveDialogConfirm']");
        By page_Title = By.XPath("//android.widget.TextView[@content-desc='MyMenuNudgingTipsText']");
        By noise_filter = By.XPath("//android.widget.TextView[@content-desc='NudgingFunctionalTip1Week5Header']");
        By music_program = By.XPath("//android.widget.TextView[@content-desc='NudgingFunctionalTip1Week3Header']");
        By gotit = By.XPath("//android.widget.TextView[@content-desc='NudgingTipConfirmButton']");
        By myresound = By.XPath("//android.widget.ImageView[@content-desc='bottom_menu_icon_person']");
        By back_to_tips = By.XPath("//android.widget.TextView[@content-desc='NudgingTipBackToArchiveButton']");
        By more = By.XPath("//android.widget.TextView[@content-desc='TabBarMoreTitle']");
        public void Press(string prog) //performs pressing action on desired button
        {
            try
            {
                switch(prog.ToUpper())
                {
                    case "OK":
                        driver.FindElement(ok).Click();
                        break;
                    case "NOISE FILTER":
                        driver.FindElement(noise_filter).Click();
                        break;
                    case "MUSIC PROGRAM":
                        driver.FindElement(music_program).Click();
                        break;
                    case "GOT IT":
                        driver.FindElement(gotit).Click(); 
                        break;
                    case "MY RESOUND":
                        driver.FindElement(myresound).Click();
                        break;
                    case "MORE":
                        driver.FindElement(more).Click();
                        break;
                }
            }
            catch(Exception e) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", $"Failed to press {prog}" + e.Message, screenshot_loc);
            }

        }
        public void ValidateTitle(string title) //validates the title of guiding tips page
        {
            try
            {
                string act_title = driver.FindElement(page_Title).Text;
                Assert.AreEqual(title, act_title);
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", ex.Message, screenshot_loc);
            }
           
        }
        public void ValidateEnabled(string name) //validates the buttons  got it and back to tips are enabled
        {
            bool status;
            try
            {
                if (name.ToUpper() == "GOT IT")
                {
                    status = driver.FindElement(gotit).Enabled;

                }
                else
                {
                    status = driver.FindElement(back_to_tips).Enabled;
                }
                Assert.IsTrue(status);
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Expected to be enabled "+ex.Message, screenshot_loc);
            }
        }
    }
}
