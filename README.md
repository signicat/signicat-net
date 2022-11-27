# WORK IN PROGRESS!
This SDK is work in progress and not production ready as of now
-------------------------------
# Signicat .NET SDK
[![Tests](https://github.com/signicat/signicat-net/actions/workflows/test.yml/badge.svg)](https://github.com/signicat/signicat-net/actions/workflows/test.yml)
[![NuGet](https://img.shields.io/nuget/v/Signicat.SDK.svg)](https://www.nuget.org/packages/Signicat.SDK)

A .NET SDK for simple integration with the Signicat REST APIs.

Supports .NET Standard 2.0+, .NET Core 2.0+ and .NET Framework 4.6.1+.

## Installation
Using NuGet is the easiest way to install the SDK.

Package Manager:

	PM > Install-Package Signicat.SDK

.NET Core CLI:  

	dotnet add package Signicat.SDK

## Documentation
- [Signicat REST API Reference](https://developer.signicat.com/dtp/apis/authentication/)
- [Signicat Developer Documentation](https://developer.signicat.com/dtp/docs)


## Sample Usage
The example below shows how to get the details of a specific document.

```csharp
// Set your credentials
SignicatConfiguration.SetClientCredentials("clientId", "clientSecret");


```

## Support
- Open an [issue](https://github.com/signicat/signicat-net/issues) to report bugs or submit feature requests.
- For other support requests, visit [Signicat Community](https://community.signicat.com).
