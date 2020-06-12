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
            return await Task.FromResult(
                "eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IlJ1ZTBUZlhsU2lYRzZieXE0MHcwQ2RSN0FkM2VYNzVJIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcImU5ZTNlMmE0LTUzMzMtNDY5YS1iMDEzLTA4OWNlNTUxY2M1NVwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU1wifSIsImF1dGh6Ijoie1wicGVybWlzc2lvbnNcIjp7XCJhbGxcIjpmYWxzZSxcInZhbHVlc1wiOltcIkZ0YWFzLk1hbmFnZUZpbGVzXCJdfSxcInRlbmFudHNcIjp7XCJhbGxcIjp0cnVlLFwidmFsdWVzXCI6W119fSIsImp3dHR5cGUiOiJzeXN0ZW0iLCJleHAiOjE1OTE5NjE4NzV9.EPbTOuCChPJRXFb0b9EBkKUjGKRLgGCNrp2_aDs6TqwB6lIPzqCTXdSWDkQfWCDl6HkJZPZ6OyxSHIVswoVJXHaAGDfG564ijVU4V0zdGiB8t1mi4iRb0fl1rnB3SNZ5qum2pzeZlhhitQGtFiYv1Ntfv7URCLTBHc8APD5ZrsCW3luNa6Vtsk3Cockx-mg-KzmpyU23mqZwvij1s8h-X1KjWphIPhWfLHweqjJUWH4hBworcj0lL-ji_QFC3wNAV-9fHX69IHstUZiMCkuTRYrt79puc91YSRDo4va0BNmQ0wfM4YQGAXyUDBH6md5277pIVBP4sTad15V_dz0SfA");
        }
    }
}
