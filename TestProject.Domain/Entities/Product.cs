using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Base;
using TestProject.Domain.Interfaces.Auditable;
using static TestProject.Domain.Base.Error;

namespace TestProject.Domain.Entities
{
    public class Product : Entity, IAuditable
    {
        private Product() { }    
        private Product(string name, 
                        string description, 
                        DateTimeOffset expirationDate, 
                        decimal price, 
                        long amount, 
                        DateTimeOffset dateCreate)
        {
            Name = name;
            Description = description;
            ExpirationDate = expirationDate;
            Price = price;
            Amount = amount;
            DateCreate = dateCreate;
        }

        public string Name { get; private set; } = string.Empty;
        public string Description { get;  private set; } = string.Empty;
        
        public DateTimeOffset ExpirationDate { get; private set; }

        public decimal Price { get; private set; }

        public long Amount { get; private set; }

        public DateTimeOffset DateCreate { get; private set; }
        
        public DateTimeOffset CreatedAt { get ; set; } // = DateTimeOffset.Now;
        public Guid CreatedBy { get; set ; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }

        public static Result<Product> Create(string name, 
                                             string description,
                                             DateTimeOffset expirationDate,
                                             decimal price,
                                             long amount,
                                             DateTimeOffset dateCreate)
        
        {

           if (name.IsEmpty() || name.Length > Constraints.MEDIUM_TITLE_LENGTH
                || name.Length < Constraints.MINIMUM_TITLE_LENGTH)
                return Errors.General.InvalidLength(nameof(name));

            if (description.IsEmpty() || description.Length > Constraints.LONG_TITLE_LENGTH
                || description.Length < Constraints.MINIMUM_TITLE_LENGTH)
                return Errors.General.InvalidLength(nameof(description));

            if (price == 0)
                return Errors.General.ValueIsRequired();

            if (amount == 0)
                return Errors.General.ValueIsRequired();

            return new Product(name,
                               description,
                               expirationDate,
                               price,
                               amount,
                               dateCreate);
        }
    }
}
