using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using POM.Support;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class HearInNoise : Cards
    {
        AndroidDriver<AndroidElement> driver;
        public HearInNoise(AndroidDriver<AndroidElement> driver) : base(driver)
        {
            this.driver = driver;
        }

        By slightvariation = By.XPath("//android.widget.Button[@content-desc='TsgWhiteNoiseVariationsSlight']");
        By reset = By.XPath("//android.widget.TextView[@content-desc='FineTuneButtonReset']");
        By program_card = By.XPath("(//androidx.viewpager.widget.ViewPager[@index = '0'])[2]");

        public void pressSlightvariation() //performs pressing operation on slight variation of tinnitus manager
        {
            try
            {
                driver.FindElement(slightvariation).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Slight Variation is not pressed as" + ex.Message, screenshot_loc);
            }
        }
        public void pressReset()  //performs pressing operation on Reset of tinnitus manager
        {
            try
            {
                driver.FindElement(reset).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "The Reset button is not pressed as" + ex.Message, screenshot_loc);
            }

        }
    }
}

