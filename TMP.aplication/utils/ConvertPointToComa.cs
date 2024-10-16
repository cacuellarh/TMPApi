

namespace TMP.aplication.utils
{
    public static class ConvertPointToComa
    {
        public static string Convert(string dataToConvert)
        {
            string modifiedData = dataToConvert.Replace('.', ',');

            return modifiedData;    
        }
    }
}
