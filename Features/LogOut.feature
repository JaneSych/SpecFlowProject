Feature: LogOut
	As a user
	I want to logout of app

@mytag
Scenario: Logout of app
	Given I open app as an authorized user
	When I click on "Logout" btn
	Then the current page is "Login"