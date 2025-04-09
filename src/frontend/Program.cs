using frontend.Hubs;
using RadixJobClient.Api;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(k=>k.AllowSynchronousIO=true);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(c=>{
    c.KeepAliveInterval=System.TimeSpan.FromSeconds(1000);
    c.ClientTimeoutInterval=System.TimeSpan.FromSeconds(1000);
});

builder.Services.AddSingleton<INotificationHubService, NotificationHubService>();
builder.Services.AddKeyedScoped<IComputeService, ComputeService1>("compute1");
builder.Services.AddKeyedScoped<IComputeService, ComputeService2>("compute2");
builder.Services.AddKeyedScoped<IJobApi>("compute1",(sp,_) => {
    return new JobApi(builder.Configuration["JOB_SCHEDULER"]+ "/api/v1/");
});
builder.Services.AddKeyedScoped<IBatchApi>("compute1",(sp,_) => {
    return new BatchApi(builder.Configuration["JOB_SCHEDULER"]+ "/api/v1/");
});
builder.Services.AddKeyedScoped<IJobApi>("compute2",(sp,_) => {
    return new JobApi(builder.Configuration["JOB_SCHEDULER2"]+ "/api/v1/");
});
builder.Services.AddKeyedScoped<IBatchApi>("compute2",(sp,_) => {
    return new BatchApi(builder.Configuration["JOB_SCHEDULER2"]+ "/api/v1/");
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapHub<NotificationHub>("/notificationhub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
