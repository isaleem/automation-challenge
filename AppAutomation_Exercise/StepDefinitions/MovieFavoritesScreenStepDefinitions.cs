using AppAutomation_Exercise.Support;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace AppAutomation_Exercise.StepDefinitions
{
    [Binding]
    public class MovieFavoritesScreenStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly AndroidDriver<AppiumWebElement> _driver;
        private readonly ElementLocators _locators;
        public MovieFavoritesScreenStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
            _locators = new ElementLocators(_driver);
        }
        [When(@"user open the movie details page for movie name ""([^""]*)"" and marks the movie as favorite")]
        public void WhenIOpenTheDetailsPageOfAMovieLikeAndMarkTheMovieAsFavorite(string movieName)
        {
            var search_bar = _locators.SearchBar;
            search_bar.Click();
            search_bar.SendKeys(movieName);
            var searchresults = _locators.SearchResult;
            searchresults[0].Click();
            _locators.FavoritesStar.Click();
            _locators.BackScreenArrow.Click();
        }

        [When("user navigates to favorites screen via three dot menu")]
        public void WhenINavigateToFavoritesScreenViaMenu()
        {
            _locators.ThreeDotMenu.Click();
            var menuItems = _locators.MenuFav;
            menuItems[3].Click();
        }

        [Then(@"the user should see the movie ""([^""]*)"" listed on the Favorites screen")]
        public void ThenIShouldSeeTheMovieListedOnTheFavoritesScreen(string movieName)
        {
            var listFavMovies =_locators.FavMovies;
            listFavMovies[0].Click();
            Assert.True(_locators.DetailPage.Text == movieName);
            _locators.FavoritesStar.Click();
        }
    }
}
