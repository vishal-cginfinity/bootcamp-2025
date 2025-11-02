 using ECommerceApi.Data;
    using Microsoft.EntityFrameworkCore;
 
    var builder = WebApplication.CreateBuilder(args);
 
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString)
    );

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowReactApp",
            policy =>
            {

                policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
    });
 
 
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
 
    var app = builder.Build();
 

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
 
    app.UseHttpsRedirection();

    app.UseCors("AllowReactApp");
 
    app.UseAuthorization();
 
    app.MapControllers();
 
    app.Run();