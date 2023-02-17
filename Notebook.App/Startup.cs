using Microsoft.EntityFrameworkCore;
using Notebook.App.Data;
using Notebook.App.Domain.Interfaces;
using Notebook.App.Services;


namespace Notebook.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AppMappingProfile));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<INotebookService, NotebookService>();
        
        services.AddDbContext<NotebookDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MSSQLDBSetting")));
        
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        
        services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        {
            app.UseSwagger();
        
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        //app.UseCors(police => police.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}