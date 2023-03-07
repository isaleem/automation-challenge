using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using Microsoft.Extensions.Configuration;

namespace AppAutomation_Exercise.Configurations
{
    /// <summary>
    /// Appium driver setup.
    /// </summary>
    public static class AppiumDriverSetup
    {
        /// <summary>
        /// Registring the app settings and getting the appttings section for getting the values.
        /// </summary>
        public static readonly IConfigurationSection configuration
            = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetSection("AppSettings");

        /// <summary>
        /// Initialize appium driver with device and apk setup.
        /// </summary>
        /// <returns>Appium driver.</returns>
        public static AndroidDriver<AppiumWebElement> InitializeDriver()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, configuration["PlatformName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, configuration["DeviceName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Environment.CurrentDirectory + configuration["ApkName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, configuration["AutomationName"]);

            return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions, TimeSpan.FromMinutes(10));
        }
    }
}
