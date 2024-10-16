using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase.imageTrack;
using TMP.aplication.response.db;
using TPM.domain.entities;
using MediatR;
using TMP.domain.commons.response.result;
using TPM.domain.domainEvents.events;
using TMP.domain.request.imageTrackRequest;

namespace TMP.aplication.useCases.imageTrack.basic
{
    public class UseCaseCreateImageTrack : IUseCaseCreateImageTrack
    {
        private readonly IImageTrackRepository _repository;
        private readonly IMediator _mediator;

        public UseCaseCreateImageTrack(IImageTrackRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;   
        }

        public async Task<Result<ImageTrack>> Execute(CreateImageTrackRequest options)
        {
            GetCurrentProductCreatedEvent getProductEvent = new GetCurrentProductCreatedEvent(options.ProductId);
            Result<Product> resultProduct = await _mediator.Send(getProductEvent);

            if (resultProduct.IsSuccess)
            { 
                options.Value.product = resultProduct.Value;
            }
            else 
            {
                return Result<ImageTrack>.Failure(resultProduct.ErrorMessage, resultProduct.CodeStatusOperation);
            }

            DbResponse createImageTrack = await _repository.AddAsync(options.Value);

            if (createImageTrack.Status)
            {
                return Result<ImageTrack>.Success(createImageTrack.Data as ImageTrack);
            }
            else 
            {
                return Result<ImageTrack>.Failure("No se pudo realizar la creacion de la entidad ImageTrack", 701);
            }

        }
    }
}
