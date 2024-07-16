using Webbing.Assignment.Service.LogicService;
using Webbing.Assignment.Service.LogicServices.Abstract;
using Webbing.Assignment.Service.Repository;
using Webbing.Assignment.Service.Repository.Abstract;

const string ORIGIN_POLICY = "MW2.0_CLIENT_ORIGIN_POLICY";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Install the service
builder.Services.AddAppService();

AddRepositories(builder);
AddLogicServices(builder);

builder.Services.AddCors(options =>
{
	options.AddPolicy(
		name: ORIGIN_POLICY,
		builder =>
		{
			builder
				.WithOrigins(new string[] { "http://localhost:4200", "http:/localhost:49983" })
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(ORIGIN_POLICY);

app.MapControllers();

app.Run();

static void AddRepositories(WebApplicationBuilder builder)
{
	builder.Services.AddScoped<INetworkEventRepository, NetworkEventRepository>();
	builder.Services.AddScoped<IUsageRepository, UsageRepository>();
}

static void AddLogicServices(WebApplicationBuilder builder)
{
	builder.Services.AddScoped<IUsageLogicService, UsageLogicService>();
}