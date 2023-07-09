using System.Diagnostics.Contracts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UITestsProject.Models;

namespace UITestsProject.Transformations
{
    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation("(.*)")]
        public ContractUserModel ContractUserModelTransformation(Table table) 
        {
            return table.CreateInstance<ContractUserModel>();
        }
    }
}
