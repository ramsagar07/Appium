using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class LearnAboutApp
    {
        AndroidDriver<AndroidElement> driver;
        public LearnAboutApp(AndroidDriver<AndroidElement> driver)
        { 
            this.driver = driver;
        }
        By volume_control = By.XPath("//android.widget.TextView[@content-desc='HelpChapterTitleVolumeControls']");
        By program_card_volume = By.XPath("(//android.widget.LinearLayout[@index = '0'])[3]");
        By program_card_left_right_vol = By.XPath("(//android.widget.LinearLayout[@index = '0'])[4]");
        By program_text_left_right_vol = By.XPath("//android.widget.TextView[@content-desc='HelpVolumeControlsSplitTitle']");
        By program_text_mute = By.XPath("//android.widget.TextView[@content-desc='HelpVolumeControlsMuteTitle']");
        By close = By.XPath("//android.widget.ImageView[@content-desc='icon_close_m']");
        By back = By.XPath("(//android.view.ViewGroup[@index ='0'])[2]");
        public void clickvolumeControl() //performs pressing of volume control 
        {
            try
            {
                driver.FindElement(volume_control).Click();
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Volume control cannot be clicked as " + ex.Message, screenshot_loc);
            }
        }
        public void swipeleft(string page) //performs swiping left operation
        {
            AndroidElement card;
            try
            {
                card = driver.FindElement(program_card_volume);
                
                if (page == "3 / 3" )
                {
                     card = driver.FindElement(program_card_left_right_vol);
                }
                int width = card.Size.Width;
                int height = card.Size.Height;
                int start_y = height / 2;
                int end_x = 5;
                TouchAction actions = new TouchAction(driver);
                actions.Press(width, start_y).MoveTo(end_x, start_y).Release().Perform();

            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Swiping operation failed "+ex.Message, screenshot_loc);
            }
        }
        public void validateAnimation(string animation_name) //validates if the animation page is shown
        {
            string title;
            try
            {
                if(animation_name.ToUpper() == "LEFT AND RIGHT VOLUME")
                {
                    title = driver.FindElement(program_text_left_right_vol).Text;
                }
                else
                {
                    title = driver.FindElement(program_text_mute).Text;
                }
                
                Assert.AreEqual(animation_name, title);
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail",ex.Message, screenshot_loc);
            }
        }
        public void pressclose() //performs closing of learn about app
        {
            try
            {
                driver.FindElement(close).Click();
                driver.FindElement(back).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", ex.Message, screenshot_loc);
            }
        }
    }
}
