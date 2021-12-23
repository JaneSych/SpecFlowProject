Feature: LogIn
	As a user
	I want to log into app

@mytag
Scenario: Successful LogIn with Valid Credentials
	Given I open "http://localhost:5000/Account/Login" url
	When I enters login="user", password="user"
	Then the current page should be "Home page"