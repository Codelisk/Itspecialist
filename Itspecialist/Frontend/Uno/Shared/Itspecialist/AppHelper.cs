using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itspecialist
{
    public static class AppHelper
    {
        public static IHostBuilder AddAuthentication(this IHostBuilder builder)
        {
            return builder.UseAuthentication(auth=> {
                auth.AddWeb(options =>
                {
                });
            });
            return builder.UseAuthentication(auth =>
        auth.AddCustom(custom =>
                custom
                    .Login((sp, dispatcher, credentials, cancellationToken) =>
                    {
                        // TODO: Write code to process credentials that are passed into the LoginAsync method
                        //if (credentials?.TryGetValue(nameof(LoginViewModel.Username), out var username) ?? false &&
                        //    !username.IsNullOrEmpty())
                        //{
                        //    // Return IDictionary containing any tokens used by service calls or in the app
                        //    credentials ??= new Dictionary<string, string>();
                        //    credentials[TokenCacheExtensions.AccessTokenKey] = "SampleToken";
                        //    credentials[TokenCacheExtensions.RefreshTokenKey] = "RefreshToken";
                        //    credentials["Expiry"] = DateTime.Now.AddMinutes(5).ToString("g");
                        //    return ValueTask.FromResult<IDictionary<string, string>?>(credentials);
                        //}

                        // Return null/default to fail the LoginAsync method
                        return ValueTask.FromResult<IDictionary<string, string>?>(default);
                    })
                    .Refresh((sp, tokenDictionary, cancellationToken) =>
                    {
                        // TODO: Write code to refresh tokens using the currently stored tokens
                        if ((tokenDictionary?.TryGetValue(TokenCacheExtensions.RefreshTokenKey, out var refreshToken) ?? false) &&
                            !refreshToken.IsNullOrEmpty() &&
                            (tokenDictionary?.TryGetValue("Expiry", out var expiry) ?? false) &&
                            DateTime.TryParse(expiry, out var tokenExpiry) &&
                            tokenExpiry > DateTime.Now)
                        {
                            // Return IDictionary containing any tokens used by service calls or in the app
                            tokenDictionary ??= new Dictionary<string, string>();
                            tokenDictionary[TokenCacheExtensions.AccessTokenKey] = "NewSampleToken";
                            tokenDictionary["Expiry"] = DateTime.Now.AddMinutes(5).ToString("g");
                            return ValueTask.FromResult<IDictionary<string, string>?>(tokenDictionary);
                        }

                        // Return null/default to fail the Refresh method
                        return ValueTask.FromResult<IDictionary<string, string>?>(default);
                    }), name: "CustomAuth")
                    );
        }
    }
}
