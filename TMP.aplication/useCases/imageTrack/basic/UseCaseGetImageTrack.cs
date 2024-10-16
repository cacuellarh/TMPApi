using System.Linq.Expressions;
using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase;
using TMP.aplication.response.db;
using TPM.domain.entities;

namespace TMP.aplication.useCases.imageTrack.basic
{
    public class UseCaseGetImageTrack : IUseCase<Expression<Func<ImageTrack, bool>>, DbResponse>
    {
        private readonly IImageTrackRepository _repository;

        public UseCaseGetImageTrack(IImageTrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<DbResponse> Execute(Expression<Func<ImageTrack, bool>> options)
        {
            return await _repository.GetAsync(options);   
        }
    }
}
