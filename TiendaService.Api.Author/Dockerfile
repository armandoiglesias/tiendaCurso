FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TiendaService.Api.Author/TiendaService.Api.Author.csproj", "TiendaService.Api.Author/"]
RUN dotnet restore "TiendaService.Api.Author/TiendaService.Api.Author.csproj"
COPY . .
WORKDIR "/src/TiendaService.Api.Author"
RUN dotnet build "TiendaService.Api.Author.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TiendaService.Api.Author.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TiendaService.Api.Author.dll"]
