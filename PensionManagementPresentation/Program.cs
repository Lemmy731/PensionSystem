using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PensionManagementApplication.IService;
using PensionManagementApplication.Service;
using PensionManagementInfrastructure.CalculatessBenfit;
using PensionManagementInfrastructure.contribution;
using PensionManagementInfrastructure.DataAccess;
using PensionManagementInfrastructure.IRepository;
using PensionManagementInfrastructure.Repository;
using PensionManagementPresentation.Helpers;
using PensionManagementPresentation.JobConfig;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using ApiVersion = Asp.Versioning.ApiVersion;

var builder = WebApplication.CreateBuilder(args);

//connection string
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddScoped<IContributionProcessService, ContributionProcessService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IMemberService, MemeberService>();

builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<IContributionProcess, ContributionProcess>();
builder.Services.AddScoped<IContributionStatement, ContributionStatement>();
builder.Services.AddScoped<IGenerateStatement, GenerateStatement>();
builder.Services.AddScoped<IContributionStatement, ContributionStatement>();
builder.Services.AddScoped<IValidateContribution, ValidateContribution>();

builder.Services.AddScoped<IValidateContribution, ValidateContribution>();
builder.Services.AddScoped<IBenefitEligiblity, BenefitEligiblity>();
builder.Services.AddScoped<IMonthlyInterest, MonthlyInterest>();
builder.Services.AddScoped<IGenerateStatement, GenerateStatement>();
builder.Services.AddScoped<IBenefitCalculation, BenefitCalculation>();
builder.Services.AddScoped<Config>();

//hangfire config
builder.Services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddHangfireServer();

//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();

using (var scope = app.Services.CreateScope())
{
    var config = scope.ServiceProvider.GetRequiredService<Config>();
    config.Configure();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
