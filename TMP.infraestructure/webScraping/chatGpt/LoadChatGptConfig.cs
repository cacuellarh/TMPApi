using PuppeteerSharp;
using System.Text;
using System.Text.Json;
using TMP.aplication.commons.request;
using TMP.aplication.utils;
using TPM.domain.contracts.webScraping.chatGpt;

namespace TMP.infraestructure.webScraping.chatGpt
{
    public class LoadChatGptConfig : ILoadRequestChatGpt
    {
        public StringContent LoadJsonConfig(string imagPath)
        {
            string base64Image = ImageConverter.EncodeImageToBase64(imagPath);

            PayLoad payload = new PayLoad()
            {
                Model = "gpt-4o-mini",
                Messages = new List<Message>
                {
                    new Message()
                    {
                        Role = "user",
                        Content = new List<object>
                        {
                            new ContentText()
                            {
                                Type = "text",
                                Text = "¿Cuál es el precio del producto? " +
                                  "Por favor, devuélveme la respuesta como un objeto JSON puro y bien estructurado con las siguientes claves:\n" +
                                  "- `OperationStatusCode`: Código de estado de la operación basado en las siguientes reglas:\n" +
                                  "  - `100`: Si la operación fue exitosa y se obtuvo al menos un precio y una descripción.\n" +
                                  "  - `501`: Si en la imagen se detectan más de un producto(Unicamente puede haber 1, si hay 2 o mas es una operacion 501).\n" +
                                  "  - `502`: Si hay un producto visible pero no se puede encontrar un precio asociado.\n" +
                                  "  - `503`: Si hay un elemento (como publicidad, aviso de cookies, etc.) que obstruye la vista del producto o su precio.\n" +
                                  "  - `504`: Si la imagen no corresponde a un ecommerce, no muestra un producto o algo relacionado.\n"+

                                  "- `Descripcion` (opcional): Formato string.\n" +
                                  "- `Precio`: Formato string precio guardado en Decimal(10,2) pero en cadena \n" +
                                  "- `Descuento` (opcional, si hay algun descuento relacionado al producto) : Formato string.\n" +
                                  "- `TipoMoneda`: Formato string (dependiendo de la moneda utilizada en el precio).\n"
                                  
                                 

        },
                            new ContentImage()
                            {
                                Type = "image_url",
                                ImageUrl = new ImageUrl
                                {
                                    Url = $"data:image/jpeg;base64,{base64Image}"
                                }
                            }
                        }
                    }
                },
                MaxTokens = 300,
                ResponseFormat = new Dictionary<string, string>
                {
                    { "type", "json_object" }
                }
            };

            return PayloadToStringContent(payload);
        }

        private StringContent PayloadToStringContent(PayLoad payload)
        {
            string jsonPayload = JsonSerializer.Serialize(payload);
            return new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        }
    }
}
