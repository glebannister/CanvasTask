using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UITestsProject.Models;

namespace UITestsProject.Transformations
{
    [Binding]
    internal class Transformations
    {
        [StepArgumentTransformation("(.*)")]
        public ContractUserModel ContractUserModelTransformation(Table table) 
        {
            return table.CreateInstance<ContractUserModel>();
        }
    }
}
