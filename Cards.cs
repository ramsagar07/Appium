using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using POM.Pages;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Support
{
    public class Cards
    {
        public AndroidDriver<AndroidElement> driver;
        public Cards(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        By music_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_music_m']");
        By outdoor_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_outdoor_m']");
        By hearinnoise_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_hearinnoise_m']");
        By allaroung_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_allaround_m']");
        By program_overview = By.Id("dk.resound.smart3d:id/program_overview_drag_button");
        By sound_enhancer = By.Id("dk.resound.smart3d:id/finetune_button");
        By mode_name = By.Id("dk.resound.smart3d:id/card_title");
        By tinnitus = By.XPath("//android.widget.TextView[@content-desc='FineTuneSwitchButtonTitleTinnitusManager']");
        By tinnitus_exit = By.XPath("//android.widget.ImageView[@content-desc='icon_close_m']");
        By program_card = By.XPath("(//androidx.viewpager.widget.ViewPager[@index = '0'])[2]");
        By page_title = By.XPath("(//android.widget.TextView[@index = '2'])[1]");
        By html_view = By.XPath("//androidx.recyclerview.widget.RecyclerView[@index = '1']");
        public void VerifyModeName(string mode) //validates the program of the program cards
        {
            string mode_title = null;
            try
            {
                mode_title = driver.FindElement(mode_name).Text;
                Assert.AreEqual(mode, mode_title);
            }
            catch (Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("FAIL", $"The Mode is {mode_title} but expected to be {mode} "+e.Message, screenshot_loc);

            }

        }
        public void PressSoundenhancer() //presses the sound enhancer button
        {
            try
            {
                driver.FindElement(sound_enhancer).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Sound enhacer not pressed as" + ex.Message, screenshot_loc);
            }
        }
        public void pressTinnitusManager() //presses the tinnitusmanager 
        {
            try
            {
                driver.FindElement(tinnitus).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Tinnitus manager not pressed as" + ex.Message, screenshot_loc);
            }
        }
        public void PressExitTinnitusManager() //presses exit on tinnitus manager
        {
            try
            {
                driver.FindElement(tinnitus_exit).Click();
            }
            catch (Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Action not performed as" + e.Message, screenshot_loc);
            }
        }
        public void Swipeleft() //swipes left from one program card to another program card
        {
            try
            {
                AndroidElement card = driver.FindElement(program_card);
                int width = card.Size.Width;
                int height = card.Size.Height;
                int start_y = height / 2;
                int end_x = 5;
                TouchAction action = new TouchAction(driver);
                action.Press(width, start_y).MoveTo(end_x, start_y).Release().Perform();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "swiping operation not performed as" + ex.Message, screenshot_loc);
            }
        }
        public void press_program(string program) //presses the program on top ribbon bar and program overview 
        {
            try
            {
                switch (program.ToUpper())
                {
                    case "ALL-AROUND":
                        driver.FindElement(allaroung_prog).Click();
                        break;
                    case "HEAR IN NOISE":
                        driver.FindElement(hearinnoise_prog).Click();
                        break;
                    case "OUTDOOR":
                        driver.FindElement(outdoor_prog).Click();
                        break;
                    case "MUSIC":
                        driver.FindElement(music_prog).Click();
                        break;
                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", $"The Program {program} is not pressed as " + ex.Message, screenshot_loc);
            }
        }
        public void ValidatePageTitleDisplayed(string page)
        {
            try
            {
                AndroidElement title = driver.FindElement(page_title);
                string act_title = title.Text;
                bool status = title.Displayed;
                Assert.IsTrue(status);
                Assert.AreEqual(page, act_title);
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", ex.Message, screenshot_loc);
            }
        }
        public void ValidateHtmlView()
        {
            bool status = driver.FindElement(html_view).Displayed;
            Assert.IsTrue(status);
        }
    }
}
