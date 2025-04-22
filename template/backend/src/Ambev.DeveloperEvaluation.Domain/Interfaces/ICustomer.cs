using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ICustomer
    {
        Guid Id { get; set; }
        string FullName { get => (FirstName + ' ' + LastName); }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Document { get; set; }
        DateTime DateOfBirth { get; set; }
        DateTime CreatedOn { get => DateTime.Now; }
        DateTime UpdatedOn { get => DateTime.Now; }
        string Password { get; set; }
        bool Active { get; set; }
        List<Address> Addresses { get; set; }
        List<Order> Orders { get; set; }
    }
}
