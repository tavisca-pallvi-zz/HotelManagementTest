Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User wants to get hotel by providing a particular id
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	And User provided valid Id '<id>' to get hotel details
	When User calls GetHotelById '<id>' api
	Then Hotel with id '<id>' should be returned in the response
Examples: 
| id | name   |
| 9  | hotel1 |

Scenario: User wants to get all added hotels
	Given User provided valid Id '10'  and 'Hyatt'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	And User provided valid Id '11'  and 'Gopal'for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api 
	When User calls get all hotels
	Then All added Hotels should be returned in the response
	                      

