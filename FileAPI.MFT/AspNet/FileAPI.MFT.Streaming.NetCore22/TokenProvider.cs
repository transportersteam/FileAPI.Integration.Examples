using System.Threading.Tasks;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public static class TokenProvider
    {
        public static async Task<string> GetAuthenticationTokenAsync()
        {
            // Here comes the logic of retrieving the authentication token.
            // This logic is out of the File API scope, but For instance, you can use something
            // similar to what is implemented in Examples/RetrieveToken.cs.
            return await Task.FromResult("MyToken");
        }
    }
}
