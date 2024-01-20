using System.Reflection;
using DangerousObjectsBLL.Configure;
using DangerousObjectsBLL.Profiles;
using DangerousObjectsBLL.Services;
using DangerousObjectsBLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DangerousObjectsDAL.Data;
using DangerousObjectsDAL.Repositories;
using DangerousObjectsDAL.Repositories.Interfaces;
using DangerousObjectsInforming.Extensions;
using DangerousObjectsInforming.Filters;
//using DangerousObjectsInforming.Filters;
using DangerousObjectsInforming.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtConfig>(config => config.Secret = builder.Configuration["Secrets:JwtConfig"]);
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddAutoMapper(typeof(DangerousObjectProfile));
builder.Services.AddScoped<IDangerousObjectService, DangerousObjectService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IDangerousObjectRepo, DangerousObjectRepo>();
builder.Services.AddScoped<IMessageRepo, MessageRepo>();
builder.Services.AddControllers(config => 
        { config.Filters.Add<CustomExceptionFilterAttribute>(); })
    .AddFluentValidation(config => 
        config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();