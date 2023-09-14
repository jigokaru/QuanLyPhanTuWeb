using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWebWeb.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using QuanLyPhanTuWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;

                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //Tu Cap Token
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,

                        //Ky vao Token
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        //IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                        ClockSkew = TimeSpan.Zero
                    };
                });

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("ADMINANDMEMBER", policy =>
        policy.RequireClaim(
             ClaimTypes.Role, new string[] { "ADMIN", "MEMBER" }
            )
    );
    option.AddPolicy("MEMBER", policy => policy.RequireClaim(
        ClaimTypes.Role, "MEMBER"
        ));
    option.AddPolicy("ADMIN", policy => policy.RequireClaim(
     ClaimTypes.Role, "ADMIN"
    ));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IEmailServices, EmailServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
