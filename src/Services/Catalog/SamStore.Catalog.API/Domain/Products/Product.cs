using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Catalog.API.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string Image { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, string description, decimal value, string image)
        {
            Name = name;
            Description = description;
            Value = value;
            Image = image;
        }

        public void ChangeName(string newName)
        {
            if (newName == Name) return;

            if (string.IsNullOrWhiteSpace(newName))
                throw new Exception("Cannot change name using a new empty name.");

            Name = newName;
        }

        public void ChangeDescription(string newDescription)
        {
            if (Description == newDescription) return;

            Description = newDescription;
        }

        public void ChangeQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new Exception("Cannot change the quantity to 0 or minus 0.");

            Quantity = newQuantity;
        }

        public void ChangeImage(string newImage)
        { 
            if (Image == newImage) return;

            Image = newImage;
        }

        public void ChangeValue(decimal newValue)
        {
            if (newValue < 0)
                throw new Exception("Cannot change the product's value to a new value minus zero");
            Value = newValue;
        }
    }
}
