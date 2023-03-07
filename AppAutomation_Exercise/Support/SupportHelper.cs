using AppAutomation_Exercise.Configurations;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace AppAutomation_Exercise.Support
{
    [Binding]
    public class SupportHelper
    {
        private readonly ScenarioContext _scenarioContext;
        public SupportHelper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Initialize()
        {
            var driver = AppiumDriverSetup.InitializeDriver();
            _scenarioContext.Set(driver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _scenarioContext.Get<AndroidDriver<AppiumWebElement>>().Quit();
        }
    }
}
