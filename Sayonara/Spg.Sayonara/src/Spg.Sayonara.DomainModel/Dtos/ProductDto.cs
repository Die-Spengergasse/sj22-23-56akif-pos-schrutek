﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Dtos
{
    public record ProductDto(string Name, string Description, DateTime ExpiryDate, Guid Guid);
}
