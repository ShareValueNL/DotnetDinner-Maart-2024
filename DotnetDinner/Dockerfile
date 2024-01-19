# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET SDK for building our application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DotnetDinner.csproj", "./"]
RUN dotnet restore "./DotnetDinner.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DotnetDinner.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "DotnetDinner.csproj" -c Release -o /app/publish

# Final stage / image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetDinner.dll"]