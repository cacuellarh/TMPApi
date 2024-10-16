using TMP.domain.commons.response.result;
using TMP.domain.contracts.map;
using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase.product;
using TMP.domain.dto;
using TMP.aplication.response.db;
using TPM.domain.entities;

namespace TMP.aplication.useCases.product.basic
{
    public class UseCaseCreateProduct : IUseCaseCreateProduct
    {
        private readonly IMap<ProductDto, Result<Product>> _mapper;
        private readonly IProductRepository _repository;
        public UseCaseCreateProduct(IMap<ProductDto, Result<Product>> mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<Result<Product>> Execute(ProductDto options)
        {
            Result<Product> product = _mapper.MapTo(options);
            
            if (product.Value == null) 
            {
                return Result<Product>.Failure($"No se pudo mapear el productoDto a Producto {options.ToString()}", 601);
            }
            DbResponse response = await _repository.AddAsync(product.Value );
            Console.WriteLine(response.ToString());

            return Result<Product>.Success(response.Data as Product);
        }

    }
}
