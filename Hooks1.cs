using BoDi;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;
using POM.StepDefinitions;
using POM.Utility;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium.Remote;
using System.Net.Http;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Threading.Channels;

namespace POM.Hooks
{
    [Binding]
    public sealed class Hooks1 : ExtentReporting
    {
        private AndroidDriver<AndroidElement> driver;
        private readonly IObjectContainer _container;

        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTeardown();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            By demo = By.Id("dk.resound.smart3d:id/demo_button");
            By Demo_ok = By.XPath("//android.widget.TextView[@content-desc='ConsentPopupButtonOK']");
            By welcome_yes = By.XPath("//android.widget.TextView[@content-desc='NudgingIntro1YesButton']");
            By cancel = By.XPath("//android.widget.ImageView[@content-desc='icon_close_m']");
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("platformName", "Android");
            appiumOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability("deviceName", "Android Emulator");
            appiumOptions.AddAdditionalCapability("udid", "cd11a3cf");
            appiumOptions.AddAdditionalCapability("platformVersion", "12");
            appiumOptions.AddAdditionalCapability(CapabilityType.Timeouts, TimeSpan.FromSeconds(20));
            appiumOptions.AddAdditionalCapability("app", "C:\\Users\\iray\\smart3d\\dk.resound.smart3d-Signed.apk");
            appiumOptions.AddAdditionalCapability("appPackage", "dk.resound.smart3d");
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(120);
            var commandExecutor = new HttpCommandExecutor(new Uri("http://localhost:4723/wd/hub"), TimeSpan.FromSeconds(120));
            driver = new AndroidDriver<AndroidElement>(commandExecutor, appiumOptions);
            _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AllAroundSteps allaround = new AllAroundSteps(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            
            try //clicks take me to demo mode on welcome page
            {
                driver.FindElement(demo).Click();
            }
            catch (Exception e)
            {
             string screenshot_loc = addscreenshot(driver);
             log("FAIL", "The button cannot  be clicked as" + e.Message, screenshot_loc);
            }
            try //presses ok  on the appeared notification
            {
                driver.FindElement(Demo_ok).Click();

            }
            catch (Exception e)
            {
                string screenshot_loc = addscreenshot(driver);
                log("FAIL", "The button cannot  be clicked as" + e.Message, screenshot_loc);

            }
            try  //presses yes on appeared notfication 
            {
                driver.FindElement(welcome_yes).Click();
            }
            catch (Exception e)
            {
                string screenshot_loc = addscreenshot(driver);
                log("FAIL", "The button cannot  be clicked as" + e.Message, screenshot_loc);
            }
            try //closes app tour guide 
            {
                driver.FindElement(cancel).Click();
            }
            catch (Exception e)
            {
                string screenshot_loc = addscreenshot(driver);
                log("FAIL", "The button cannot  be clicked as" + e.Message, screenshot_loc);
            }

        }


        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            AddStep(scenarioContext);
        }
    }
}