using MediatR;
using PuppeteerSharp;
using TMP.aplication.utils;
using TPM.domain.contracts.webScraping.takeScreen;
using TPM.domain.domainEvents.events;
using TMP.domain.commons.response.result;
using TMP.domain.dto;
using PuppeteerExtraSharp;
using TMP.aplication.utils.id;
using TMP.aplication.response.PuppeteerSharp;

namespace TMP.infraestructure.webScraping
{
    public class CaptureUrl : ISaveImageFromUrl
    {
        private readonly string _pathDirectory = @"C:\Users\camil\OneDrive\Desktop\escritorio\TMPAngular\TMPFront\src\p";
        //private readonly string _pathDirectory = @"/usr/storage/urlImages";
        private readonly IMediator _mediator;

        public CaptureUrl(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<ProductDto>> CaptureImgFromUrl(string url, bool resizeImage)
        {
            try
            {
                TakeScreenResponse file = await TakeScreenshot(url);

                if (!File.Exists(file.filePath))
                {
                    return Result<ProductDto>.Failure("La captura no se guardó correctamente.", 604);
                }

                string finalPath = file.filePath;

                if (resizeImage)
                {
                    var resizeResult = ResizeImage(finalPath, 600, 600);

                    if (!resizeResult.IsSuccess)
                    {
                        return Result<ProductDto>.Failure(resizeResult.ErrorMessage, 605);
                    }

                    finalPath = resizeResult.Value;
                }

                var imageCapturedEvent = new ImageCaptureEvent(finalPath);
                var productDto = await _mediator.Send(imageCapturedEvent);
                productDto.Value.FilePath = file.fileName;

                return Result<ProductDto>.Success(productDto.Value);
            }
            catch (Exception ex)
            {
                return Result<ProductDto>.Failure($"Error al intentar realizar la captura de la URL: {url}. Detalles: {ex.Message}", 606);
            }
        }


        private async Task<TakeScreenResponse> TakeScreenshot(string url)
        {
            Console.WriteLine("uno");
            //Instancia de PuppeteerExtra y configuración del plugin Stealth
            PuppeteerExtra puppeteerExtra = new PuppeteerExtra();
            var stealth = new PuppeteerExtraSharp.Plugins.ExtraStealth.StealthPlugin();
            puppeteerExtra.Use(stealth);

            // Configuración del navegador
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            // Opciones de lanzamiento del navegador
            var launchOptions = new LaunchOptions
            {
                Headless = false,  // Establece en 'true' para ejecutar en modo sin cabeza (headless)
                Args = new[]
                {
                    "--no-sandbox",
                    //"--disable-setuid-sandbox",
                    //"--disable-infobars",
                    //"--window-size=1920,1080",
                    "--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36"
        }
            };

            // Lanzar el navegador con PuppeteerExtra
            using (var browser = await puppeteerExtra.LaunchAsync(launchOptions))
            {
                using (var page = await browser.NewPageAsync())
                {
                    // Configurar el tamaño de la vista
                    await page.SetViewportAsync(new ViewPortOptions { Width = 1080, Height = 1000 });

                    // Navegar a la URL y esperar a que la página se cargue completamente
                    await page.GoToAsync(url, new NavigationOptions
                    {
                        WaitUntil = new[] { WaitUntilNavigation.Load }
                    });

                    // Esperar 5 segundos adicionales para asegurar que todos los elementos se carguen
                    await Task.Delay(8000);
                    string fileName = GuidGenerate.Generate();
                    // Capturar la pantalla y guardarla en el directorio especificado
                    var filePath = Path.Combine(_pathDirectory, $"{fileName}.png");
                    await page.ScreenshotAsync(filePath);

                    return new TakeScreenResponse(fileName, filePath);
                }
            }
        }

        private Result<string> ResizeImage(string inputImagePath, int width, int height)
        {
            var outputImagePath = Path.Combine(_pathDirectory, "rezize.png");
            return ImageReize.ReizeImage(inputImagePath, outputImagePath, width, height);
        }
    }
}