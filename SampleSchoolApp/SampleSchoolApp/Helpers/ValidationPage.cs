using FluentValidation;
using SampleSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSchoolApp.Helpers
{
   public class ValidationPage : AbstractValidator<SchoolModel>
    {
        public ValidationPage()
        {
            RuleFor(x => x.SchoolName).NotNull().Length(8, 20);
            RuleFor(x => x.PhoneNumber).NotNull().MinimumLength(10);
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Email.");
            RuleFor(x => x.Address).NotNull().Length(8, 20);
        }
    }
}
