using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Signicat.SDK.Tests;

public class LaunchSettingsHelper
{

    public static void LoadEnvironmentVariables()
    {
        var launchSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties", "launchSettings.dev.json");
        if (File.Exists(launchSettingsPath))
        {
            var json = JObject.Parse(File.ReadAllText(launchSettingsPath));
            var variables = json["profiles"]["Signicat.SDK.Tests"]["environmentVariables"].ToObject<Dictionary<string, string>>();

            foreach (var variable in variables)
            {
                Environment.SetEnvironmentVariable(variable.Key, variable.Value);
            }
        }
    }

}