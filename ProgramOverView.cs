using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using POM.Support;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class ProgramOverView :Cards
    {
        AndroidDriver<AndroidElement> driver;

        public ProgramOverView(AndroidDriver<AndroidElement> driver) :base(driver)
        {
            this.driver = driver;
        }
        By close = By.XPath("//android.widget.ImageView[@content-desc='icon_close_m']");
        By myresound = By.XPath("//android.widget.ImageView[@content-desc='bottom_menu_icon_person']");
        public void press_Close() //performs closing of program overview
        {
            try
            {
                driver.FindElement(close).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Failed to press close button" + ex.Message, screenshot_loc);
            }

        }
        public void preeMyresound() //performs pressing of MY RESOUND on botton ribbon bar
        {
            try
            {
                driver.FindElement(myresound).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Failed to press My Resound"+ex.Message, screenshot_loc);
            }
        }
    }
}
