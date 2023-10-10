using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UITestsProject.Models;

namespace UITestsProject.Transformations
{
    [Binding]
    internal class Transformations
    {
        [StepArgumentTransformation("(.*)")]
        public NewContractUserModel NewContractUserModelTransformation(Table table) 
        {
            return table.CreateInstance<NewContractUserModel>();
        }

        [StepArgumentTransformation("(.*)")]
        public IEnumerable<ContactUserModel> ContractUserModelsTransformation(Table table)
        {
            return table.CreateSet<ContactUserModel>();
        }
    }
}
