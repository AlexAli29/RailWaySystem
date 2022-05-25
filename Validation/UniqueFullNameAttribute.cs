using System.ComponentModel.DataAnnotations;
using TrainTickets.Areas.Identity.Data;
using TrainTickets.Areas.Identity.Pages.Account;

namespace TrainTickets.Validation {
    public class UniqueFullNameAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var context = (IdentityContext)validationContext.GetService(typeof(IdentityContext));
            RegisterModel.InputModel userIM = (RegisterModel.InputModel)value;
            string fullName = userIM.GetFullName();
            if (context.Users.Any(u => u.FirstName + " " + u.LastName == fullName)) {
                return new ValidationResult("Name '" + fullName + "' is already taken");
            }
            return ValidationResult.Success;
        }
    }
}
