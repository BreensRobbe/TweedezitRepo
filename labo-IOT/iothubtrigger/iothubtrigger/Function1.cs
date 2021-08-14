using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;
using iothubtrigger.Models;

namespace iothubtrigger
{
    public static class Function1
    {
        private static HttpClient client = new HttpClient();
        


        [FunctionName("Function1")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IoTHub")]EventData message, ILogger log)
        {


            Item item = new Item();

            item.id = "1";
            item.MessageText = Encoding.UTF8.GetString(message.Body.Array);

            AddItemAsync(item);
             



            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }


        public static async Task AddItemAsync(Item item)
        {
            try
            {
                CosmosClientOptions clientOptions = new CosmosClientOptions();
                clientOptions.ConnectionMode = Microsoft.Azure.Cosmos.ConnectionMode.Gateway;

                CosmosClient cosmosClient = new CosmosClient(Environment.GetEnvironmentVariable("cosmosDb"), clientOptions);
                Container container = cosmosClient.GetContainer("iotclouddb", "tabel");
                ItemResponse<Item> response = await container.CreateItemAsync<Item>(item, new PartitionKey(item.id));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}