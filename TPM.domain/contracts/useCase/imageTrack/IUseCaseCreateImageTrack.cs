
using TMP.domain.commons.response.result;
using TMP.domain.request.imageTrackRequest;
using TPM.domain.entities;

namespace TMP.domain.contracts.useCase.imageTrack
{
    public interface IUseCaseCreateImageTrack : IUseCase<CreateImageTrackRequest, Result<ImageTrack>> { }
    
    
}
