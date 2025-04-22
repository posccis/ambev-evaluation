using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public AddressState State { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string ReferencePoint { get; set; }
    }
}
