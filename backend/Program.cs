var builder = WebApplication.CreateBuilder(args);

//setup localhost
builder.WebHost.ConfigureKestrel(options =>
        {
            // Set HTTPS port => choose any available port you want
            options.ListenLocalhost(5001, listenOptions =>
            {
                listenOptions.UseHttps();
            });

            // Set HTTP port  => choose any available port you want
            options.ListenLocalhost(5000);
        });

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
