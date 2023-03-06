using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrainTickets.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TrainTickets.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using TrainTickets.Services;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.AddPolicy("ADMIN_ACCESS_ONLY", policy => policy.RequireRole("ADMIN"));
});

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddDbContext<TrainTicketsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrainTicketsContext") ?? throw new InvalidOperationException("Connection string 'TrainTicketsContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;

    var ticketsContext = services.GetRequiredService<TrainTicketsContext>();
    ticketsContext.Database.EnsureCreated();
    DbInitializer.Initialize(ticketsContext);

    var identityContext = services.GetRequiredService<IdentityContext>();
    identityContext.Database.Migrate();
    var adminPassword = builder.Configuration.GetValue<string>("AdminPassword");
    await IdentityDBInitializer.Initialize(services, "H654321e36525hjgjgGGjggjgjgjj4646446464646нананаапгпшрлраппрпроп");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
