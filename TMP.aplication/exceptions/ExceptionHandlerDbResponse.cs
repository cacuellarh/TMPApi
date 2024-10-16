using TMP.aplication.response.db;
using TMP.aplication.utils;

namespace TMP.aplication.exceptions
{
    public static class ExceptionHandlerDbResponse
    {
        public static async Task<DbResponse> HandleAsync(Func<Task<DbResponse>> func, string errorMessageDetails = "Ninguno.", int statusCode = 500)
        {
            try
            {
                return await func();
            }
            catch (Exception ex) 
            {
                return MakeResponse.CreateResponse(false, $"{ex.Message}, ExceptionHandler: {errorMessageDetails}", null, statusCode);
            }
        }
    }
}
