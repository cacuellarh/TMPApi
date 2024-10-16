
using TPM.domain.commons.entities;

namespace TMP.domain.dto
{
    public class ProductDto : AuditoryScann
    {
        public string? Descripcion { get; set; }
        public string? Precio { get; set; }
        public string? Descuento { get; set; }
        public string? TipoMoneda { get; set; }
        public string? FilePath { get; set; }
    }
}
