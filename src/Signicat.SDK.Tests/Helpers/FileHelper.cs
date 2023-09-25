using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

    public static bool CompareByteArrayAndStream(byte[] data, Stream data2)
    {
        using var ms = new MemoryStream();
        data2.CopyTo(ms);
        return ms.ToArray().SequenceEqual(data);
    }
}