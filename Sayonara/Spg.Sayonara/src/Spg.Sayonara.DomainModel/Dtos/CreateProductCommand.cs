using Spg.Sayonara.DomainModel.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Dtos
{
    public record CreateProductCommand(
        [NoHomerValidator("homer", ErrorMessage = "homer darf nicht rein")]
        [StringLength(maximumLength: 10, ErrorMessage = "name vieeeeeeeeeel zu lang")]
        string Name,
        string Description, 
        DateTime ExpiryDate,
        int CategoryId
        );
}
