namespace TMP.domain.contracts.api
{
    public interface IApiCrud<Response>
    {
        public Task<Response> Post(string url, StringContent? content);
    }
}
