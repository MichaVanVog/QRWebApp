using Microsoft.EntityFrameworkCore;
using QR.Db;
using QRWebApp.Jobs;
using QRWebApp.Services;
using Quartz;
using Telegram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("QuickRestoContext")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductsInDbRepository, ProductsInDbRepository>();
builder.Services.AddTransient<ITextSender, TextSender>();
builder.Services.AddTransient<IDaysCountFromDb, DaysCountFromDb>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("TelegramMessageSender");
    q.AddJob<TelegramMessageSender>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("TelegramMessageSender-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 0 10 * * ?")
    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

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
