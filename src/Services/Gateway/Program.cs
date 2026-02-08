
using Aspire.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

// Aspire Service Defaults
builder.AddServiceDefaults();

// YARP Reverse Proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

//ONLY FOR DEV: Ignore SSL errors when proxying to services with self-signed certs (e.g., in Docker)
//builder.Services.AddReverseProxy()
//  .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
//  .ConfigureHttpClient((context, handler) =>
   // {
        // Ignore certificate errors (only for Dev!)
     //   handler.SslOptions.RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
//    });

// JWT-Auth (zentral!)
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// YARP Middleware
app.MapReverseProxy();

app.MapDefaultEndpoints();
app.Run();
