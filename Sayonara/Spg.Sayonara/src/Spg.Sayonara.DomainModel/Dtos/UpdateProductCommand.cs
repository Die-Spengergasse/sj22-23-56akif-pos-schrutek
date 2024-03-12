using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Dtos
{
    public record UpdateProductCommand(
        [StringLength(maximumLength: 3, ErrorMessage = "name vieeeeeeeeeel zu lang")]
        string Name,
        string Description,
        DateTime ExpiryDate,
        int CategoryId
    );
}
