using System.Reflection;
// using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddOpenApiDocument();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Contact API",
        Description = "ASP.NET Core Web API to manage contacts",
        // TermsOfService = "",
        // Contact = "",
        // LicenseUrl = "",
        // LicenseName = "", 
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// builder.Services.AddOpenApiDocument(options => {
//      options.PostProcess = document =>
//      {
//          document.Info = new OpenApiInfo
//          {
//              // Version = "v3",
//              Title = "ToDo API",
//              Description = "An ASP.NET Core Web API for managing ToDo items",
//              TermsOfService = "https://example.com/terms",
//              Contact = new OpenApiContact
//              {
//                  Name = "Example Contact",
//                  Url = "https://example.com/contact"
//              },
//              License = new OpenApiLicense
//              {
//                  Name = "Example License",
//                  Url = "https://example.com/license"
//              }
//          };
//      };
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    // app.UseReDoc(options => 
    // {
    //     options.Path = "/redoc";
    // });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
