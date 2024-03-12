using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Validation.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Class, AllowMultiple = false)]
    public class NoHomerValidator : ValidationAttribute
    {
        public string ForbiddenName { get; set; }

        public NoHomerValidator(string forbiddenName)
        {
            ForbiddenName = forbiddenName;
        }

        public override bool IsValid(object? value)
        {
            if (value?.ToString()?.ToLower().Contains(ForbiddenName?.ToLower() ?? string.Empty) ?? false)
            {
                return false;
            }
            return true;
        }
    }
}
