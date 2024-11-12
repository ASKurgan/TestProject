﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Infrastructure.ReadModels
{
    public class PCReadModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;   
        public string Description { get; init; } = string.Empty;
        public ICollection<ProductReadModel> Products { get; init; } = [];
    }
}
