

using Core.Interface.DataAccess;
using Core.Interface.UseCases;
using Core.UseCase;
using GradeMS.Commands;
using Infrastructure.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GradeCommand>();
builder.Services.AddScoped<IGetStudentGradeUseCase, GetStudentGradeUseCase>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();


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
