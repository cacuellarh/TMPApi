using System;

namespace TMP.aplication.utils.id
{
    public static class GuidGenerate
    {
        public static string Generate()
        {
            Guid guid1 = Guid.NewGuid();
            return guid1.ToString();    
        }
    }
}
