using POC.Domain.Validation;

namespace POC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = ValidateDomain(name);
        }

        private string ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name");
            DomainExceptionValidation.When(name.Length < 3, "Name value is too short");
            return name;
        }

        public void Update(string name)
        {
            Name = ValidateDomain(name);
        }

        // Navegation properties
        public ICollection<Product>? Products { get; set; }
    }
}