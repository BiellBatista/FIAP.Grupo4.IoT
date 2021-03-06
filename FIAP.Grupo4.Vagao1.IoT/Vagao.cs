using FIAP.Grupo4.Domain.IoT;
using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIAP.Grupo4.Vagao1.IoT
{
    public class Vagao
    {
        private static DeviceClient s_deviceClient;

        private const string s_connectionString = "";

        private static async Task SendDeviceToCloudMessagesAsync()
        {
            var startTime = DateTime.Now;
            var peopleEntered = 0;
            var peopleLeft = 0;
            var peopleStayed = 0;
            var station = 0;

            var rand = new Random();

            do
            {
                peopleLeft = (int)Math.Round(rand.NextDouble() * 30);
                peopleEntered = (int)Math.Round(rand.NextDouble() * 30);

                if (station == 0)
                {
                    ++station;
                    peopleStayed = peopleEntered;
                }
                else
                {
                    peopleStayed -= peopleLeft;
                    peopleStayed += peopleEntered;
                }

                var peopleFlow = new PeopleFlow(peopleEntered, peopleLeft, peopleStayed, 1);
                var messageString = JsonSerializer.Serialize(peopleFlow);
                var message = new Message(Encoding.UTF8.GetBytes(messageString));

                message.Properties.Add("peopleFlow", "true");

                await s_deviceClient.SendEventAsync(message).ConfigureAwait(false);

                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                await Task.Delay(1000).ConfigureAwait(false);
            } while (startTime < startTime.AddHours(19));
        }

        private static void Main()
        {
            Console.WriteLine("Vagao 1 iniciado com sucesso. Ctrl-C to exit.\n");

            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync().Wait();

            Environment.Exit(0);
        }
    }
}