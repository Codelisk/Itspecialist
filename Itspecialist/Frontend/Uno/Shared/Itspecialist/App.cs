using Itspecialist.Api;
using Itspecialist.Services;
using Prism.DryIoc;
using Uno.UI;

namespace Itspecialist
{
    public partial class App : PrismApplication
    {
        protected override void ConfigureHost(IHostBuilder builder)
        {
            builder
                .UseAuthentication(b => b.AddCustom())
#if DEBUG
                    // Switch to Development environment when running in DEBUG
                    .UseEnvironment(Environments.Development)
#endif
                    .UseSerialization()
                    .UseLogging(configure: (context, logBuilder) =>
                    {
                        // Configure log levels for different categories of logging
                        logBuilder
                            .SetMinimumLevel(
                                context.HostingEnvironment.IsDevelopment() ?
                                    LogLevel.Information :
                                    LogLevel.Warning)

                            // Default filters for core Uno Platform namespaces
                            .CoreLogLevel(LogLevel.Warning);

                    }, enableUnoLogging: true)
                    .UseConfiguration(configure: configBuilder =>
                        configBuilder
                            .EmbeddedSource<App>()
                            .Section<AppConfig>()
                    )
                    // Enable localization (see appsettings.json for supported languages)
                    .UseLocalization()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddApi<AuthenticationService>();
                    });
        }

        protected override UIElement CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAccounts.Views.Uno.ModuleInitializer>();
        }
    }
}
