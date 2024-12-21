# Use the official .NET Core SDK image as the build image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BodyMeasurementsTracker/BodyMeasurementsTracker.csproj", "BodyMeasurementsTracker/"]
RUN dotnet restore "BodyMeasurementsTracker/BodyMeasurementsTracker.csproj"
COPY . .
WORKDIR "/src/BodyMeasurementsTracker"
RUN dotnet build "BodyMeasurementsTracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BodyMeasurementsTracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BodyMeasurementsTracker.dll"]
