using fbk_api.Data;
using fbk_api.Repository;
using fbk_api.Services;
using fbk_api.Shared;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IReadDatFileShared, ReadDatFileShared>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IPurchasesRepository, PurchasesRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options => options
    .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8080", "http://localhost:4200" })
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.MapControllers();


app.Run();


