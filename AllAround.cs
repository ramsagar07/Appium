using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using POM.Utility;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Interfaces;
using static System.Collections.Specialized.BitVector32;
using System.Collections;
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Appium.Enums;
using POM.Support;

namespace POM.Pages
{
    public class AllAround : Cards
    {
        private AndroidDriver<AndroidElement> _driver;
        public AllAround(AndroidDriver<AndroidElement> driver): base(driver)
        {
            _driver = driver;
            
        }
        By split = By.Id("dk.resound.smart3d:id/SplitImageView_bottom");
        By Rightslider = By.XPath("(//android.widget.ImageView[@index = '0'])[7]");
        By Left_slider = By.XPath("(//android.widget.ImageView[@index = '0'])[8]");
        By Slider = By.XPath("(//android.widget.ImageView[@index = '1'])[5]");
        By Speech_clarity = By.XPath("//android.widget.TextView[@content-desc='SmartButtonAllAroundSpeechClarity']");
        By Noise_filter = By.XPath("//android.widget.TextView[@content-desc='SmartButtonAllAroundNoiseFilter']");
        By merge = By.XPath("//android.widget.ImageView[@content-desc='icon_split1_s']");
        By Middle_gain = By.XPath("(//android.view.View[@index = '0'])[2]");
        By Bass_gain = By.XPath("(//android.view.View[@index = '0'])[1]");
        By Treble_gain = By.XPath("(//android.view.View[@index = '0'])[3]");
        By calm_waves = By.XPath("//android.widget.Button[@content-desc='TsgNatureSoundsCalmingWaves']");
        By breaking_waves = By.XPath("//android.widget.Button[@content-desc='TsgNatureSoundsBreakingWaves']");

       
        public void PressSplitButton() //performs splitting of sorrounding volume bar
        {
            try
            {
                driver.FindElement(split).Click();
            }

            catch (Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("FAIL", "The button cannot  be clicked as " + e.Message,screenshot_loc);
            }
        }
       
        public void ValidateHI_Value(string HI, string value) //validates the value of sorrounding volume bar
        {
            
            int x_co;
            int x_offset = 2;
            int y;
            string actual_value = null;
            if (value == "13")
            {
                x_offset = -10;
            }
            TouchAction action = new TouchAction(driver);
            
            
            try
            {
                switch(HI.ToUpper())
                {
                    case "RIGHT HI":
                        AndroidElement rightslider = driver.FindElement(Rightslider);
                        x_co = rightslider.Location.X+35;
                        y = 1698;
                        action.Press(x_co, y).MoveTo(x_co + x_offset, y).Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='VolumeChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        action.Release().Perform();
                        break;
                    case "LEFT HI":
                        y = 1846;
                        AndroidElement leftslider = driver.FindElement(Left_slider);
                        x_co = leftslider.Location.X + 35;
                        action.Press(x_co, y).MoveTo(x_co + x_offset, y).Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='VolumeChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        action.Release().Perform();
                        break;
                    case "HI":
                        y = 1846;
                        AndroidElement slider = driver.FindElement(Slider);
                        x_co = slider.Location.X+30;
                        action.Press(x_co, y).MoveTo(x_co + x_offset, y).Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='VolumeChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        action.Release().Perform();
                        break;



                }
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", ex.Message, screenshot_loc);
            }
            

        }
        public void move_sliders(string present, string target_value, string HI) //moves the slider of sorrounding volume bar
        {
            TouchAction action = new TouchAction(driver);
            int y = 1698;
            int present_pos;
            int target_pos;
            present_pos = GetCoordinates(present);
            target_pos = GetCoordinates(target_value);
            try
            {
                switch(HI.ToUpper())
                {
                    case "RIGHT HI":
                        y = 1698;
                        action.Press(present_pos, y).MoveTo(target_pos, y).Release().Perform();
                        break;
                    case "LEFT HI" or "HI":
                        y = 1846;
                        action.Press(present_pos, y).MoveTo(target_pos, y).Release().Perform();
                        break;
                }
            }
            catch(Exception ex) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Failed to move slider"+ex.Message, screenshot_loc);
            }
            
        }      
        public void click_merge() //performs merging of sorrounding volume bar
        {
            try
            {
                driver.FindElement(merge).Click();
            }
            catch(Exception e) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Unable to click as"+e.Message,screenshot_loc);
            }
        }
        public void clickquickbutton(string button_name) //performs pressing of speech clarity and noise filter
        {
            try
            {
                switch (button_name.ToUpper())
                {
                    case "SPEECH CLARITY":
                        driver.FindElement(Speech_clarity).Click();
                        break;
                    case "NOISE FILTER":
                        driver.FindElement(Noise_filter).Click();
                        break;
                }
            }
            catch(Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("FAIL", $"The quick button cannot  be clicked as{screenshot_loc}" + e.Message, screenshot_loc);
            }
        }
        public void isenabled(string button_name) //validates wheather quick buttons noise filter and speech clarity are enabled
        {
            bool result = false;
            try
            {
                switch (button_name.ToUpper())
                {

                    case "SPEECH CLARITY":
                        result = driver.FindElement(Speech_clarity).Selected;
                        Assert.IsTrue(result);
                        break;
                    case "NOISE FILTER":
                        result = driver.FindElement(Noise_filter).Selected;
                        Assert.IsTrue(result);
                        break;
                }
            }
            catch(Exception e)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("FAIL", "The quick button is expected to be selected but it is not selected as "+e.Message, screenshot_loc);
            }
                
            
        }
        public void isdiabled(string button_name) //validates wheather quick buttons noise filter and speech clarity are disabled
        { 
            bool result;
            try
            {
                switch (button_name.ToUpper())
                {

                    case "SPEECH CLARITY":
                        result = driver.FindElement(Speech_clarity).Selected;
                        Assert.IsFalse(result);
                        break;
                    case "NOISE FILTER":
                        result = driver.FindElement(Noise_filter).Selected;
                        Assert.IsFalse(result);
                        break;
                }
            }
            catch(Exception e) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("FAIL", "The quick button is expected to be not selected but it is selected"+e.Message, screenshot_loc);
            }
        }
        public void MoveGainSliders(string gain_type, string target_value, string present) //Moves the slider of sound enhancer to desired value
        {
            int x_co;
            int start_y_co;
            int end_y_co;
            TouchAction action = new TouchAction(driver);
            try
            {
                switch (gain_type.ToUpper())
                {
                    case "BASS GAIN":
                        AndroidElement bassgain = driver.FindElement(Bass_gain);
                        x_co = 90;
                        start_y_co = bassgain.Location.Y;
                        start_y_co += 35;
                        end_y_co = GetSliderCoordinates(target_value);
                        action.Press(x_co, start_y_co).MoveTo(x_co, end_y_co).Release().Perform();
                        break;
                    case "MIDDLE GAIN":
                        AndroidElement middlegain = driver.FindElement(Middle_gain);
                        x_co = 450;
                        start_y_co = middlegain.Location.Y;
                        start_y_co += 35;
                        end_y_co = GetSliderCoordinates(target_value);
                        action.Press(x_co,start_y_co).MoveTo(x_co,end_y_co).Release().Perform();
                        break;
                    case "TREBLE GAIN":
                        AndroidElement treblegain = driver.FindElement(Treble_gain);
                        x_co = 810;
                        start_y_co = treblegain.Location.Y;
                        start_y_co += 35;
                        end_y_co = GetSliderCoordinates(target_value);
                        action.Press(x_co, start_y_co).MoveTo(x_co, end_y_co).Release().Perform();
                        break;

                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", "Slider didnot move as /n" + ex.Message, screenshot_loc);
            }
        }
       
        public void ValidateGainValue(string gain, string value) //validates the values of slider of sound enhancer
        {
            string actual_value = null;
            Actions actions = new Actions(driver);

            int x_offset = 2;
            if (value == "-6")
            {
                x_offset = -2;
            }

            try
            {

                switch (gain.ToUpper())
                {
                    case "BASS GAIN":

                        AndroidElement bassgain = driver.FindElement(Bass_gain);
                        actions.ClickAndHold(bassgain)
                            .MoveByOffset(x_offset, 0)
                            .Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='GainChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        actions.Release()
                            .Perform();
                        break;
                    case "MIDDLE GAIN":
                        AndroidElement middlegain = driver.FindElement(Middle_gain);
                        actions.ClickAndHold(middlegain)
                            .MoveByOffset(x_offset, 0)
                            .Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='GainChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        actions.Release()
                            .Perform();
                        break;
                    case "TREBLE GAIN":
                        AndroidElement treblegain = driver.FindElement(Treble_gain);
                        actions.ClickAndHold(treblegain)
                            .MoveByOffset(x_offset, 0)
                            .Perform();
                        actual_value = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='GainChanging']")).Text;
                        Assert.AreEqual(value, actual_value);
                        actions.Release()
                            .Perform();
                        break;

                }
            }
            catch (Exception ex)
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);

                ExtentReporting.log("Fail", $"Expected the value to be {value} but the actual value is {actual_value}" + ex.Message, screenshot_loc);


            }

        }
        
        public void PressNatureWaves(string wave_type) //performs pressing of nature waves on tinnitus manager
        {
            try
            {
                switch(wave_type.ToUpper())
                {
                    case "CALMING WAVES":
                        driver.FindElement(calm_waves).Click();
                        break;
                    case "BREAKING WAVES":
                        driver.FindElement(breaking_waves).Click();
                        break;
                }
            }
            catch(Exception e ) 
            {
                string screenshot_loc = ExtentReporting.addscreenshot(driver);
                ExtentReporting.log("Fail", $"the {wave_type} button is not pressed as" + e.Message, screenshot_loc);
            }
        }
        public int GetCoordinates(string value) //returns the coordinates to move sliders method
        {
            int pos = 0;
            switch (value)
            {
                case "1":
                    pos = 249;
                    break;
                case "2":
                    pos = 295;
                    break;
                case "3":
                    pos = 356;
                    break;
                case "4":
                    pos = 402;
                    break;
                case "5":
                    pos = 480;
                    break;
                case "6":
                    pos = 545;
                    break;
                case "7":
                    pos = 579;
                    break;
                case "8":
                    pos = 620;
                    break;
                case "9":
                    pos = 703;
                    break;
                case "10":
                    pos = 745;
                    break;
                case "11":
                    pos = 808;
                    break;
                case "12":
                    pos = 858;
                    break;
                case "13":
                    pos = 905;
                    break;
             
            }
            return pos;
        }
        public int GetSliderCoordinates(string value) //returns the coordinates of sliders of sound enhancer 
        {
            int pos = 0;
            switch (value)
            {
                case "-6":
                    pos = 1720;
                    break;
                case "-5":
                    pos = 1621;
                    break;
                case "-4":
                    pos = 1524;
                    break;
                case "-3":
                    pos = 1426;
                    break;
                case "-2":
                    pos = 1329;
                    break;
                case "-1":
                    pos = 1232;
                    break;
                case "0":
                    pos = 1134;
                    break;
                case "1":
                    pos = 1037;
                    break;
                case "2":
                    pos = 940;
                    break;
                case "3":
                    pos = 842;
                    break;
                case "4":
                    pos = 745;
                    break;
                case "5":
                    pos = 648;
                    break;
                case "6":
                    pos = 550;
                    break;
            }
            return pos;
        }
       


        
    }
}

