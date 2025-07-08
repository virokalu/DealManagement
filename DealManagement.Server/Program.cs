using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Repositories;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Domain.Validators;
using DealManagement.Server.Mapping;
using DealManagement.Server.Persistence.Contexts;
using DealManagement.Server.Persistence.Repositories;
using DealManagement.Server.Resources;
using DealManagement.Server.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DealContext>(options =>
    options.UseSqlServer(connectionString));

// Registering the FluentValidation validators
builder.Services.AddScoped<IValidator<SaveDealResource>, DealValidator>();
builder.Services.AddScoped<IValidator<SaveHotelResource>, HotelValidator>();

// Registering the DealService and DealRepository with dependency injection
builder.Services.AddScoped<IDealService, DealService>();
builder.Services.AddScoped<IDealRepository, DealRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper configuration
builder.Services.AddAutoMapper(cgf =>
{
    cgf.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzgzMzgyNDAwIiwiaWF0IjoiMTc1MTg4NjEwMiIsImFjY291bnRfaWQiOiIwMTk3ZTQ4YmEwZGU3YjYwYjA0N2I1YjRiMTljMDkyMyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxanpqOHMwM3pudmt2Yno2NXoycWg3cnd4Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.0jENx9FLUkLs96xnLdRQqjLnizF2SBU9J6RGvnePIx7-zv9GBHiJQYd_pCYXQdX53RdzyOjMSut77ZmTFOrdhz6y2TIzhpEhqpLMEMJ-s2TFdKEWHrpdNDka2_GEBlYZ-pTn562aEHaBAJtGVg-ZHCs5WjVvQ36H1cCPhXrJseiI5N8L-BPoh2ztHy2wS14VgjyBaqdVgmxkMeksVJlNDbS040ySVsWFsHk_v7SF5a7pZv-4wJzA042Okz1VHW75BLBfc86AKEQRH_2OcvX2rJnMM1iT8QLipALNYQiTJtp_TPovNJgBpieIRY3OfCIjByz1dX70ZdlbN0j0xxWmaQ";
    cgf.AddProfile<ModelToResourceProfile>();
    cgf.AddProfile<ResourceToModelProfile>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
