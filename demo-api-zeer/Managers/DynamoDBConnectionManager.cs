using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using demo_api_zeer.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_api_zeer.Managers
{
    public class DynamoDBConnectionManager
    {
        public AmazonDynamoDBClient client;
        public DynamoDBContext context;
        AmazonDynamoDBConfig dynamodbconfig = new AmazonDynamoDBConfig() { ServiceURL = DynamoDBConfigManager.AWS_SERVICE_URL };
        BasicAWSCredentials credentials = new BasicAWSCredentials(DynamoDBConfigManager.AWS_ACCESS_KEY_ID, DynamoDBConfigManager.AWS_SECRET_ACCESS_KEY);

        public void connection()
        {
            try
            {
                client = new AmazonDynamoDBClient(credentials, dynamodbconfig);
                context = new DynamoDBContext(client);
            }
            catch (AmazonDynamoDBException e)
            {
                Console.WriteLine("Failed to Create a DynamoDB Client! ", e.Message);
                throw;
            }
        }
    }
}
