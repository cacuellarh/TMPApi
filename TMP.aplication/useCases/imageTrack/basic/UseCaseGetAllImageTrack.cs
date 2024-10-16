using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase;
using TMP.aplication.response.db;


namespace TMP.aplication.useCases.imageTrack.basic
{
    public class UseCaseGetAllImageTrack : IUseCaseVoid<DbResponse>
    {
        private readonly IImageTrackRepository _repository;

        public UseCaseGetAllImageTrack(IImageTrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<DbResponse> Execute()
        {

            return await this._repository.GetAllAsync();

        }
    }
}
