using Microsoft.OpenApi.Models;
using PASCHOALOTTO_Random_User_Consumer.Utils;
using RandomUserConsumer.Application;
using RandomUserConsumer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
    {
        swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Random User Consumer - API", Version = "v1" });
        swagger.SchemaFilter<SwaggerFilter>();
    }
);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddApplicationServcices();
builder.Services.AddInfrastructureServices(Env.DatabaseEnvLoad(builder.Environment));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

// Make easy to test
//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

#region SPA configuration
// It's possible use Angular as SPA
// string angularFiles = Path.Combine(Directory.GetCurrentDirectory(),
//     "../../Frontend/RandomUserConsumer.Front/dist/paschoalotto-random-user-consumer.front/browser"
// );

// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(angularFiles),
//     RequestPath = ""
// });
#endregion

app.Run();