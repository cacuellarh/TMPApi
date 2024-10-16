using SkiaSharp;
using TMP.domain.commons.response.result;

namespace TMP.aplication.utils
{
    public class ImageReize
    {
        public static Result<string> ReizeImage(string inputImagePath, string outputImagePath, int width, int height)
        {
            try
            {
                using (var inputStream = File.OpenRead(inputImagePath))
                {
                    using (var originalImage = SKBitmap.Decode(inputStream))
                    {
                        var resizedImage = originalImage.Resize(new SKImageInfo(width, height), SKFilterQuality.High);
                        if (resizedImage == null)
                        {
                            return Result<string>.Failure("La imagen no pudo ser redimensionada.", 602);
                        }

                        using (var image = SKImage.FromBitmap(resizedImage))
                        {
                            using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                            {
                                using (var outputStream = File.OpenWrite(outputImagePath))
                                {
                                    data.SaveTo(outputStream);
                                }
                            }
                        }

                        if (File.Exists(outputImagePath))
                        {
                            return Result<string>.Success(outputImagePath);
                        }
                        return Result<string>.Failure("No se creó el archivo ajustado.", 602);
                    }
                }
            }
            catch (Exception e)
            {
                return Result<string>.Failure(e.Message, 603);
            }
        }
    }
}
