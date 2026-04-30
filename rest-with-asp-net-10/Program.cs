using rest_with_asp_net_10.Configuration;
using rest_with_asp_net_10.Repository;
using rest_with_asp_net_10.Service;

var builder = WebApplication.CreateBuilder(args);

builder.AddLoggingConfiguration();

builder.Services.AddControllers()
    .AddContentNegotiation();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveCondiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<PersonServiceV2>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
