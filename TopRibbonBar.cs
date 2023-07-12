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
    
    public class TopRibbonBar : Cards
    {
        AndroidDriver<AndroidElement> driver;
        
        public TopRibbonBar(AndroidDriver<AndroidElement> driver) : base(driver) 
        { 
            this.driver = driver;
        }
        By music_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_music_m']");
        By outdoor_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_outdoor_m']");
        By hearinnoise_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_hearinnoise_m']");
        By allaroung_prog = By.XPath("//android.widget.ImageView[@content-desc='prg_allaround_m']");
        By program_overview = By.Id("dk.resound.smart3d:id/program_overview_drag_button");
        public void pressProgramOverview() //performs pressing of program overiew
        {
            try
            {
                driver.FindElement(program_overview).Click();
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Failed to press program overview" + ex.Message, screenshot_loc);
            }
        }
    }
}
