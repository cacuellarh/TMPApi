
using MediatR;
using TMP.domain.commons.response.result;
using TMP.domain.dto;

namespace TPM.domain.domainEvents.events
{
    public class ImageCaptureEvent : IRequest<Result<ProductDto>>
    {
        public ImageCaptureEvent(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        
    }
}
