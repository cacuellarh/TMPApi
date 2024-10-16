
using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase;
using TMP.domain.contracts.useCase.imageTrack;
using TMP.aplication.response.db;
using TPM.domain.entities;

namespace TMP.aplication.useCases.imageTrack.basic
{
    public class UseCaseUpdateImageTrack : IUseCaseUpdateImageTrack
    {
        private readonly IImageTrackRepository _repository;

        public UseCaseUpdateImageTrack(IImageTrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<DbResponse> Execute(ImageTrack options)
        {
            return await _repository.UpdateAsync(options);
        }
    }
}
