Feature: MovieViewDetails

Searching for a movie from the main screen using search and then navigating to its details page.

@movieDetails
Scenario: View Details of a Movie
	Given user is on the main screen with list of movies
	When user searches for a movie whose name starts with "Hello"
	And user selects the second option from the result list of movies in search box
	And taps the Show details link
	Then user should see the overview of the movie on details page
