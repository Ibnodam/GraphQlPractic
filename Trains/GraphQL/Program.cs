using Microsoft.EntityFrameworkCore;
using GraphQL.Data;
using GraphQL;
using HotChocolate.Authorization;
using HotChocolate.Validation;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = GraphQL.Data.Query;
using GraphQL.DAO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<TrainDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarriageRepository, CarriageRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddMutationType<Mutation>().
    AddFiltering().AddSorting();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

app.UseWebSockets();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<TrainDbContext>();
    dbContext?.Database.EnsureCreated();
    DataSeeder.SeedData(dbContext!);
}


app.MapGraphQL("/graphql");
app.Run();

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();
//builder.Services.AddDbContext<TrainDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString
//("DefaultConnection")));
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddFiltering().AddSorting();

//if (app.Environment.IsDevelopment())
//{ 
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//using (var scope = app.Services.CreateScope())
//{ 
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<TrainDbContext>();
//    dbContext?.Database.EnsureCreated();
//    DataSeeder.SeedData(dbContext!);
//}

//app.MapGraphQL("/graphql");
//app.Run();