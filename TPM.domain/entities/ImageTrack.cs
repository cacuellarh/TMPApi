using TPM.domain.commons;

namespace TPM.domain.entities
{
    public class ImageTrack : BaseEntity
    {
        public string email { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        public Product product { get; set; }
        public bool CanScan { get; set; } = true;
    }
}
