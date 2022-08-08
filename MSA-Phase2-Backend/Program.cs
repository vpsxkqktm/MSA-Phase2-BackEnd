using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding My Dependencies
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<RandomAnimalDbContext>(optionts => optionts.UseInMemoryDatabase(builder.Configuration["MyDb"]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "My Amazing API";
    options.Version = "V1";

});

if (builder.Environment.IsDevelopment()){
    builder.Services.AddHttpClient(builder.Configuration["AnimalsClientName"], configureClient: client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["AnimalsAddress"]);
    });
}

var app = builder.Build();


// Configure the HTTP request pipeline.

//app.UseSwagger();
//app.UseSwaggerUi();
app.UseOpenApi();
app.UseSwaggerUi3();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
