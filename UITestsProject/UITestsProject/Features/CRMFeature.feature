Feature: CRMFeature

Background: 
	Given Home and Actions page is opened

@CrmUiTest
@UIAuthorization
@QuitWebDriver
Scenario: CreateContact
	When I go to 'SalesMarketing' and 'Contacts' page
	Then Contacts page is opened
	When I click on Create button 
	Then New contact page is opened
	When I create a new contact
		| FirstName    | LastName  | Role | CustomersCategory    |
		| Napoleon1769 | Bonaparte | CEO  | Customers, Suppliers |
		And I save a new contact
	Then Created contact page is opened
	  And I check that the contact has proper values

@CrmUiTest
@ApiAuthorization
@QuitWebDriver
Scenario: RunReport
	When I go to 'ReportsSettings' and 'Reports' page
	Then Reports page is opened
		And I find 'Project Profitability' report
	When I go to report 'Project Profitability' page
	Then Spesific report page is opened
	When I run report
	Then Report has returned values

@CrmUiTest
@UIAuthorization
@QuitWebDriver
Scenario: RemoveEventsFromActivityLog
	When I go to 'ReportsSettings' and 'ActivityLog' page
	Then Activity log browser all page is opened
	When I delete first '3' items in the table
	Then The items has been deleted