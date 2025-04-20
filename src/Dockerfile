# Stage 1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /src

COPY ./*.sln .
COPY ./nuget.config .
COPY ./Nora.Products.Api/Nora.Products.Api.csproj/ Nora.Products.Api/
COPY ./Nora.Products.Domain/Nora.Products.Domain.csproj/ Nora.Products.Domain/
COPY ./Nora.Products.Domain.Command/Nora.Products.Domain.Command.csproj/ Nora.Products.Domain.Command/
COPY ./Nora.Products.Domain.Query/Nora.Products.Domain.Query.csproj/ Nora.Products.Domain.Query/
COPY ./Nora.Products.Grpc/Nora.Products.Grpc.csproj/ Nora.Products.Grpc/
COPY ./Nora.Products.Infrastructure.Database/Nora.Products.Infrastructure.Database.csproj/ Nora.Products.Infrastructure.Database/

RUN dotnet restore
COPY . .

WORKDIR /src
RUN dotnet publish -c Release -o /app

# Stage 2

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8083
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8083

ENTRYPOINT ["dotnet", "Nora.Products.Api.dll"]