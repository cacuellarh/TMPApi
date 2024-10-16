using TPM.domain.commons;

namespace TPM.domain.entities
{
    public class Product : BaseEntity
    {
        public Product(string? descripcion, decimal precio, string? descuento, string? tipoMoneda)
        {
            Descripcion = descripcion;
            Precio = precio;
            Descuento = descuento;
            TipoMoneda = tipoMoneda;
            PrecioActualEscaneado = precio;
        }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Descuento { get; set; }
        public string? TipoMoneda { get; set; }
        public decimal? PrecioActualEscaneado { get; set; }

    }
}
