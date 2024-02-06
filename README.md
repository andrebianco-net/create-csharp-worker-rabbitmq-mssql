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

```bash
$ git clone https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql.git
```

#### 2. Update file appsettings.json with a valid:

First, rename the file appsettings.template to appsettings.json.

Second, update the default connection string to allow access to Microsoft SQL Server.

```json
"ConnectionStrings": {
    "DefaultConnection": "YOUR CONNECTION STRING"
},
```

Third, update the RabbitMQ section with a valid Uri.

```json
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
```

#### 3. Compile project:

```bash
$ dotnet build
```

#### 4. Test project:

```bash
$ dotnet test
```

#### 5. Run project:

```bash
$ dotnet run --project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj
```

#### 6. Microsoft SQL Server/Entity Framework Migrations

<ins>Create migrations:</ins>
```bash
$ dotnet ef migrations add InitialDatabase --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]
```

<ins>Update database:</ins>
```bash
$ dotnet ef database update --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj [ --verbose ]
```

<ins>Remove migrations:</ins>
```bash
[$ dotnet ef migrations remove --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj] [ --verbose ]
```

<ins>List migrations:</ins>
```bash
[$ dotnet ef migrations list --project SalesOrderReceiverService.Infra.Data/SalesOrderReceiverService.Infra.Data.csproj --startup-project SalesOrderReceiverService.Worker/SalesOrderReceiverService.Worker.csproj] [ --verbose ]
```

#### 7. Set the log folder

Define a real path to the log.

```json
"Serilog": {
    "Folder": "Log",
    "File": "SalesOrderReceiverServiceWorker.log",
    "Size": 5242880
},
```

#### 8. RabbitMQ/Docker (localhost)

<ins>Useful commands:</ins>

```bash
$ sudo systemctl status docker
```

```bash
$ docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management
```

```bash
$ sudo docker container ls --all --quiet --no-trunc --filter "name=rabbit-server"
```

```bash
$ sudo docker start FULL-CONTAINER-ID
```

```bash
$ sudo docker stop FULL-CONTAINER-ID
```

Access to http://localhost:8080/#/ and consider use guest/guest to access if it's the case

#### 9. From Docker to Azure Container

```bash
$ docker build -t salesorder-receiver-service .
```

```bash
[$ docker run -it salesorder-receiver-service]
```

```bash
$ docker login youruricreatedinazurecontainerregistry.azurecr.io
```

```bash
$ docker tag salesorder-receiver-service youruricreatedinazurecontainerregistry.azurecr.io/salesorder-receiver-service
```

```bash
$ docker push youruricreatedinazurecontainerregistry.azurecr.io/salesorder-receiver-service
```

```bash
[$ docker pull youruricreatedinazurecontainerregistry.azurecr.io/salesorder-receiver-service]
```

#### 10. Created in Azure Cloud Computing

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql/assets/453193/01a8c500-744e-48d5-b4c8-f530f021e5c8)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql/assets/453193/a62d382d-231f-41cf-aac9-36f744e10a88)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql/assets/453193/47939540-30fd-45bc-9197-27e4ca18c25f)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mssql/assets/453193/9288e591-ad2e-43e6-ab04-48adbbdcccdf)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/b965fae7-422f-40c7-ab0d-2070f2922fb9)

###
![image](https://github.com/andrebianco-net/create-csharp-worker-rabbitmq-mongodb/assets/453193/b824813c-9b2c-4ded-9e17-369ca77e26e0)
