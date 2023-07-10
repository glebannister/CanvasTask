Feature: CRMFeature

Background: 
	Given I navigate to CRM login page
		And I pass the authorization
		And Home and Actions page is opened

@UIAuthorization
@QuiteWebDriver
Scenario: CreateContact
	When I go to 'SalesMarketing' and 'Contacts' page
	Then Contacts page is opened
	When I click on Create button 
	Then New contact page is opened
	When I create a new contact
		| FirstName | LastName  | Role | CustomersCategory    |
		| Napoleon6  | Bonaparte | CEO  | Customers, Suppliers |
		And I save a new contact
	Then Created contact page is opened
	  And I check that the contact has proper values

@UIAuthorization
@QuiteWebDriver
Scenario: RunReport
	#When I go to 'ReportsSettings' and 'Reports' page
	Then Reports page is opened
	Then I find 'Project Profitability' report
	When I go to report 'Project Profitability' page