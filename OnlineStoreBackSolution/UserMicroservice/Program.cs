using Microsoft.EntityFrameworkCore;
using UserBLL.Contracts.Service;
using UserBLL.Service;
using UserDAL;
using UserDAL.Contracts.Repositories;
using UserDAL.Repositories;
using Microsoft.Extensions.Configuration;
using UserBLL.Contracts.Helpers;
using UserBLL.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnectionString"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDESEncryptionHelper, DESEncryptionHelper>();
builder.Services.AddScoped<IHashHelper, HashHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
