// when application loads in memory, program.cs file get executed
// start the exec from main method
// when app loads in memory , it is a console app
// convert console app to web app

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// we will add additional services that we want to load in app
builder.Services.AddControllersWithViews();

// you have to add all the servives before Build method 
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
