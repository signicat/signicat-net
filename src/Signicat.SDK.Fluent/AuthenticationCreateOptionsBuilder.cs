using System.ComponentModel.DataAnnotations;
using Signicat.Authentication;

namespace Signicat.SDK.Fluent;

public class AuthenticationCreateOptionsBuilder
{
    private readonly AuthenticationCreateOptions _options = new AuthenticationCreateOptions();
    
    public static AuthenticationCreateOptionsBuilder Create()
    {
        return new AuthenticationCreateOptionsBuilder();
    }

    public AuthenticationCreateOptionsBuilder WithThemeId(string themeId)
    {
        _options.ThemeId = themeId;
        return this;
    }
    
    public AuthenticationCreateOptionsBuilder WithFlow(AuthenticationFlow flow)
    {
        _options.Flow = flow;
        return this;
    }
    
    /// <summary>
    /// The language to use for the identification process. Defaults to `en`
    /// </summary>
    /// <param name="language"><see cref="Signicat.Constants.Languages"/></param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithLanguage(string language = "en")
    {
        _options.Language = language;
        return this;
    }
    
    /// <summary>
    /// Request additional information about the user.
    /// One of: <c>firstname</c>, <c>lastname</c>, <c>dateofbirth</c> or <c>nin</c>.
    /// </summary>
    /// <param name="requestedAttributes"><see cref="Signicat.Constants.RequestedAttributes"/></param>
    /// <returns></returns>
    public AuthenticationCreateOptionsBuilder WithRequestedAttributes(params string[] requestedAttributes)
    {
        _options.RequestedAttributes = requestedAttributes;
        return this;
    }
    
    /// <summary>
    /// A list of eID providers that can be used for identification. If not specified, the user will be able to chose from all eIDs associated with your Signicat account.
    /// <param name="allowedProviders"><see cref="Signicat.Constants.AllowedProviderTypes"/></param>
    /// </summary>
    public AuthenticationCreateOptionsBuilder WithAllowedProviders(params string[] allowedProviders)
    {
        _options.AllowedProviders = allowedProviders;
        return this;
    }
    
    public AuthenticationCreateOptionsBuilder WithExternalReference(string externalReference)
    {
        _options.ExternalReference = externalReference;
        return this;
    }
    
    public AuthenticationCreateOptionsBuilder WithCallbackUrls(string success, string abort, string error)
    {
        _options.CallbackUrls = new CallbackUrls(){AbortUrl = abort, ErrorUrl = error, SuccessUrl = success};
        return this;
    }
    
    public AuthenticationCreateOptionsBuilder WithSessionLifetime(int seconds)
    {
        _options.SessionLifetime = seconds;
        return this;
    }
    
    public AuthenticationCreateOptionsBuilder WithPrefilledInput(string? email = null, string? mobile = null, 
        string? nin = null, string? username=null, string? dateOfBirth = null)
    {
        _options.PrefilledInput = new PrefilledInput()
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
    /// Builds the authentication request after all properties are set
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public AuthenticationCreateOptions Build()
    {
        if (_options.Flow == AuthenticationFlow.Redirect)
        {
            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.AbortUrl))
                throw new ValidationException("Abort url must be set when using flow redirect");
            
            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.ErrorUrl))
                throw new ValidationException("Error url must be set when using flow redirect");
            
            if (string.IsNullOrWhiteSpace(_options.CallbackUrls?.SuccessUrl))
                throw new ValidationException("Success url must be set when using flow redirect");
        }

        if (_options.Flow == AuthenticationFlow.Headless)
        {
            if (string.IsNullOrWhiteSpace(_options.PrefilledInput?.Email) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Mobile) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Nin) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.Username) &&
                string.IsNullOrWhiteSpace(_options.PrefilledInput?.DateOfBirth)
                )
                throw new ValidationException("One or more prefilled fields must be set when using flow headless");
        }
        
        return _options;
    }
}