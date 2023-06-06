using System;
using System.Diagnostics;

namespace Signicat.SDK.Tests.Helpers;

public static class FileHelper
{
    public static string CreateTempPdfFileName()
    {
        return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
    }

    public static void OpenFile(string filename)
    {
        new Process
        {
            StartInfo = new ProcessStartInfo(filename)
            {
                UseShellExecute = true
            }
        }.Start();
    }
}