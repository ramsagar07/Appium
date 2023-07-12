using NUnit.Framework;
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
    public class LegalInformation :Cards
    {
       AndroidDriver<AndroidElement> driver;
        public LegalInformation(AndroidDriver<AndroidElement> driver) :base(driver)
        {
            this.driver = driver;
        }
        By manufacturer = By.XPath("//android.widget.RelativeLayout[@index = '1']");
        By terms = By.XPath("//android.widget.RelativeLayout[@index = '2']");
        By privacy = By.XPath("//android.widget.RelativeLayout[@index = '4']");
        By back = By.XPath("//android.widget.ImageView[@content-desc='icon_arrow_back_m']");
        
        public void Press(string name) //performs pressing action on desired feature
        {
            try
            {
                switch (name.ToUpper())
                {
                    case "MANUFACTURER":
                        driver.FindElement(manufacturer).Click();
                        break;
                    case "TERMS AND CONDITIONS":
                        driver.FindElement(terms).Click();
                        break;
                    case "PRIVACY POLICY":
                        driver.FindElement(privacy).Click();
                        break;
                    case "BACK":
                        driver.FindElement(back).Click();
                        break;
                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Unable to press Element as "+ex.Message, screenshot_loc);
            }
        }
        

    }
}
