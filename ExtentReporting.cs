using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;

namespace POM.Utility
{
    public class ExtentReporting
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static ExtentTest step;
        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("C:\\Users\\iray\\source\\repos\\POM\\POM\\bin\\Debug\\net6.0", "TestReport");

        public static void ExtentReportInit() //creates extent report
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "smart3d_Report";
            htmlReporter.Config.DocumentTitle = "Final_Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Smart3d");
            _extentReports.AddSystemInfo("OS", "Android");
        }
        public static void ExtentReportTeardown() 
        {
            _extentReports.Flush();
        }

        public static string addscreenshot(AppiumDriver<AndroidElement> driver) //takes screenshots on failure
        {
            ITakesScreenshot takescreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takescreenshot.GetScreenshot();
            string screenshotlocation = "C:\\Users\\iray\\source\\repos\\POM\\POM\\bin\\Debug\\net6.0\\TestReport\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".png";
            
            screenshot.SaveAsFile(screenshotlocation, ScreenshotImageFormat.Png);
            return screenshotlocation;
        }
        public void AddStep(ScenarioContext scenarioContext) //adds steps to extent report
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    step = _scenario.CreateNode<Given>(stepName);

                }
                else if (stepType == "When")
                {
                    step = _scenario.CreateNode<When>(stepName);

                }
                else if (stepType == "Then")
                {
                    step = _scenario.CreateNode<Then>(stepName);

                }
            }
        }
        public static void log(String Result, String desc, string location) //used for logging to extent report
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            switch (Result.ToUpper().Trim())
            {
                case "PASS":
                    step.Log(Status.Pass, desc);
                    break;
                case "FAIL":
                    step.Log(Status.Fail, desc);
                    step.AddScreenCaptureFromPath(location);
                    break;
                case "INFO":
                    step.Log(Status.Info, desc);
                    break;
                default:
                    throw new ArgumentException("Unknown Result type: " + Result + " in Log.");
            }
        }

    }
}
