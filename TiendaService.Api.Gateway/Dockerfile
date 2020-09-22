FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TiendaService.Api.Gateway/TiendaService.Api.Gateway.csproj", "TiendaService.Api.Gateway/"]
RUN dotnet restore "TiendaService.Api.Gateway/TiendaService.Api.Gateway.csproj"
COPY . .
WORKDIR "/src/TiendaService.Api.Gateway"
RUN dotnet build "TiendaService.Api.Gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TiendaService.Api.Gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TiendaService.Api.Gateway.dll"]
