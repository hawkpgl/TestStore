using FluentValidation.Results;
using TestStore.Core.DomainObjects;
using TestStore.Core.Entities.Validations;

namespace TestStore.Core.Entities
{
    public class Product : IAggregateRoot
    {
        //Changed the primary key type to facilitate the app usage
        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string OriginalCurrency { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;    
            Name = name;
            Price = price;
            OriginalCurrency = "USD";

            IsValid();
        }

        public bool IsValid()
        {
            ValidationResult = new ProductValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}