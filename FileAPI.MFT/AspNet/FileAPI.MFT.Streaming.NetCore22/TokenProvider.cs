using System.Threading.Tasks;

namespace FileAPI.MFT.Streaming.NetCore22
{
    public static class TokenProvider
    {
        public static async Task<string> GenerateAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // To get more information about how to retrieve it, please go to Ping documentation.
            // ToDo Add ping documentation.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IktZTHJHT0tucUc3cHBJQkVyeW9Vdzhnd2VObWQ0WmJuIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcIjI2OTNjNWE5LTZiMWYtNGE1OS05Y2UxLTExZTU2YTkxYmIzZFwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU19TaW5nbGUtVGVuYW50XCJ9IiwiYXV0aHoiOiJ7XCJwZXJtaXNzaW9uc1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiRnRhYXMuTWFuYWdlRmlsZXNcIl19LFwidGVuYW50c1wiOntcImFsbFwiOmZhbHNlLFwidmFsdWVzXCI6W1wiNjQwMTk3MFwiXX19Iiwiand0dHlwZSI6InN5c3RlbSIsImV4cCI6MTU5MTk2OTYyMH0.VZST3hwfE193G7VLq4yubXX3HGBpzHG3GhJzvwpzxtjW0nrhFO6edxXAuFfx113wrOyoo-iAspD-S8U2R0qWG_Bn46FsvEV47gkRxpQXtvQs0f4Ih5fKY0_JQE9YDD2_SzBRVJmOKqoAgY6XAeILeUbIMmsdYYXcAsBY6Vwsrx1M0tsbUQM6QC8m6VdaJ-ml7WpOVk-7AXt8w-WQysgXWRebWOK12Cuu5mtCmIik38X-QVlBJ2j3SVKVEQdjScOBrc0_V2FwL1MyXI82x7OG5eZ4WuwUYCx1sYDGAnr26L1Jt8ScZLqZixJOjnG0H98lhcby_wKEqwl_33DuavCbgQ");
        }
    }
}
