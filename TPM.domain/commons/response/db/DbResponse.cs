using TMP.aplication.commons.response;

namespace TMP.aplication.response.db
{
    public class DbResponse : HttpResponse
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }
    }
}
