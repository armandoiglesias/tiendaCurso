FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TiendaService.WebApi.Cart/TiendaService.WebApi.Cart.csproj", "TiendaService.WebApi.Cart/"]
RUN dotnet restore "TiendaService.WebApi.Cart/TiendaService.WebApi.Cart.csproj"
COPY . .
WORKDIR "/src/TiendaService.WebApi.Cart"
RUN dotnet build "TiendaService.WebApi.Cart.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TiendaService.WebApi.Cart.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TiendaService.WebApi.Cart.dll"]
