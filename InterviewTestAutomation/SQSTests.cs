using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace InterviewTestQA.InterviewTestAutomation
{
    public class SQSTests
    {

        public static string QueueUrl = "https://sqs.eu-west-2.amazonaws.com/216435942005/MySQSQueue";

        [Fact]
        public async Task SendSQSAsync()
        {
            var credentials = new BasicAWSCredentials("AKIATEZEWMJ25V76AHMG", "+QaFICfYvv+izues2Y9WP0n+zVzJfryGYvoMh/2b");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.EUWest2);
            var request = new SendMessageRequest()
            {
                QueueUrl = QueueUrl,
                MessageBody = "test message"
            };
            await client.SendMessageAsync(request);
        }


        [Fact]
        public static async Task GetMessages()
        {
            var credentials = new BasicAWSCredentials("AKIATEZEWMJ25V76AHMG", "+QaFICfYvv+izues2Y9WP0n+zVzJfryGYvoMh/2b");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.EUWest2);

            do
            {
                var msg = await GetMessage(client, QueueUrl, 1);
                Console.WriteLine(msg.Messages.Count);

                if (msg.Messages.Count != 0)
                {
                    foreach (var mess in msg.Messages)
                    {
                        Assert.Equal("test message", mess.Body);
                    }
                }

            } while (!Console.KeyAvailable);

        }

        private static async Task<ReceiveMessageResponse> GetMessage(
         IAmazonSQS sqsClient, string qUrl, int waitTime = 0)
        {
            return await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                QueueUrl = qUrl,
                MaxNumberOfMessages = 1,
                WaitTimeSeconds = waitTime
            });
        }

    }
}
