using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Base;
using TestProject.Domain.Interfaces.Auditable;
using static TestProject.Domain.Base.Error;

namespace TestProject.Domain.Entities
{
    public class ProductCategory : Entity
    {
        private ProductCategory() {}
        private ProductCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public IReadOnlyList<Product> Products => _products;
        private readonly List<Product> _products = [];

        public Result<Guid> AddProduct(Product product)
        {
            if (product == null) 
            {
                return Errors.General.NotFound();   
            }
            if (_products.Any(p => p.Name == product.Name))
            {
                return Errors.General.ProductAlreadyExists(product.Name);
            }

            _products.Add(product);

            return product.Id;
        }

        public Result<Guid> DeleteProduct(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == p.Id);
            if (product is null)
                return Errors.General.NotFound();
            var productId = product.Id;
            _products.Remove(product);
            return productId;
           
        }

        public static Result<ProductCategory> Create(string name, string description) 
        {

            if (name.IsEmpty() || name.Length > Constraints.SHORT_TITLE_LENGTH 
                || name.Length < Constraints.MINIMUM_TITLE_LENGTH)
                return Errors.General.InvalidLength(nameof(name));

            if (description.IsEmpty() || description.Length > Constraints.LONG_TITLE_LENGTH 
                || description.Length < Constraints.MINIMUM_TITLE_LENGTH)
                return Errors.General.InvalidLength(nameof(description));
           

            return new ProductCategory(name, description);
        }
    }
}
