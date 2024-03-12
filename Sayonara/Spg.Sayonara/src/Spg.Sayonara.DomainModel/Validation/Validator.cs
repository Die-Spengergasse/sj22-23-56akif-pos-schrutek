using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Validation
{
    public class Validator<TEntity>
        where TEntity : class
    {
        public bool Validate(TEntity entity)
        {
            bool isValidSum = true;

            PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                IEnumerable<Attribute> attributes = property.GetCustomAttributes();
                foreach (Attribute attribute in attributes)
                {
                    if (attribute?.GetType()?.BaseType?.Name != nameof(ValidationAttribute))
                    {
                        continue;
                    }
                    ValidationAttribute validationAttribute = (ValidationAttribute)attribute;
                    bool isValid = validationAttribute.IsValid(property.GetValue(entity));
                    if (!isValid)
                    {
                        isValidSum = false;
                    }
                }
            }
            return isValidSum;
        }
    }
}
