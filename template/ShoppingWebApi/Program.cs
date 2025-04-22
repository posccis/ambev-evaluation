using Ambev.DeveloperEvaluation.ORM;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information("Starting web application");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
    )
);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.RegisterDependencies();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseBasicHealthChecks();

app.MapControllers();

app.Run();
