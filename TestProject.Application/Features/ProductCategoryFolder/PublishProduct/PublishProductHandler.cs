using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Interfaces.DataAccess;
using TestProject.Domain.Base;
using TestProject.Domain.Entities;

namespace TestProject.Application.Features.ProductCategoryFolder.PublishProduct
{ 
    public class PublishProductHandler
    {
        private readonly IProductCategoryRepository _productCategory;
        private readonly ITransaction _transaction;

        public PublishProductHandler(IProductCategoryRepository productCategory, ITransaction transaction)
        {
            _productCategory = productCategory;
            _transaction = transaction;
        }

        public async Task<Result<Guid>> Handle(PublishProductCommand productCommand, CancellationToken ct)
        {
            var pcResult = await _productCategory.GetByName(productCommand.PCName, ct);

            if (pcResult.IsFailure) 
            {
               return pcResult.Error;
            }

            var pc = pcResult.Value;

            var productResult = Product.Create(productCommand.Name,
                                         productCommand.Description,
                                         productCommand.ExpirationDate,
                                         productCommand.Price,
                                         productCommand.Amount,
                                         productCommand.DateCreate);
            if (productResult.IsFailure) 
            {
                return productResult.Error;
            }

            var product = productResult.Value;

            pc.AddProduct(product);

            await _transaction.SaveChangesAsync(ct);
            
            return pc.Id; 
        }
    }
    
}
