# Use .NET 8 SDK for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file to the working directory
COPY ["BodyMeasurementsTracker.csproj", "./"]

# Restore dependencies
RUN dotnet restore "BodyMeasurementsTracker.csproj"

# Copy the rest of the files and build the app
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use .NET 8 Runtime for running the app
FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BodyMeasurementsTracker.dll"]
