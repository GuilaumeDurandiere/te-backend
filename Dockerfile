FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY "PortailTE44.Business/PortailTE44.Business.csproj" "./PortailTE44.Business/"
COPY "PortailTE44.Common/PortailTE44.Common.csproj" "./PortailTE44.Common/"
COPY "PortailTE44.DAL/PortailTE44.DAL.csproj" "./PortailTE44.DAL/"
COPY "PortailTE44.Exchange/PortailTE44.Exchange.csproj" "./PortailTE44.Exchange/"
RUN dotnet restore "./PortailTE44.Exchange/PortailTE44.Exchange.csproj"
COPY . .
RUN dotnet build "PortailTE44.Exchange/PortailTE44.Exchange.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PortailTE44.Exchange/PortailTE44.Exchange.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PortailTE44.Exchange.dll"]