using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. (Removed to show on presentation)
// if (app.Environment.IsDevelopment())
// {
// Documentation configuration
app.UseSwagger();
app.UseSwaggerUI();
// }

// Make easy to test
//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// It's possible use Angular as SPA
string angularFiles = Path.Combine(Directory.GetCurrentDirectory(),
    "../../Frontend/RandomUserConsumer.Front/dist/paschoalotto-random-user-consumer.front/browser"
);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(angularFiles),
    RequestPath = ""
});

app.Run();