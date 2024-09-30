using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapGet("/", () => "Ocelot API Gateway is running!");
await app.UseOcelot();
app.Use(async (context, next) =>
{
	try
	{
		await next.Invoke();
	}
	catch (Exception ex)
	{
		// Hatalarý burada loglayabilirsin
		Console.WriteLine($"Exception: {ex.Message}");
	}
});
app.Run();
