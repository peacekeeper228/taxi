FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ./gateway/Gateway ./gateway/Gateway
COPY ./auth-service/AuthService.Proto ./auth-service/AuthService.Proto
RUN dotnet restore ./gateway/Gateway
RUN dotnet publish ./gateway/Gateway/Gateway.csproj -c Release -o out

EXPOSE 4000

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Gateway.dll"]