using TMP.aplication.response.db;

namespace TMP.aplication.utils
{
    public static class MakeResponse
    {
        public static DbResponse CreateResponse(bool status, string message, object data, int statusCode = 200)
        {
            var dbResponse = new DbResponse
            {
                Status = status,
                Data = status ? data : null,
                Message = status
                    ? $"Operación realizada correctamente, detalles de repositorio: {message}"
                    : $"Ocurrió un error al realizar la operación. Detalles de repositorio: {message}",
                StatusCode = !status ? statusCode : 200
            };

            return dbResponse;
        }
    }
}
