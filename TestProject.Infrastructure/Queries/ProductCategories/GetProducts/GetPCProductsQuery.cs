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

namespace TestProject.Infrastructure.Queries.ProductCategories.GetProducts
{
    public class GetPCProductsQuery
    {
        private readonly ReadDbContext _dbContext;

        public GetPCProductsQuery(ReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetPCProductsResponse>> Handle(
                                                                GetPCProductsRequest request,
                                                                CancellationToken ct)
        {
            var pcReadModel = await _dbContext.PCReadModels
                                .FirstOrDefaultAsync(pc => pc.Id == request.ProductCategoryId);

            if (pcReadModel == null)
            {
                return Errors.General.NotFound(request.ProductCategoryId);
            }



            var productReadModels = await _dbContext.ProductReadModels
                                    .Where(p => p.ProductCategoryId == request.ProductCategoryId)
                                    .ToListAsync(ct);


            var productDtos = productReadModels.Select(product => new ProductDto(
                product.Id,
                product.Name,
                pcReadModel.Name,
                product.Description,
                product.Price,
                product.Amount,
                product.DateCreate,
                product.ExpirationDate))
                .ToList();

            return new GetPCProductsResponse(productDtos);
           
        }
    }
}
