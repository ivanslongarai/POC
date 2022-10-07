using POC.Domain.Validation;

namespace POC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private void ValidateDomain(string name, string description, decimal price)
        {
            Id = Guid.NewGuid();
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name");
            DomainExceptionValidation.When(name.Length < 3, "Name value is too short");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description");
            DomainExceptionValidation.When(price <= 0, "Invalid Price");

            Name = name;
            Description = description;
            Price = price;
        }

        public Product(string name, string description, decimal price, bool active, DateTime createdAt)
        {
            ValidateDomain(name, description, price);
            Active = active;
            CreatedAt = createdAt;
        }    

        public void Update(string name, string description, decimal price, bool active, DateTime createdAt, int categoryId)
        {
            ValidateDomain(name, description, price);
            Active = active;
            CreatedAt = createdAt;
            CategoryId = categoryId;
        }              

        // Navegation properties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}