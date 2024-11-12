using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestProject.Domain.Base.Error;
using TestProject.Domain.Base;
using TestProject.Infrastructure.DbContexts;
using TestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TestProject.Application.Features.ProductCategoryFolder;

namespace TestProject.Infrastructure.Repositories
{
       public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly WriteDbContext _dbContext;

        public ProductCategoryRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ProductCategory productCategory, CancellationToken ct)
        {
            await _dbContext.ProductCategories.AddAsync(productCategory, ct);
        }

        public async Task<IReadOnlyList<ProductCategory>> GetAll(CancellationToken ct)
        {
            var productCategories = await _dbContext.ProductCategories
                                                    .ToListAsync(cancellationToken: ct);

            return productCategories;
        }

        public async Task<Result<ProductCategory>> GetById(Guid id, CancellationToken ct)
        {
            var productCategory = await _dbContext.ProductCategories
                .Include(pc => pc.Products)
                .FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken: ct);

            if (productCategory is null)
                return Errors.General.NotFound(id);

            return productCategory;
        }

        public async Task<Result<ProductCategory>> GetByName(string name, CancellationToken ct)
        {
            var productCategory = await _dbContext.ProductCategories
                .Include(pc => pc.Products)
                .FirstOrDefaultAsync(pc => pc.Name == name, cancellationToken: ct);

            if (productCategory is null)
                return Errors.General.NotFound();

            return productCategory;
        }
    }

}
