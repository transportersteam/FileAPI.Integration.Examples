using System.Threading.Tasks;

namespace FileAPI.MFT.FileSystem.NetCore22.Tests.Examples
{
    public static class TokenProvider
    {
        public static async Task<string> GenerateAsync()
        {
            // Here comes the logic of retrieving the authorization token.
            // To get more information about how to retrieve it, please go to Ping documentation.
            // ToDo Add ping documentation.
            //return await Task.FromResult("MyToken");
            return await Task.FromResult("eyJhbGciOiJSUzI1NiIsImtpZCI6IlNELVQtSUFNV0VCMDgucmFldC5sb2NhbCJ9.eyJzY29wZSI6W10sImNsaWVudF9pZCI6IlJ1ZTBUZlhsU2lYRzZieXE0MHcwQ2RSN0FkM2VYNzVJIiwiaXNzIjoiaWRlbnRpdHkucmFldHRlc3QuY29tIiwiYXBwIjoie1wiaWRcIjpcImU5ZTNlMmE0LTUzMzMtNDY5YS1iMDEzLTA4OWNlNTUxY2M1NVwiLFwibmFtZVwiOlwiVmlzbWFSYWV0X1RyYW5zcG9ydGVyc19GVGFhU1wifSIsImF1dGh6Ijoie1wicGVybWlzc2lvbnNcIjp7XCJhbGxcIjpmYWxzZSxcInZhbHVlc1wiOltcIkZ0YWFzLk1hbmFnZUZpbGVzXCJdfSxcInRlbmFudHNcIjp7XCJhbGxcIjp0cnVlLFwidmFsdWVzXCI6W119fSIsImp3dHR5cGUiOiJzeXN0ZW0iLCJleHAiOjE1OTE4OTIwNzB9.LZ1xAU-IgQV5puUGH9OQ4HPP1hYU4jnksuigrn8mrRyJiS5iK6l4CEbg9pirwx72xQAUt83HAKQ0t8el-3pQYYBHNmy_7e66ITb1JvKomFe_wlsM2STh1dQlq3fW-kctONmuIGuIGjf2wwuDOhpHCtVyYDWpBbS-ywgbM3RuR6qLuIe7v1ZDMdgipAQvuDstABPA2QXxM6yq5SVfauQxIx9WJFYQ47qs7_xn-5dHNIisyTjYmqMVXG03Fa_lhnthpigZ2OjCrEfB15W8wCkz3p2nP708W9bcJIzGFnz0KMlSqWnOAKfyEZ8QzKBQloeMxKWkA4vElC29ThMSkMcr6w");
        }
    }
}
