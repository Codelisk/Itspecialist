using Foundation.Api.Models;
using Itspecialist.Api;
using Itspecialist.Api.Apis;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using Itspecialist.Services;
using Uno.UI;
using static System.Net.WebRequestMethods;

namespace Itspecialist
{
    public partial class App : PrismApplication
    {
        protected override void ConfigureApp(IApplicationBuilder builder)
        {
            base.ConfigureApp(builder);
#if DEBUG
            builder.Window.EnableHotReload();
            //ClientHotReloadProcessor.CurrentWindow = builder.Window;
#endif
        }
        protected override void ConfigureHost(IHostBuilder builder)
        {
            builder
                .UseAuthentication(b => b.AddCustom(custom =>
                {
                    custom.Refresh(
                        async (sp, tokenCache, credentials, cancellationToken) =>
                        {
                            var tokenProvider = sp.GetService<ITokenProvider>();
                            var token = await tokenCache.AccessTokenAsync();
                            var rToken = await tokenCache.RefreshTokenAsync();
                            tokenProvider.UpdateCurrentToken(token, rToken);
                            return default;
                        });
                    custom.Login(
                    async (sp, dispatcher, tokenCache, credentials, cancellationToken) =>
                    {
                        var auth = sp.GetService<IAuthRepository>();
                        var tokenProvider = sp.GetService<ITokenProvider>();
                        credentials.TryGetValue("email", out var email);
                        credentials.TryGetValue("password", out var password);
                        var authenticated = await auth.LoginAsync(new AuthPayload { email = email, password = password });
                        tokenProvider.UpdateCurrentToken(authenticated.accessToken, authenticated.refreshToken);
                        credentials["AccessToken"] = authenticated.accessToken;
                        credentials["RefreshToken"] = authenticated.refreshToken;
                        return credentials;
                    });
                }))
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
                        services.AddSingleton<IDispatcher, Dispatcher>();
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
            moduleCatalog.AddModule<ModuleShell.Views.Uno.ModuleInitializer>();
            moduleCatalog.AddModule<ModuleDashboard.Views.Uno.ModuleInitializer>();
            moduleCatalog.AddModule<ModuleList.Views.Uno.ModuleInitializer>();
        }
    }
}
