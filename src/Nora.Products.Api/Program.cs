using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Configurations;
using Nora.Core.Database.Postgres.EntityFramework.Configurations;
using Nora.Products.Domain.Command.Commands.v1.Products.Create;
using Nora.Products.Domain.Command.Mappers;
using Nora.Products.Domain.Query.Queries.v1.Products.GetById;
using Nora.Products.Infrastructure.Database.EntityFramework;
using Nora.Products.Infrastructure.Database.EntityFramework.Repositories;
using Nora.Products.Api.Middlewares;
using FluentValidation;
using Nora.Products.Domain.Command.Commands.v1.Categories.Create;
using FluentValidation.AspNetCore;
using Nora.Core.Api.MediatR.Extensions;
using Nora.Core.Api.AutoMapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR<CreateProductCommandHandler, GetProductByIdQueryHandler>();
builder.Services.AddEntityFramework<AppDbContext>(builder.Configuration);
builder.Services.AddRepositories<ProductRepository>();
builder.Services.AddAutoMapper<ProductProfile>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

var app = builder.Build();

if (builder.Configuration.GetSection("ExecuteMigration").Get<bool>())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
