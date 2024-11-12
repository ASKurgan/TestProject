using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Dtos;
using TestProject.Domain.Base;
using TestProject.Infrastructure.DbContexts;
using static TestProject.Domain.Base.Error;

namespace TestProject.Infrastructure.Queries.Products.GetProductById
{
    public class GetByIdProductQuery
    {
        private readonly ReadDbContext _dbContext;

        public GetByIdProductQuery(ReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetByIdProductResponse>> Handle(GetByIdProductRequest request, CancellationToken ct)
        {
            var product = await _dbContext.ProductReadModels
                                 .FirstOrDefaultAsync(p => p.Id == request.ProductId, ct);

            if (product == null) 
            {
                return Errors.General.NotFound(request.ProductId);
            }

            var productCategory = await _dbContext.PCReadModels
                                        .FirstOrDefaultAsync(pc => pc.Id == product.ProductCategoryId, ct);

            if (productCategory == null) 
            {
                return Errors.General.NotFound(product.ProductCategoryId);
            }

            var productDto = new ProductDto(
                product.Id,
                product.Name,
                productCategory.Name,
                product.Description,
                product.Price,
                product.Amount,
                product.DateCreate,
                product.ExpirationDate);

            return new GetByIdProductResponse(productDto);
        }
    }
}
