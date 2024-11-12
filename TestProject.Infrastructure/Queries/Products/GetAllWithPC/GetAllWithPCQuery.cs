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

namespace TestProject.Infrastructure.Queries.Products.GetAllWithPC
{
    public class GetAllWithPCQuery
    {
        private readonly ReadDbContext _dbContext;

        public GetAllWithPCQuery(ReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetAllWithPCResponse>> Handle(CancellationToken ct)
        {
            

            var productsWithPCDto = await _dbContext.PCReadModels
                          .Include(pc => pc.Products)
                          .SelectMany(pc => pc.Products,
                                      (pc, p) => new { PC = pc, Product = p, })
                          .Where(x => x.PC.Id == x.Product.ProductCategoryId)
                          .Select(p => new ProductWithPCDto()
                          {
                              ProductId = p.Product.Id,
                              ProductName = p.Product.Name,
                              ProductDescription = p.Product.Description,
                              ProductCategoryId = p.PC.Id,
                              PCDescrption = p.PC.Description,
                              PCName = p.PC.Name,
                              ProducPrice = p.Product.Price.ToString(),
                              ProductAmount = p.Product.Amount, 
                              ProductDateCreate = p.Product.DateCreate,
                              ProductExpirationDate = p.Product.ExpirationDate
                          })
                          .ToListAsync(ct);


            

            if (productsWithPCDto == null)
            {
                return Errors.General.NotFound();
            }

            return new GetAllWithPCResponse(productsWithPCDto);
        }
    }
}
