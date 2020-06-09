Feature: TimenMaterial
	As a admin of TurnUp portal
	I would like to manage time and material record portal effectively

@mytag
Scenario: Create a Time and Material record successfully
	Given I have logged in to the turnup portal successfully
	And I navigate to time and material page
	When I create a time and material record
	Then the record should be created successfully

Scenario: Edit a time and material record successfully
	Given I have logged in to the turnup portal successfully
	And I navigate to time and material page
	When I edit a time and material record in the page
	Then the record should be edited successsfully

Scenario: Delete an existing time and material record
	Given I have logged in to the turnup portal successfully
	And I navigate to time and material page
	When I delete an existing time and material from the page
	Then The record should be deleted successsfully

Scenario Outline: Create multiple time and material record
	Given I have logged in to the turnup portal successfully
	And I navigate to time and material page
	When I create time and material records for below <code> and <description> 
	Then The records should be created with below values <code> and <description> successfully 
	Examples: 
	| code  |   description     |
	| green  |   color |
	| red |  color |
		
	
	



