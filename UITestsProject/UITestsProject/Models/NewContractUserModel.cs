using UITestsProject.Enums;

namespace UITestsProject.Models
{
    internal class NewContractUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BusinessRoleEnum Role { get; set; }
        public string CustomersCategory { get; set; }
    }
}
