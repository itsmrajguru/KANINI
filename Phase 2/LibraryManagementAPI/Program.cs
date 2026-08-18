using LibraryManagementAPI.Data;
using LibraryManagementAPI.Helpers;
using LibraryManagementAPI.Interfaces;
using LibraryManagementAPI.Middleware;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//here we configure a asp.net application using builder
var builder = WebApplication.CreateBuilder(args);

// Register all controllers in the project
builder.Services.AddControllers();

// Swagger UI with JWT Authorize button (the lock icon)
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Library Management API",
        Version = "v1"
    });

    // Add Bearer token input to Swagger UI
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter your JWT token here. Example: Bearer <your-token>"
    });

    // Apply the lock icon to all protected routes
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configure EF Core with Pomelo MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))));

//added JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// added cors to accept request from any frotend like swagger, postman or React
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

//These are the Dependency Injections
/* Dependency Injection : 
It is a design pattern  Where the class doesn't create objects it depends on,
instaed the dependencies that are already created as services and listed in the interface
are directly provided directly by the .NET's DI container in the program.cs */
builder.Services.AddScoped<IBookService, DatabaseBookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IFineService, FineService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IReportService, ReportService>();

// JwtHelper builds tokens
builder.Services.AddSingleton<JwtHelper>();

/* This is the line responsible for building the whole application using the configurations */
var app = builder.Build();

// Catch all unhandled exceptions and return clean JSON error
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DevPolicy");

/* Middlewares */
app.UseAuthentication();
app.UseAuthorization();

//this mapcontroller maps the HTTP request to the appropriate controller
app.MapControllers();

//it is smimiliar to app.listen(PORT)
app.Run();
