using AppAutomation_Exercise.Support;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace AppAutomation_Exercise.StepDefinitions
{
    [Binding]
    public class MovieViewDetailsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly AndroidDriver<AppiumWebElement> _driver;
        private readonly ElementLocators _locators;
        public MovieViewDetailsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
            _locators = new ElementLocators(_driver);
        }

        [Given(@"user is on the main screen with list of movies")]
        public void GivenIAmOnTheMainScreenWithListOfMovies()
        {
            var search_bar = _locators.SearchBar;
            Assert.True(search_bar.Displayed);
        }


        [When(@"user searches for a movie whose name starts with ""([^""]*)""")]
        public void WhenISearchForAMovieWhoseNameStartsWith(string movieName)
        {
            var search_bar = _locators.SearchBar;
            search_bar.Click();
            search_bar.SendKeys(movieName);
        }

        [When("user selects the second option from the result list of movies in search box")]
        public void WhenISelectTheSecondOptionFromTheResultListOfMoviesInSearchBox()
        {
            var searchresults = _locators.SearchResult;
            searchresults[1].Click();
        }

        [When("taps the Show details link")]
        public void WhenITapTheShowDetailsLink()
        {
            var showDetails = _locators.ShowDetails;
            showDetails.Click();
        }

        [Then("user should see the overview of the movie on details page")]
        public void ThenIShouldSeeTheOverviewOfTheMovieOnDetailsPage()
        {
            var overview = _locators.DetailsOverview;
            Assert.True(overview.Text is not null);
        }
    }
}
