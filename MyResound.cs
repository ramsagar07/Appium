using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using POM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class MyResound
    {
        AndroidDriver<AndroidElement> driver;
        public MyResound(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
        By learn_about_app = By.XPath("//android.widget.TextView[@content-desc='MyResoundLearningMenuTitleApp']");
        By guiding_tips = By.XPath("//android.widget.TextView[@content-desc='MyMenuNudgingTipsText']");
        public void press_program(string prog) //performs pressing action on desired feature
        {
            try
            {
                switch (prog.ToUpper())
                {
                    case "LEARN ABOUT THE APP":
                        driver.FindElement(learn_about_app).Click();

                        break;
                    case "GUIDING TIPS":
                        driver.FindElement(guiding_tips).Click();
                        break;
                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", $"Failed to press {prog}"+ex.Message, screenshot_loc);
            }
        }
    }
}
