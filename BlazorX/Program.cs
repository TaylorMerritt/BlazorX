using BlazorX.Components;

var builder = WebApplication.CreateBuilder(args);

// Get the PORT environment variable
var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Set the URLs the application should listen on
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();