using Newtonsoft.Json;
using Xunit.Abstractions;

namespace FileAPI.MFT.Utils
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
    }
}
