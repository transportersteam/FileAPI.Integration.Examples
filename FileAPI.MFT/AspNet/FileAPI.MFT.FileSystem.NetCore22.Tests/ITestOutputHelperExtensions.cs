﻿using Newtonsoft.Json;
using Xunit.Abstractions;

namespace FileAPI.MFT.FileSystem.NetCore22.Tests
{
    public static class ITestOutputHelperExtensions
    {
        public static void WriteJson(this ITestOutputHelper output, object value)
        {
            output.WriteLine(JsonConvert.SerializeObject(value, Formatting.Indented));
        }

        public static void WriteTittle(this ITestOutputHelper output, string value)
        {
            output.WriteLine("=======================================================");
            output.WriteLine(value);
            output.WriteLine("=======================================================");
        }

        public static void WriteEnd(this ITestOutputHelper output)
        {
            output.WriteLine("");
        }
    }
}
