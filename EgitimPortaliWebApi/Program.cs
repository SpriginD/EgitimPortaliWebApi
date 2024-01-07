using EgitimPortaliWebApi.Business.Services;
using EgitimPortaliWebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string ApiCorsPolicy = "_apiCorsPolicy";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IArticleService, ArticleService>();

builder.Services.AddDbContext<EgitimPortaliContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options => options.AddPolicy(ApiCorsPolicy,
    policy => policy.WithOrigins("https://localhost:7120").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ApiCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
