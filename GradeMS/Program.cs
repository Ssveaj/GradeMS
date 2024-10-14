

using AutoMapper;
using Core.Interface.DataAccess;
using Core.Interface.UseCases;
using Core.UseCase;
using Core.UseCases;
using GradeMS.Commands;
using GradeMS.MappingProfile;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetStudentGradeCommand>();
builder.Services.AddScoped<SetStudentGradeCommand>();
builder.Services.AddScoped<IGetStudentGradeUseCase, GetStudentGradeUseCase>();
builder.Services.AddScoped<ISetStudentGradeUseCase, SetStudentGradeUseCase>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddDbContext<GradeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GradeDB")));

var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

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
