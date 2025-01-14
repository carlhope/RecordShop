using RecordShop.Common.Models;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess
{
    public static class MyValidator<T> where T : class, IEntity
    {
        public static bool IsValid(T source) 
        {
        var validationContext = new ValidationContext(source);
        var validationResults = new List<ValidationResult>();
        return Validator.TryValidateObject(source, validationContext, validationResults, true);
        }
    }
}
