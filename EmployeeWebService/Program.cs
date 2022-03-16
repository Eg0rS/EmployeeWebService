using DataAccess.Data;
using DataAccess.DataBaseAccess;
using EmployeeWebService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataBaseAccess, DataBaseAccess>();
builder.Services.AddSingleton<IEmployeeData, EmployeeData>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.CofigureApi();


app.Run();
