using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using POM.Support;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class More :Cards
    {
        AndroidDriver<AndroidElement> driver;
        public More(AndroidDriver<AndroidElement> driver) :base(driver)
        {
            this.driver = driver;
        }
        By auto_active = By.XPath("//android.widget.Switch[@content-desc='AppAutoActivateSwitch']");
        By about = By.XPath("//android.widget.TextView[@content-desc='MoreGeneralAboutText']");
        By about_title = By.XPath("//android.widget.TextView[@content-desc='AboutHeaderTitle']");
        By back = By.XPath("//android.widget.ImageView[@content-desc='icon_arrow_back_m']");
        By legal_info = By.XPath("//android.widget.RelativeLayout[@index = '6']");
        By support = By.XPath("//android.widget.RelativeLayout[@index = '7']");
        By home = By.XPath("//android.widget.ImageView[@content-desc='bottom_menu_icon_main']");
        public void ValidateOnOff(string name) //validates if a switch is or on off
        {
            bool status;
            try
            {
                switch (name.ToUpper())
                {
                    case "ON":
                        status = false;
                        status = driver.FindElement(auto_active).GetAttribute("checked") == "true";
                        Assert.IsTrue(status);
                        break;
                    case "OFF":
                        status = true;
                        status = driver.FindElement(auto_active).GetAttribute("checked") == "true";
                        Assert.IsFalse(status);
                        break;
                    default:
                        Assert.Fail("Invalid case");
                        break;
                }
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", ex.Message, screenshot_loc);
            }
        }
        
        public void Press(string name) // performs pressing action on desired feature
        {
            try
            {
                switch (name.ToUpper())
                {
                    
                    case "AUTO-ACTIVATE FAVORITE LOCATIONS":
                        driver.FindElement(auto_active).Click();
                        break;
                    case "ABOUT":
                        driver.FindElement(about).Click();
                        break;
                    case "LEGAL INFORMATION":
                        driver.FindElement(legal_info).Click();
                        break;
                    case "BACK":
                        driver.FindElement(back).Click();
                        break;
                    case "SUPPORT":
                        driver.FindElement(support).Click();
                        break;
                    case "HOME":
                        driver.FindElement(home).Click();
                        break;
                default:
                    Assert.Fail($"NO matching case{name.ToUpper()}");
                    break;
                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", $"Unable to press button {name} as "+ex.Message, screenshot_loc);
            }
        }

           
        
       
        
    }

}
