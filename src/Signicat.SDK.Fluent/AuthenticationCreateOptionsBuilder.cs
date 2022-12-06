using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Signicat.Authentication;

[assembly: InternalsVisibleTo("Signicat.SDK.Tests")]
[assembly: InternalsVisibleTo("Signicat.SDK.Internal")]

namespace Signicat;

public class AuthenticationCreateOptionsBuilder
{
    private readonly AuthenticationCreateOptions _options = new();

    public static AuthenticationCreateOptionsBuilder Create()
    {
        return new AuthenticationCreateOptionsBuilder();
    }

    /// <summary>
    ///     (optional) Only needed if you have multiple themes setup on the same account.
    ///     <param name="themeId">Id for the Theme </param>
    /// </summary>
    public AuthenticationCreateOptionsBuilder WithThemeId(string themeId)
    {
        _options.ThemeId = themeId;
        return this;
    }

    /// <summary>
    ///     The type of flow to use.
    /// </summary>
    /// <param name="flow">One of: <c>redirect</c>, or <c>headless</c>.</param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithFlow(AuthenticationFlow flow)
    {
        _options.Flow = flow;
        return this;
    }

    /// <summary>
    ///     The language to use for the identification process. Defaults to `en`
    /// </summary>
    /// <param name="language">
    ///     <see cref="Signicat.Constants.Languages" />
    /// </param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithLanguage(string language = "en")
    {
        _options.Language = language;
        return this;
    }

    /// <summary>
    ///     Request additional information about the user.
    ///     One of: <c>firstname</c>, <c>lastname</c>, <c>dateofbirth</c> or <c>nin</c>.
    /// </summary>
    /// <param name="requestedAttributes">
    ///     <see cref="Signicat.Constants.RequestedAttributes" />
    /// </param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithRequestedAttributes(params string[] requestedAttributes)
    {
        _options.RequestedAttributes = requestedAttributes;
        return this;
    }

    /// <summary>
    ///     A list of eID providers that can be used for identification. If not specified, the user will be able to chose from
    ///     all eIDs associated with your Signicat account.
    ///     <param name="allowedProviders">
    ///         <see cref="Signicat.Constants.AllowedProviderTypes" />
    ///     </param>
    /// </summary>
    public AuthenticationCreateOptionsBuilder WithAllowedProviders(params string[] allowedProviders)
    {
        _options.AllowedProviders = allowedProviders;
        return this;
    }

    /// <summary>
    ///     (Optional) Add your internal reference for the session
    /// </summary>
    /// <param name="externalReference">Your external reference for the session.</param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithExternalReference(string externalReference)
    {
        _options.ExternalReference = externalReference;
        return this;
    }

    /// <summary>
    ///     (Required for redirect) The urls to redirect the user to after the authentication process is done
    /// </summary>
    /// <param name="success">The URL that the user is redirected to after a successful identification.</param>
    /// <param name="abort">The URL that the user is redirected to if the session is aborted by the user.</param>
    /// <param name="error">The URL that the user is redirected to if something goes wrong.</param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithCallbackUrls(string success, string abort, string error)
    {
        _options.CallbackUrls = new CallbackUrls {Abort = abort, Error = error, Success = success};
        return this;
    }

    /// <summary>
    ///     Lifetime of session in seconds.
    /// </summary>
    /// <param name="seconds">How many seconds should this session live</param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithSessionLifetime(int seconds)
    {
        _options.SessionLifetime = seconds;
        return this;
    }

    /// <summary>
    ///     (Required for headless, otherwise optional) Prefilled input values, use prefill user input to simplify the user
    ///     journey
    /// </summary>
    /// <param name="email">Prefill the user's email.</param>
    /// <param name="mobile">Prefill the user's mobile number. Must be prefixed with country code.</param>
    /// <param name="nin">Prefill the user's national identification number.</param>
    /// <param name="username">Prefill the user's username.</param>
    /// <param name="dateOfBirth">
    ///     Prefill the user's date of birth (YYYY-MM-DD). For Norwegian BankID on Mobile the DDMMYY
    ///     format is also supported.
    /// </param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithPrefilledInput(string? email = null, string? mobile = null,
        string? nin = null, string? username = null, string? dateOfBirth = null)
    {
        _options.PrefilledInput = new PrefilledInput
        {
            Email = email,
            Mobile = mobile,
            Nin = nin,
            Username = username,
            DateOfBirth = dateOfBirth
        };
        return this;
    }

    /// <summary>
    ///     Builds the authentication request after all properties are set
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public AuthenticationCreateOptions Build()
    {
        if (_options.Flow == AuthenticationFlow.Redirect)
        {
            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.Abort))
            {
                throw new ValidationException("Abort url must be set when using flow redirect");
            }

            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.Error))
            {
                throw new ValidationException("Error url must be set when using flow redirect");
            }

            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.Success))
            {
                throw new ValidationException("Success url must be set when using flow redirect");
            }
        }

        if (_options.Flow == AuthenticationFlow.Headless)
        {
            if (string.IsNullOrWhiteSpace(_options.PrefilledInput?.Email) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Mobile) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Nin) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Username) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.DateOfBirth)
               )
            {
                throw new ValidationException("One or more prefilled fields must be set when using flow headless");
            }
        }

        return _options;
    }

    internal AuthenticationCreateOptions BuildWithOutValidation()
    {
        return _options;
    }
}