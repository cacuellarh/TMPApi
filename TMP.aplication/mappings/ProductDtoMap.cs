using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using TMP.domain.commons.response.result;
using TMP.domain.contracts.map;
using TMP.domain.dto;

namespace TMP.aplication.mappings
{
    public class ProductDtoMap : IMap<string, Result<ProductDto>>
    {
        public Result<ProductDto> MapTo(string map)
        {
            if (string.IsNullOrWhiteSpace(map))
            {
                return Result<ProductDto>.Failure("Error: El string de entrada es nulo o vacío.",607);
            }

            try
            {
                var jsonMatch = Regex.Match(map, @"```json\s*(\{.*?\})\s*```", RegexOptions.Singleline);
                if (!jsonMatch.Success)
                {
                    return Result<ProductDto>.Failure("Error: No se pudo serializar los datos de chatGpt a JSON", 600);

                }

                var jsonString = jsonMatch.Groups[1].Value;

                // Limpiar el JSON de caracteres no deseados
                jsonString = jsonString.Trim();

                ProductDto product = JsonSerializer.Deserialize<ProductDto>(jsonString);
                return Result<ProductDto>.Success(product); 
            }
            catch (JsonException ex)
            {
                Result<ProductDto>.Failure($"Error al deserializar JSON: {ex.Message}", 600);
 
            }
            catch (Exception ex)
            {
                Result<ProductDto>.Failure($"Error inesperado: {ex.Message}", 606);

            }
            return Result<ProductDto>.Failure("Error: Operacion de serializacion incompleta", 600);
        }
    }
}
