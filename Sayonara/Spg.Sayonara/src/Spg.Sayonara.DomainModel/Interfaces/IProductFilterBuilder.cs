﻿using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Interfaces
{
    public interface IProductFilterBuilder
    {
        IProductFilterBuilder ApplyNameContainsFilter(string namePart);

        IQueryable<Product> Build();
    }
}
