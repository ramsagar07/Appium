using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using POM.Support;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class Outdoor : Cards
    {
        AndroidDriver<AndroidElement> driver;
        private AllAround allAround;
        By wind_noise_red = By.XPath("(//android.view.View[@index = '0'])[5]");
        public Outdoor(AndroidDriver<AndroidElement> driver) : base(driver)
        {
            this.driver = driver;
        }
        public void set_wind_noiseReductionToStorng() //sets the wind noise reduction to strong on sound enhancer
        {
            try
            {
                AndroidElement wind_red = driver.FindElement(wind_noise_red);
                TouchAction action = new TouchAction(driver);
                action.Press(325, 2028).MoveTo(825, 2028).Release().Perform();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Wind Noise Reduction is not set to strong"+ex.Message, screenshot_loc);
            }
        }
 

    }
}
