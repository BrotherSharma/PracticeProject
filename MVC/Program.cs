using MVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
builder.Services.AddSingleton<IStudentRepositories, StudentRepositories>();
builder.Services.AddSingleton<IUseriRepositories, UserRepositories>();
builder.Services.AddSingleton<CommanRepositories>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication("MyCookieAuthenticationSchema")
    .AddCookie("MyCookieAuthenticationSchema",options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/AccessDenied";
    });
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


=======
builder.Services.AddSingleton<IStudentRepositories,StudentRepositories>();
builder.Services.AddSingleton<NpgsqlConnection>((serviceProvider) =>
{
    // Use the IConfiguration service to get the connection string
    var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});
>>>>>>> 62bf9f2105ca49904989f86ada82045cde9ee880

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
