using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tracker.Data.Commands;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Data.Queries;
using Tracker.Data.Repository;
using Tracker.Data.ResponseModels;
using Tracker.Domain.Repository;
using Tracker.Domain.Service;
using Tracker.Domain.Service.ExpenseFilter;
using Tracker.Domain.Service.ExpenseService;
using Tracker.Domain.UseCase;
using Tracker.Domain.UseCase.Budget;
using Tracker.Domain.UseCase.Mails;
using Tracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseFilter, ExpenseFilter>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDueRepository, DueRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IExpenseMailRepository, ExpenseMailRepository>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();

builder.Services.AddScoped<IRequestHandler<GetAllDuesRequest, List<Due>?>, GetAllDuesUseCase>();
builder.Services.AddScoped<IRequestHandler<GetDueByIdRequest, Due>, GetDueByIdUseCase>();
builder.Services.AddScoped<IRequestHandler<AddDueCommand, Guid>, AddDueUseCase>();
builder.Services.AddScoped<IRequestHandler<UpdateCommand, Guid>, UpdateDueByIdUseCase>();
builder.Services.AddScoped<IRequestHandler<DeleteCommand, Guid>, DeleteDueByIdUseCase>();

builder.Services.AddScoped<IRequestHandler<GetAllMailsRequest, List<ExpenseMail>>, GetAllMailsUseCase>();
builder.Services.AddScoped<IRequestHandler<AddMailsCommand, Unit>, AddMailsUseCase>();
builder.Services.AddScoped<IRequestHandler<CreateBudgetCommand, Guid>, CreateBudgetCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateBudgetCommand, Unit>, UpdateBudgetCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteBudgetCommand, Unit>, DeleteBudgetCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetBudgetByIdQuery, Budget>, GetBudgetByIdQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetBudgetsByCategoryAndDateQuery, IEnumerable<Budget>>, GetBudgetsByCategoryAndDateQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetBudgetsBetweenDatesQuery, IEnumerable<BudgetWithCategoryDetails>>,  GetBudgetsBetweenDatesQueryHandler>();

builder.Services.AddDbContext<TrackerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var key = builder.Configuration.GetValue<string>("AuthSettings:Secret");


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
