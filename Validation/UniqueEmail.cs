using System.ComponentModel.DataAnnotations;
using TrainTickets.Areas.Identity.Data;

namespace TrainTickets.Validation {
    public class UniqueEmail : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var context = (IdentityContext)validationContext.GetService(typeof(IdentityContext));
            string email = (string) value;
            if (context.Users.Any(u => u.Email == email)) {
                return new ValidationResult("Email '" + email + "' is already taken");
            }
            return ValidationResult.Success;
        }
    }
}
