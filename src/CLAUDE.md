# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This repository contains the Signicat .NET SDK, a client library for interacting with Signicat's REST API services. Signicat provides digital identity and electronic signature solutions.

The solution consists of three main projects:

1. **Signicat.SDK** - Core SDK library targeting .NET Standard 2.0
2. **Signicat.SDK.Fluent** - Fluent API builder extension for the SDK
3. **Signicat.SDK.Tests** - NUnit test project for the SDK

## Development Setup

### Prerequisites

- .NET 8.0 SDK or later
- Environment variables for authentication:
  - `SIGNICAT_CLIENT_ID` - Your Signicat client ID
  - `SIGNICAT_CLIENT_SECRET` - Your Signicat client secret

### Common Commands

#### Building the Solution

```bash
dotnet build
```

#### Running Tests

Run all tests:
```bash
dotnet test
```

Run a specific test class:
```bash
dotnet test --filter "FullyQualifiedName~Signicat.SDK.Tests.Services.AuthenticationServiceTest"
```

Run a specific test method:
```bash
dotnet test --filter "FullyQualifiedName=Signicat.SDK.Tests.Services.AuthenticationServiceTest.Create_WhenCalled_ReturnsAuthSession"
```

#### Creating NuGet Packages

```bash
dotnet pack -c Release
```

## Architecture

### Core Components

1. **SignicatConfiguration** - Static configuration class for the SDK including authentication settings
2. **Services** - Organized by functional areas:
   - AuthenticationService - For authentication and identification
   - SignService - For document signatures
   - InformationService - For retrieving information about entities
   - DigitalEvidenceManagementService - For managing digital evidence
   - UsageService - For tracking API usage
   - AccountManagementService - For account management

3. **Infrastructure**
   - HttpRequestor - Handles HTTP communication with the Signicat API
   - Mapper - Handles serialization/deserialization
   - AuthManager - Manages OAuth authentication
   - APIHelper - Utility methods for API calls

### Testing Approach

Tests use:
- NUnit as the test framework
- Moq for mocking
- AutoFixture for test data generation

The `BaseTest` class provides common infrastructure for tests including:
- Environment setup
- Authentication configuration
- HTTP request assertion helpers

## Current Development

The current branch (`add_support_for_dtp_sign`) is focused on adding support for DTP (Document Transaction Platform) signing capabilities, with modifications to the Sign service and related entities.