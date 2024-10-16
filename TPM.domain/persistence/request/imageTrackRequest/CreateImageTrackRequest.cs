using TPM.domain.entities;

namespace TMP.domain.request.imageTrackRequest
{
    public class CreateImageTrackRequest
    {
        public int ProductId { get; set; }
        public ImageTrack Value { get; set; }   
    }
}
