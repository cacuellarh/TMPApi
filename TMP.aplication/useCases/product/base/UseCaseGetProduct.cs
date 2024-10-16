
using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase.product;
using TMP.aplication.response.db;
using TMP.domain.commons.response.result;
using TPM.domain.entities;

namespace TMP.aplication.useCases.product.basic
{
    public class UseCaseGetProduct : IUseCaseGetProduct
    {
        private readonly IProductRepository _repository;

        public UseCaseGetProduct(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Product>> Execute(int id)
        {
            DbResponse response = await _repository.GetByIdAsync(id);

            if (response.Status)
            {
                return Result<Product>.Success(response.Data as Product);
            }
            else
            {
                return Result<Product>.Failure($"Error al obtener producto con id : {id}",700);
            }
        }
    }

}