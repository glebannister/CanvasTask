Feature: CRMFeatureForParallel

@CrmUiTest
@UIAuthorization
@QuitWebDriver
Scenario: RemoveEventsFromActivityLog
	When I go to 'ReportsSettings' and 'ActivityLog' page
	Then Activity log browser all page is opened
	When I delete first '3' items in the table
	Then The items has been deleted
