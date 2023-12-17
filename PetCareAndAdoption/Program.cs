using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.Integration;
using Microsoft.Bot.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetCareAndAdoption.Data;
using PetCareAndAdoption.Helpers;
using PetCareAndAdoption.Repositories;
using PetCareAndAdoption.Repositories.AuthenticationRepositories;
using PetCareAndAdoption.Repositories.PetTypeRepositories;
using PetCareAndAdoption.Repositories.PostRepositories;
using System.Text;
using Microsoft.Bot.Builder.BotFramework;
using Microsoft.Bot.Builder.Dialogs;
using PetCareAndAdoption.Bots.Accessories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet care and adoption API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader()));
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
        policy.RequireRole("Admin"));
});
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetCareAndAdoption"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>(); 
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPetTypeRepository, PetTypeRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidAudience= builder.Configuration["JWT:ValidAudience"],
        ValidIssuer= builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["JWT:Secret"])) 
    };
});
//Add bot service
builder.Services.AddBot<BotService>(options =>
{
    options.CredentialProvider = new ConfigurationCredentialProvider(builder.Configuration);

    var conversationState = new ConversationState(new MemoryStorage());
    options.State.Add(conversationState);

});

builder.Services.AddSingleton(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<BotFrameworkOptions>>().Value;
    var conversationState = options.State.OfType<ConversationState>().FirstOrDefault();

    var accessors = new BotAccessors(conversationState)
    {
        DialogStateAccessor = conversationState.CreateProperty<DialogState>(BotAccessors.DialogStateAccessorName),
        //FlowerShopStateStateAccessor = conversationState.CreateProperty<FlowerShopState>(BotAccessors.FlowerShopBotStateAccessorName)
    };

    return accessors;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Care and Adoption API");
    c.RoutePrefix = string.Empty;
});
app.UseBotFramework();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
