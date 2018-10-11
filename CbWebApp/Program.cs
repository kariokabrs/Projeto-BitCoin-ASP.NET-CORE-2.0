using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CbWebApp
{
    /// <summary>
    /// Classe responsável pelo início do sistema web.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                           .UseStartup<Startup>()
                           .UseKestrel(options =>
                           {
                               options.AddServerHeader = false;
                           })
                           .UseSetting("https_port", "8080")
                           .Build();
    }
}

