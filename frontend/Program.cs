using frontend.Hubs;
using RadixJobClient.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(c=>{
    // c.KeepAliveInterval=System.TimeSpan.FromSeconds(15);
    // c.ClientTimeoutInterval=System.TimeSpan.FromSeconds(60);
});

builder.Services.AddSingleton<INotificationHubService, NotificationHubService>();
builder.Services.AddScoped<IComputeService, ComputeService>();
builder.Services.AddScoped<IJobApi>(sp => {
    return new JobApi(builder.Configuration["JOB_SCHEDULER"]+ "/api/v1/");
});
builder.Services.AddScoped<IBatchApi>(sp => {
    return new BatchApi(builder.Configuration["JOB_SCHEDULER"]+ "/api/v1/");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
