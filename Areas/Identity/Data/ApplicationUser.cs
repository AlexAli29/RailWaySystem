﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TrainTickets.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string IIN { get; set; }
    public ICollection<IdentityUserRole<string>> UserRoles { get; set; }

    public string GetFullName() {
        return FirstName + " " + LastName;
    }
}

