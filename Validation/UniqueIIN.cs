using System.ComponentModel.DataAnnotations;
using TrainTickets.Areas.Identity.Data;

namespace TrainTickets.Validation {
    public class UniqueIIN : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var context = (IdentityContext)validationContext.GetService(typeof(IdentityContext));
            string iin = (string)value;
            if (context.Users.Any(u => u.IIN == iin)) {
                return new ValidationResult("IIN " + iin + " is already taken");
            }
            return ValidationResult.Success;
        }
    }
}
