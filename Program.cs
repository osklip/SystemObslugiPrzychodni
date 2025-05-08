using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace SystemObslugiPrzychodni
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IPasswordMailer, PasswordMailer>();
            services.AddSingleton<IConfiguration>(config);

            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<LoginPanel>();

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<LoginPanel>());
        }
    }
}