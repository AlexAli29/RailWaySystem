using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace TrainTickets.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser {
    [Required]
    [DisplayName("First name")]
    public string FirstName { get; set; }
    [Required]
    [DisplayName("Last name")]
    public string LastName { get; set; }
    [Required]
    public string IIN { get; set; }
    [DisplayName("Phone number")]
    public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    public ICollection<IdentityUserRole<string>> UserRoles { get; set; }

    public string GetFullName() {
        return FirstName + " " + LastName;
    }
}

