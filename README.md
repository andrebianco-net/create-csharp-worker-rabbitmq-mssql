# create-csharp-worker-rabbitmq-mssql

## Overview:
Creating a C# .NET Core Worker based on Clean Architecture.

This example is an implementation where I adapted a Worker layer to work together clean architecture layers. Read [readme file ](https://github.com/andrebianco-net/andrebianco-net#readme) in order to obtain more details about the finality of this solution.

In order to know more aboute my career check my Linkedin profile, please.

https://www.linkedin.com/in/andrebianco-net/

## General Scope:

Sales Order Receiver implementation propose a small example of how to create a Worker service using C#.

C# .NET Core Worker based on Clean Architecture, using Worker, Repository and xUnit to test the implementation. It will use Microsoft SQL Server database and RabbitMQ/Docker as an integration queue.  

The Solution will be a Worker which consumes messages (Sales Orders) from RabbitMQ integration queue and use Microsoft SQL Server to store the purchases in the end of the process.

## How to run this project

#### 1. Clone project:

$ git clone https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql.git

#### 2. Update file appsettings.json with a valid:

First, rename the file appsettings.template to appsettings.json.

Second, update the default connection string to allow access to Microsoft SQL Server.

"ConnectionStrings": {
    "DefaultConnection": "YOUR CONNECTION STRING"
},

Third, update the RabbitMQ section with a valid Uri.

"RabbitMQ": {
    "Uri": "amqp://YOUR USER:YOUR PASSWORD@YOUR HOST:5672",
    "ClientProvidedName": "Sales Order Receiver",
    "ExchangeName": "ExchangeSalesOrder",
    "RoutingKey": "sales-order-01",
    "QueueName": "SalesOrder",
    "BasicQosPrefetchSize": 0,
    "BasicQosPrefetchCount": 10,
    "BasicQosGlobal": true
}

#### 3. Compile project:

$ dotnet build

#### 4. Test project:

$ dotnet test

#### 5. Run project:

$ dotnet run --project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj

#### 6. Microsoft SQL Server/Entity Framework Migrations

Create migrations: dotnet ef migrations add InitialDatabase --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]

Update database: dotnet ef database update --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]

[ Remove migrations: dotnet ef migrations remove --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]

[ List migrations: dotnet ef migrations list --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]

#### 7. Set the log folder

Define a real path to the log.

"Serilog": {
    "Folder": "Log",
    "File": "SalesOrderReceiverServiceWorker.log",
    "Size": 5242880
},

#### 8. RabbitMQ/Docker

Useful commands:

$ sudo systemctl status docker

$ docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management

$ sudo docker container ls --all --quiet --no-trunc --filter "name=rabbit-server"

$ sudo docker start FULL-CONTAINER-ID

$ sudo docker stop FULL-CONTAINER-ID

Access to http://localhost:8080/#/ and consider use guest/guest to access if it's the case
