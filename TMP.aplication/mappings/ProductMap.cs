
using TMP.aplication.utils;
using TMP.domain.commons.response.result;
using TMP.domain.contracts.map;
using TMP.domain.dto;
using TPM.domain.entities;

namespace TMP.aplication.mappings
{
    public class ProductMap : IMap<ProductDto, Result<Product>>
    {
        public Result<Product> MapTo(ProductDto map)
        {

            try
            {
                Product productMap =  new Product
                    (
                        map.Descripcion,
                        Decimal.Parse(ConvertPointToComa.Convert(map.Precio)),
                        map.Descuento,
                        map.TipoMoneda

                    );

                return Result<Product>.Success(productMap);
            }
            catch (Exception ex)
            {
                return Result<Product>.Failure($"Error al mapear ProductDto a Product, detalles: {ex.Message}",601);

            }
            
        }
    }
}
