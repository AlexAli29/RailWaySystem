using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using TrainTickets.Models;
using TrainTickets.Areas.Identity.Data;

namespace TrainTickets.Authorization {
    public class TicketIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Ticket> {
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketIsOwnerAuthorizationHandler(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Ticket ticket) {
            if (context.User == null || ticket == null) {
                return Task.CompletedTask;
            }

            var user = _userManager.GetUserAsync(context.User).Result;
            if (requirement.Name == "READ" && (ticket.FirstName + " " + ticket.LastName == user.FirstName + " " + user.LastName)) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
