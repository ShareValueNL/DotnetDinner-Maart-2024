# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DotnetDinnerApi.csproj", "./"]
RUN dotnet restore "./DotnetDinnerApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DotnetDinnerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetDinnerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetDinnerApi.dll"]