using System.Linq.Expressions;
using TMP.domain.contracts.useCase;
using TMP.domain.contracts.useCase.facades;
using TMP.domain.contracts.useCase.imageTrack;
using TMP.aplication.response.db;
using TMP.aplication.useCases.imageTrack.basic;
using TPM.domain.entities;
using TMP.domain.request.imageTrackRequest;
using TMP.domain.commons.response.result;

namespace TMP.aplication.useCases.imageTrack.facade
{
    public class FacadeUseCasesImageTrack : IImageTrackFacade
    {
        private readonly IUseCaseCreateImageTrack _useCaseCreate;
        private readonly IUseCaseUpdateImageTrack _useCaseUpdate;
        private readonly IUseCaseDeleteImageTrack _useCaseDelete;
        private readonly IUseCaseVoid<DbResponse> _useCaseGetAll;
        private readonly IUseCase<Expression<Func<ImageTrack, bool>>, DbResponse> _useCaseGet;

        public FacadeUseCasesImageTrack(
            IUseCaseCreateImageTrack useCaseCreate,
            IUseCaseDeleteImageTrack useCaseDelete,
            IUseCaseUpdateImageTrack useCaseUpdate,
            IUseCaseVoid<DbResponse> useCaseGetAll,
            IUseCase<Expression<Func<ImageTrack, bool>>, DbResponse> useCaseGet
            )
        {
            _useCaseCreate = useCaseCreate;
            _useCaseDelete = useCaseDelete;
            _useCaseGetAll = useCaseGetAll;
            _useCaseGet = useCaseGet;
            _useCaseUpdate = useCaseUpdate;
        }


        public async Task<Result<ImageTrack>> CreateImageTrack(CreateImageTrackRequest request) =>  await _useCaseCreate.Execute(request);
        public async Task<DbResponse> GetAllImageTrack() => await _useCaseGetAll.Execute();
        public async Task<DbResponse> DeleteImageTrack(ImageTrack image) => await _useCaseDelete.Execute(image);
        public async Task<DbResponse> GetImageTrack(Expression<Func<ImageTrack, bool>> predicate) => await _useCaseGet.Execute(predicate);
        public async Task<DbResponse> UpdateImageTrack(ImageTrack image) => await _useCaseUpdate.Execute(image);

    }
}
