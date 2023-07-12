using OpenQA.Selenium.Appium.Android;
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
    public class Music : Cards
    {
        AndroidDriver<AndroidElement> driver;
        public Music(AndroidDriver<AndroidElement> driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
