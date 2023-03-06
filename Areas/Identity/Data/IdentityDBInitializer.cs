using TrainTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TrainTickets.Areas.Identity.Data {
    public class IdentityDBInitializer {
        public static async Task Initialize(IServiceProvider serviceProvider, string adminPassword) {
            using (var context = new TrainTicketsContext(
                    serviceProvider.GetRequiredService<DbContextOptions<TrainTicketsContext>>())) {

                // Password is set with the following:
                // dotnet user-secrets set AdminPassword <password>

                var admin = new ApplicationUser {
                    UserName = "splitter4774@gmail.com",
                    Email = "splitter4774@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Bakhyt",
                    LastName = "Kaskarov",
                    IIN = "870101495026",
                    PhoneNumber = "+87053689433",
                    PhoneNumberConfirmed = true
                };
                string adminID = await EnsureUser(serviceProvider, admin, adminPassword);
                string adminRole = "ADMIN";
                await EnsureRole(serviceProvider, adminID, adminRole);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, 
                                                        ApplicationUser user, string password) {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var dbUser = await userManager.FindByNameAsync(user.UserName);
            if (dbUser == null) {
                dbUser = user;
                await userManager.CreateAsync(dbUser, password);
            }

            if (dbUser == null) {
                throw new Exception("The password is probably not strong enough!");
            }

            return dbUser.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string userID, string role) {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role)) {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(userID);
            if (user == null)
            {
                throw new Exception("The password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
