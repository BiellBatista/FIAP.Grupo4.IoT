using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text;
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

namespace FIAP.Grupo4.Function.IoT
{
    public static class WagonAnalysis
    {
        [FunctionName("func-grupo4-fiap")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IoTHubConnectionString", ConsumerGroup = "func-grupo4-fiap")] EventData message, ILogger log)
        {
            var messageString = Encoding.UTF8.GetString(message.Body.Array);

            log.LogInformation($"Mensagem: {messageString}");
        }
    }
}