FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TiendaService.Api.Book/TiendaService.Api.Book.csproj", "TiendaService.Api.Book/"]
RUN dotnet restore "TiendaService.Api.Book/TiendaService.Api.Book.csproj"
COPY . .
WORKDIR "/src/TiendaService.Api.Book"
RUN dotnet build "TiendaService.Api.Book.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TiendaService.Api.Book.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TiendaService.Api.Book.dll"]