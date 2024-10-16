
namespace TMP.aplication.utils
{
    public class ImageConverter
    {
        public static string EncodeImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }
    }
}
