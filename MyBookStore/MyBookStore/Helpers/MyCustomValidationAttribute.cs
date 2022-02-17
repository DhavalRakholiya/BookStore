using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        //To Make Text Attribute Required need to add constructor 
        //if not passed then we will get compile time(build) error
        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }

        //to make a new atttribute for custom validation
        public string Text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookName = value.ToString();
                if (bookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    //if ErrorMessage attribute contains value then it will be displayed otherwise below default message will be displayed
                    return new ValidationResult(ErrorMessage ??"Book Name does not contain the desired value");
                }
            }
            //if ErrorMessage attribute contains value then it will be displayed otherwise below default message will be displayed
            return new ValidationResult(ErrorMessage ?? "Book Name is empty");
        }
    }
}
