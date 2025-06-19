# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["MenuParser.API/MenuParser.API.csproj", "MenuParser.API/"]
COPY ["MenuParser.Application/MenuParser.Application.csproj", "MenuParser.Application/"]
COPY ["MenuParser.Infrastructure/MenuParser.Infrastructure.csproj", "MenuParser.Infrastructure/"]
COPY ["MenuParser.Domain/MenuParser.Domain.csproj", "MenuParser.Domain/"]

RUN dotnet restore "MenuParser.API/MenuParser.API.csproj"

COPY . .
WORKDIR "/src/MenuParser.API"
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MenuParser.API.dll"]
