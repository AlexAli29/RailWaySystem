using System.ComponentModel.DataAnnotations;
using TrainTickets.Areas.Identity.Data;

namespace TrainTickets.Validation {
    public class UniquePhoneNumber : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var context = (IdentityContext)validationContext.GetService(typeof(IdentityContext));
            string phoneNumber = (string)value;
            if (context.Users.Any(u => u.PhoneNumber == phoneNumber)) {
                return new ValidationResult("Phone number " + phoneNumber + " is already taken");
            }
            return ValidationResult.Success;
        }
    }
}
