namespace TMP.aplication.response.PuppeteerSharp
{
    public class TakeScreenResponse
    {
        public TakeScreenResponse(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }

        public string fileName { get; set; }
        public string filePath { get; set; }
    }
}
