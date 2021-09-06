using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_api_zeer.Models
{
    [DynamoDBTable("todos-api")]
    public class TodosModel
    {
        [DynamoDBHashKey]
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String Title { get; set; }
        public String Details { get; set; }
        public Boolean Completed { get; set; }

    }
}
