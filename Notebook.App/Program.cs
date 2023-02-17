namespace Notebook.App;

using System.Text;

public class Program
{
    private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(
            (hostingContext, builder) =>
            {
                builder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json", false, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                        true)
                    .AddEnvironmentVariables();
                
                builder.AddEnvironmentVariables();
            })
        .ConfigureWebHostDefaults(
            webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    public static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        CreateHostBuilder(args).Build().Run();
    }
}