using ObliOPG4OPG.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

        }));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<CarRepo>(new CarRepo());

var app = builder.Build();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
