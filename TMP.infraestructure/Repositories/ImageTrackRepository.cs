using TMP.aplication.contracts.repository;
using TMP.infraestructure.persistence;
using TPM.domain.entities;

namespace TMP.infraestructure.Repositories
{
    public class ImageTrackRepository : BaseRepository<ImageTrack>, IImageTrackRepository
    {
        public ImageTrackRepository(DbContextTMP dbContext) : base(dbContext)
        {

        }
    }
}
