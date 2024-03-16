global using Microsoft.EntityFrameworkCore;
using Firebase.Auth.Providers;
using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using MyTMS.Data.DataContext;
using MyTMS.Data.Repository;
using MyTMS.Service.UserService;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionString = builder.Configuration.GetConnectionString("DBConnection");

var firebaseProjectName = "mytms-auth";
builder.Services.AddSingleton(FirebaseApp.Create());
builder.Services.AddFirebaseAuthentication();
builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
    ApiKey = "AIzaSyAfFghM3mbPXbUvBr03JVc-jYnrUKK-kxA",
    AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
    Providers = new FirebaseAuthProvider[]
    {
        new EmailProvider(),
        new GoogleProvider()
    }
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(provider => new MyTMSDBContextFactory(provider.GetService<IDbContextFactory<MyTMSDBContext>>(), provider.GetService<MyTMSDBContext>()));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContextFactory<MyTMSDBContext>(options =>
{
    if (!builder.Environment.IsProduction())
        options.EnableSensitiveDataLogging(true);

    options.UseSqlServer(sqlConnectionString);
    options.EnableDetailedErrors();
}, ServiceLifetime.Scoped);

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
