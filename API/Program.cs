using System.Text;
using Application.Behavior;
using Application.Books.Commands.Create;
using Application.Books.Commands.Update;
using Application.People.Commands.Create;
using Application.People.Commands.Update;
using Application.Products.Commands.Create;
using Application.Products.Commands.Update;
using Application.Products.Queries.GetAll;
using Application.Stores.Commands.AddBook;
using Application.Stores.Commands.Create;
using Application.Stores.Commands.Update;
using Application.Transaction;
using Confluent.Kafka;
using Domain.Books;
using Domain.BookStores;
using Domain.People;
using Domain.Products;
using Domain.Stores;
using Domain.User;
using FluentValidation.AspNetCore; 
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TokenHandler = Application.Token.TokenHandler;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreatePersonCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateStoreCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdatePersonCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateStoreCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<AddBookToStoreCommandValidator>();

    });

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<TokenHandler>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IBookStoreRepository, BookStoreRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issure"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorCacheBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatorCacheInvalidationBehavior<,>));

builder.Services.AddTransient(typeof(DbTransactionHandlerMiddleware<>));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); 

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<DbTransactionHandlerMiddleware<DataContext>>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 

app.Run(); 