using TMP.aplication.contracts.repository;
using TMP.infraestructure.persistence;
using TPM.domain.entities;

namespace TMP.infraestructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContextTMP dbContext) : base(dbContext)
        {

        }
    }
}
