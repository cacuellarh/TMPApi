

using MediatR;
using TMP.domain.commons.response.result;
using TPM.domain.entities;

namespace TPM.domain.domainEvents.events
{
    public class GetCurrentProductCreatedEvent : IRequest<Result<Product>>
    {
        public int ProductId { get; }
        public GetCurrentProductCreatedEvent(int productId)
        { 
            ProductId = productId;
        }
    }
}
