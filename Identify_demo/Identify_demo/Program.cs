using Identify_demo.Core.Domain.Entities;
using Identify_demo.Core.Domain.RepositoryContracts;
using Identify_demo.Infrastructure.DbContexts;
using Identify_demo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
	.AddEntityFrameworkStores<UsersDbContext>()
	.AddUserStore<UserStore<ApplicationUser, ApplicationRole, UsersDbContext, Guid>>()
	.AddRoleStore<RoleStore<ApplicationRole, UsersDbContext, Guid>>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.Run();
