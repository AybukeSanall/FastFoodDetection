using FastFoodClassification.Services;
using FastFoodClassification;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var path = "D:\\Projects\\FastFoodDetection\\FastFoodClassification\\Scenarios\\MLModel1.mlnet";

builder.Services.AddPredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput>().FromFile(path);
builder.Services.AddScoped<IFastFoodDetectionService, FastFoodDetectionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json","Fast Food Detection API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
