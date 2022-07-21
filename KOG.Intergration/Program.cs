using KOG.Intergration.Auth;
using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.BusinessService.Interfaces.Caching;
using KOG.Intergration.BusinessService.Services;
using KOG.Intergration.BusinessService.Services.Caching;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.DataService.Services;
using KOG.Intergration.Models;
using KOG.Intergration.Models.UsersConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<AdminLogin>(builder.Configuration.GetSection("UsersConfig:AdminLogin"));
builder.Services.Configure<UserLogin>(builder.Configuration.GetSection("UsersConfig:UserLogin"));
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();       // Thêm dịch vụ dùng bộ nhớ lưu cache (session sử dụng dịch vụ này)
builder.Services.AddSession();                      // Thêm  dịch vụ Session, dịch vụ này cunng cấp Middleware
builder.Services.AddDbContext<KOGIntergrationDBContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("KOGIntergrationDBContext")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<KOGIntergrationDBContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();
//Business Services
builder.Services.AddTransient<IJwtUtils, JwtUtils>();
builder.Services.AddTransient<IUserBusinessService, UserBusinessService>();
builder.Services.AddTransient<IRoleBusinessService, RoleBusinessService>();
builder.Services.AddTransient<IBoPhanBusinessService, BoPhanBusinessService>();
builder.Services.AddTransient<INhanVienBusinessService, NhanVienBusinessService>();
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<ICacheProvider, CacheProvider>();
//Data Services
builder.Services.AddTransient<IUserDataService, UserDataService>();
builder.Services.AddTransient<IRoleDataService, RoleDataService>();
builder.Services.AddTransient<IBoPhanDataService, BoPhanDataService>();
builder.Services.AddTransient<INhanVienDataService, NhanVienDataService>();


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Note: Required when using example providers
    c.ExampleFilters();

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KOG Rosy API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(filePath);
    c.EnableAnnotations();
});


//builder.Services.AddMvc().AddNewtonsoftJson(option =>
//{
//    option.SerializerSettings.ContractResolver = new DefaultContractResolver();
//});

builder.Services.AddAuthentication(options =>
{
    // When targeting OpenIddict 3.0, OpenIddictValidationAspNetCoreDefaults
    // must be used instead of OpenIddictValidationDefaults.
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]))
    };
});

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
//builder.Services.AddSwaggerExamplesFromAssemblyOf<BoPhanExample>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Documentation v1");
        }
    );

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Swagger Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.UseRouting();

app.Run();
