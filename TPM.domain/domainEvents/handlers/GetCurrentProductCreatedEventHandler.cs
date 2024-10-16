using MediatR;
using TMP.domain.commons.response.result;
using TMP.domain.contracts.useCase.product;
using TPM.domain.domainEvents.events;
using TPM.domain.entities;

namespace TPM.domain.domainEvents.handlers
{
    public class GetCurrentProductCreatedEventHandler : IRequestHandler<GetCurrentProductCreatedEvent, Result<Product>>
    {
        private readonly IUseCaseGetProduct useCaseGetProduct;

        public GetCurrentProductCreatedEventHandler(IUseCaseGetProduct useCaseGetProduct)
        {
            this.useCaseGetProduct = useCaseGetProduct;
        }

        public async Task<Result<Product>> Handle(GetCurrentProductCreatedEvent request, CancellationToken cancellationToken)
        {
            Result<Product> result = await useCaseGetProduct.Execute(request.ProductId);

            if (result.IsSuccess)
            {
                return result;
            }
            else 
            {
                return Result<Product>.Failure(result.ErrorMessage, result.CodeStatusOperation);
            }
        }
    }
}
