FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GerenciaJogos/GerenciaJogos.csproj", "GerenciaJogos/"]
RUN dotnet restore "GerenciaJogos/GerenciaJogos.csproj"
COPY . .
WORKDIR "/src/GerenciaJogos"
RUN dotnet build "GerenciaJogos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GerenciaJogos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GerenciaJogos.dll"]