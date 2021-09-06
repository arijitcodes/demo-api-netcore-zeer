# Demo api with C#, .NET Core, AWS SDK & DynamoDB (Local)

<hr />

`Author:` Arijit Banerjee

`Technologies Used:` C#, .NET Core, AWS-SDK, DynamoDB

<hr />

## Instruction:

#### To setup this API, follow the instructions carefully:

1.  Clone the Repo.
2.  Open a terminal and redirect in the `demo-api-zeer` directory.
3.  Setup your DynamoDB Access details in the 'Configs/DynamoDBConfigManager.cs'.
4.  Run `dotnet run` in Terminal.
5.  Now you can use the api accordingly.

NOTE: If `Step 4` doesn't work due to missing packages, then you have to restore using PM. You can try the following command: `dotnet restore` and then can try `dotnet run` again.

<hr />

## API Routes:

GET - `/welcome` : Welcome Route

<br />

GET - `/api/todos` : Get all Todos

GET - `/api/todos/{id}` : Get One Todo by ID

POST - `/api/todos` : Create a New Todo

PUT - `/api/todos/{id}` : Update a Todo

PATCH - `/api/todos/{id}` : Update/Alter the 'Completed' Status of a Todo

DELETE - `/api/todos/{id}` : Delete a Todo

<hr />
