using StockDAL;
using StockDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL
{
    public class UniqueNameAttribute : ValidationAttribute
    {             
        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    AppDbContext app = new AppDbContext();
        //    if (value == null)
        //    {
        //        return ValidationResult.Success; // Or handle the null value validation
        //    }

        //    var name = value.ToString();
        //    var appa = app.Stores.FirstOrDefault(i => i.Name == name);

        //    if (appa == null)
        //    {
        //        return ValidationResult.Success;
        //    }

        //    return new ValidationResult($"{name} already exists. Please try another name.");
        //}
    }

}
