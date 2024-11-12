using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Dtos;

namespace TestProject.Infrastructure.Queries.Products.DraftProductResponse
{
    public class DraftQuery
    {
        public DraftResponse DraftHandle()
        {
            var draftDto = new DraftDto("Автомобиль Volvo v90cc", 
                                        "Хороший автомобиль Volvo v90cc " +
                                        "класса S, роскошный и надёжный универсал");
            return new DraftResponse(draftDto);

        }
    }
}
