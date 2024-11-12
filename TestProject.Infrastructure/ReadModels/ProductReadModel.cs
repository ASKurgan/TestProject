using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Infrastructure.ReadModels
{
    public class ProductReadModel
    {
        public Guid Id { get; init; }
        public Guid ProductCategoryId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }

        public DateTimeOffset DateCreate { get; init; }

        public DateTimeOffset ExpirationDate { get; init; }
        public long Amount { get; init; }

    }
}
