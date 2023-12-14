using EmployeeManagement.API;
using EmployeeManagement.API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//ENABLE CORS POLICY
string myAllowSpecificOrigin = builder.Configuration.GetValue<string>("CORSPolicy:OriginName");

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ENABLE CORS POLICY
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigin, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENABLE CORS POLICY
app.UseCors(myAllowSpecificOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
