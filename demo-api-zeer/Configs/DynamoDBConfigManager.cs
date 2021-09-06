using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_api_zeer.Configs
{
    interface DynamoDBConfigManager
    {
        static readonly String AWS_ACCESS_KEY_ID = "accesskeyid";
        static readonly String AWS_SECRET_ACCESS_KEY = "secretaccesskey";
        static readonly String AWS_SERVICE_URL = "http://localhost:8000";
    }
}
