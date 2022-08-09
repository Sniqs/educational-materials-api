var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddDbContext<MaterialsContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:MaterialsDb"]));
builder.Services.AddRepositoriesToDi();
builder.Services.AddServicesToDi();
builder.Services.AddMiddlewareToDi();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
builder.Services.AddSwaggerGenWithCustomOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterCustomMiddleware();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
