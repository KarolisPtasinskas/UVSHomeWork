using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace UVSHomeWork
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<Form1>();

                 //Db
                 //services.AddSingleton<SqlConnection>(_ => new SqlConnection("Server=.;Database=UvsThreads;Trusted_Connection=True;Integrated Security=SSPI;"));

                 ////Repository
                 //services.AddSingleton<MainModelRepository>();

                 ////Services
                 //services.AddSingleton<MainServices>();
                 //services.AddSingleton<TaskService>();
                 //services.AddSingleton<CancellationTokenSource>();

             });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var form1 = services.GetRequiredService<Form1>();
                Application.Run(form1);

            }
        }
    }
}
