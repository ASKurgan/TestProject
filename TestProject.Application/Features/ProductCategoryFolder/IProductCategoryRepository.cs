using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Base;
using ProductCategory = TestProject.Domain.Entities.ProductCategory;

namespace TestProject.Application.Features.ProductCategoryFolder
{
    public interface IProductCategoryRepository
    {
        Task Add(ProductCategory productCategory, CancellationToken ct);
        Task<Result<ProductCategory>> GetById(Guid id, CancellationToken ct);
        Task<Result<ProductCategory>> GetByName(string name, CancellationToken ct);
        Task<IReadOnlyList<ProductCategory>> GetAll(CancellationToken ct);
    }
}
