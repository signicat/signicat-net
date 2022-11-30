# Signicat .NET SDK
[![Tests](https://github.com/signicat/signicat-net/actions/workflows/test.yml/badge.svg)](https://github.com/signicat/signicat-net/actions/workflows/test.yml)
[![NuGet](https://img.shields.io/nuget/v/Signicat.SDK.svg)](https://www.nuget.org/packages/Signicat.SDK)

A .NET SDK for simple integration with the Signicat REST APIs.

Supports .NET Standard 2.0+, .NET Core 2.0+ and .NET Framework 4.6.1+.

## Installation
Using NuGet is the easiest way to install the SDK.

Package Manager:

	PM > Install-Package Signicat.SDK
    PM > Install-Package Signicat.SDK.Fluent (optional if you wan to use the fluent builder)

.NET Core CLI:  

	dotnet add package Signicat.SDK
    dotnet add package Signicat.SDK.Fluent (optional if you wan to use the fluent builder)

## Documentation
- [Signicat REST API Reference](https://developer.signicat.com/dtp/apis/authentication/)
- [Signicat Developer Documentation](https://developer.signicat.com/dtp/docs)

The SDK have option for both sync and async methods.

## Sample Usage
You can set the credentials either in the configuration class as seen below or per service in the constructor.
```csharp
// Set your credentials
SignicatConfiguration.SetClientCredentials("clientId", "clientSecret");
```
### Authentication

#### Create session
```csharp
AuthenticationService _authenticationService = new AuthenticationService();

var createSession  = new AuthenticationCreateOptions()
             {
                 Flow = AuthenticationFlow.Redirect,
                 Language = Languages.English,
                 AllowedProviders = new List<string>()
                 {
                     AllowedProviderTypes.NorwegianBankId,
                     AllowedProviderTypes.SwedishBankID
                 },
                 ExternalReference = Guid.NewGuid().ToString("n"),
                 CallbackUrls = new CallbackUrls()
                 {
                     Abort = "https://mytest.com#abort",
                     Success = "https://mytest.com#success",
                     Error = "https://mytest.com#error",
                 },
                 RequestedAttributes = new List<string>()
                 {
                     RequestedAttributes.FirstName,
                     RequestedAttributes.LastName,
                     RequestedAttributes.NationalIdentifierNumber
                 },
                 SessionLifetime = 60
             };
             
var session =await  _authenticationService.CreateSessionAsync(createSession);
```
##### Using fluent package
```csharp
AuthenticationService _authenticationService = new AuthenticationService();

var createSession = AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Redirect)
            .WithCallbackUrls(success: "https://myservice.com/success", abort: "https://myservice.com/abort",
                error: "https://myservice.com/error")
            .WithLanguage("no")
            .WithAllowedProviders(Constants.AllowedProviderTypes.NorwegianBankId, Constants.AllowedProviderTypes.iDIN)
            .WithExternalReference(Guid.NewGuid().ToString())
            .WithThemeId("ab1212")
            .WithRequestedAttributes(Constants.RequestedAttributes.FirstName, Constants.RequestedAttributes.LastName,
                Constants.RequestedAttributes.NationalIdentifierNumber)
            .Build();
                
var session =await  _authenticationService.CreateSessionAsync(createSession);
```

#### Get session
```csharp
AuthenticationService _authenticationService = new AuthenticationService();
var session =await  _authenticationService.GetSessionAsync("53912d35-eef6-4116-8d7e-8b7c84ffa1f2");
```

### Digital Evidence Management

#### Create dem record
```csharp
var digitalEvidenceManagementService = new DigitalEvidenceManagementService();

var newRecord = new DemRecordCreateOptions()
    {
        Metadata = new Dictionary<string, object>()
        {
            {"timestamp", DateTime.Now},
            {"hash", "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"},
        },
        Type = RecordTypes.LOG_IN,
        TimeToLiveInDays = 1,
        CoreData = new Dictionary<string, object>()
        {
            {"name", "Bruce Wayne"},
            {"identityProvider", "WayneEnterpriseCorporateId"},
            {"subject", "9764384103"}
        },
        AuditLevel = AuditLevels.ADVANCED
    };
var record = await  digitalEvidenceManagementService.CreateDemRecordAsync(newRecord);
```

##### Fluent
```csharp
var digitalEvidenceManagementService = new DigitalEvidenceManagementService();

        var options = DemRecordCreateOptionsBuilder.Create()
            .WithType(RecordTypes.LOG_IN)
            .WithAuditLevel(AuditLevels.ADVANCED)
            .WithTimeToLiveInDays(365)
            .WithMetaData(new Dictionary<string, object>()
            {
                {"timestamp", DateTime.Now},
                {"hash", "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"},
            })
            .WithMetaData(new Dictionary<string, object>()
            {
                {"name", "Bruce Wayne"},
                {"identityProvider", "WayneEnterpriseCorporateId"},
                {"subject", "9764384103"}
            })
            .WithRelations("53912d35-eef6-4116-8d7e-8b7c84ffa1f2")
            .Build();

        var response = await digitalEvidenceManagementService.CreateDemRecordAsync(options);
```

#### Get record
```csharp
var digitalEvidenceManagementService = new DigitalEvidenceManagementService();

var retrievedRecord = await _digitalEvidenceManagement.GetRecordAsync("53912d35-eef6-4116-8d7e-8b7c84ffa1f2");
```

## Support
- Open an [issue](https://github.com/signicat/signicat-net/issues) to report bugs or submit feature requests.
- For other support requests, visit [Signicat Community](https://community.signicat.com).
