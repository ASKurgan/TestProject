using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Interfaces.DataAccess;
using TestProject.Domain.Base;
using TestProject.Domain.Entities;
using static TestProject.Domain.Base.Error;

namespace TestProject.Application.Features.ProductCategoryFolder
{
    public class PCHandler
    {
        private readonly IProductCategoryRepository _productCategory;
        private readonly ITransaction _transaction;

        public PCHandler(IProductCategoryRepository productCategory, ITransaction transaction)
        {
            _productCategory = productCategory;
            _transaction = transaction;
        }

        public async Task<Result<Guid>> Handle(PCCommand command, CancellationToken ct)
        {
            var pcResult = await _productCategory.GetByName(command.Name, ct);
            
            if (pcResult.IsSuccess) 
            {
                return Errors.General.PCAlreadyExists();
            }

            // var pc = pcResult.Value;

            pcResult = ProductCategory.Create(command.Name, command.Description);

            if (pcResult.IsFailure)
            {
                return pcResult.Error;
            }

            var pc = pcResult.Value;

            await _productCategory.Add(pc, ct);
            await _transaction.SaveChangesAsync(ct);
            
            return pc.Id;
        }
    }
}
