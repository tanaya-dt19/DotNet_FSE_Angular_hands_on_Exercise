using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var key = builder.Configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(key))
        {
            throw new InvalidOperationException("JWT Key is not configured");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception is SecurityTokenExpiredException)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var response = new { message = "Token has expired. Please login again." };
                    return context.Response.WriteAsJsonAsync(response);
                }
                else if (context.Exception is SecurityTokenInvalidSignatureException)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var response = new { message = "Token signature is invalid." };
                    return context.Response.WriteAsJsonAsync(response);
                }
                else if (context.Exception is SecurityTokenException)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    var response = new { message = "Token is invalid." };
                    return context.Response.WriteAsJsonAsync(response);
                }

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var defaultResponse = new { message = "Authentication failed." };
                return context.Response.WriteAsJsonAsync(defaultResponse);
            },

            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var response = new { message = "You are not authorized. Please provide a valid token." };
                return context.Response.WriteAsJsonAsync(response);
            },

            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                var response = new { message = "Access denied. You do not have the required role." };
                return context.Response.WriteAsJsonAsync(response);
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();