

using MediatR;
using TMP.domain.commons.response.api;
using TMP.domain.commons.response.result;
using TMP.domain.contracts.api;
using TMP.domain.contracts.map;
using TMP.domain.dto;
using TPM.domain.contracts.webScraping.chatGpt;
using TPM.domain.domainEvents.events;


namespace TPM.domain.domainEvents.handlers
{
    public class ImageCaptureEventHandler : IRequestHandler<ImageCaptureEvent, Result<ProductDto>>
    {
        private readonly ILoadRequestChatGpt _loadRequestChatGpt;
        private readonly IApiCrud<ApiResponse> _apiCrud;
        private readonly IMap<string, Result<ProductDto>> _mapper;

        public ImageCaptureEventHandler(ILoadRequestChatGpt loadRequestChatGpt, IApiCrud<ApiResponse> apiCrud, IMap<string, Result<ProductDto>> mapper)
        {
            _loadRequestChatGpt = loadRequestChatGpt;
            _apiCrud = apiCrud;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(ImageCaptureEvent request, CancellationToken cancellationToken)
        {
            var content = _loadRequestChatGpt.LoadJsonConfig(request.FilePath);
            var responseApi = await _apiCrud.Post("https://api.openai.com/v1/chat/completions", content);

            Result<ProductDto> productDto = _mapper.MapTo(responseApi.Response.choices[0].message.content);
            return productDto;
        }
    }
}
