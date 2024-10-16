using System.Linq.Expressions;
using TMP.aplication.response.db;
using TMP.domain.commons.response.result;
using TMP.domain.request.imageTrackRequest;
using TPM.domain.entities;

namespace TMP.domain.contracts.useCase.facades
{
    public interface IImageTrackFacade
    {
        public  Task<Result<ImageTrack>> CreateImageTrack(CreateImageTrackRequest request);
        public  Task<DbResponse> GetAllImageTrack();
        public  Task<DbResponse> DeleteImageTrack(ImageTrack image);
        public  Task<DbResponse> GetImageTrack(Expression<Func<ImageTrack, bool>> predicate);
        public  Task<DbResponse> UpdateImageTrack(ImageTrack image);
    }
}
