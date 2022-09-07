using Microsoft.EntityFrameworkCore;
using MSA_Phase3_Backend.Dal;
using MSA_Phase3_Backend.Domain.Interfaces;
using MSA_Phase3_Backend.Domain.Models;
using MSA_Phase3_Backend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding My Dependencies
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddDbContext<RandomAnimalDbContext>(optionts => optionts.UseInMemoryDatabase("RandAnimal"));
builder.Services.AddScoped<IRandomAnimalServices, RandomAnimalServices>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "msa";
    options.Version = "V1";

});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpClient(builder.Configuration["AnimalsClientName"], configureClient: client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["AnimalsAddress"]);
    });
}
if (builder.Environment.IsProduction())
{
    builder.Services.AddHttpClient(builder.Configuration["AnimalsClientName"], configureClient: client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["AnimalsAddress"]);
    });
}

var app = builder.Build();

var db = app.Services.CreateScope().ServiceProvider.GetService<RandomAnimalDbContext>();

//default input for testing
var animal = new RandomAnimal
{
    id = 1,
    name = "test",
    latine_name = "test",
    animal_type = "test",
    active_time = "test",
    length_min = 0,
    length_max = 0,
    weight_min = 0,
    weight_max = 0,
    diet = "test",
    geo_range = "test",
    habitat = "test",
    image_link = "text",
    lifespan = 0,

};

db.RandAnimal.Add(animal);
db.SaveChanges();

// Configure the HTTP request pipeline.

//app.UseSwagger();
//app.UseSwaggerUi();
app.UseOpenApi();
app.UseSwaggerUi3();


app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGraphQL("/graphql");
app.MapControllers();
app.Run();



