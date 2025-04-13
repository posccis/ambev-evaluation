namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ICustomer
    {
        public Guid Id { get; set; }
        public string FullName { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
