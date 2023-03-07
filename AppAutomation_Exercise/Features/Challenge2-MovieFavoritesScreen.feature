Feature: MovieFavoritesScreen

Searching for a movie from the main screen using search and then navigating to its details page.

@movieFavoritesScreen
Scenario: Verify the favorites feature is working properly by navigating to the favorites screen
	Given user is on the main screen with list of movies
	When user open the movie details page for movie name "Avatar" and marks the movie as favorite
	And user navigates to favorites screen via three dot menu
	Then the user should see the movie "Avatar" listed on the Favorites screen
