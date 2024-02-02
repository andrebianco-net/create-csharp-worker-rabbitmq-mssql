FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

COPY SalesOrderReceiverService.Worker/bin/Debug/net7.0 /app

#RUN ls /app

ENTRYPOINT ["dotnet", "SalesOrderReceiverService.Worker.dll"]

