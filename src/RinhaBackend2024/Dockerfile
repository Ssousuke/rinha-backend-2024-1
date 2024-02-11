# Base image for running ASP.NET applications
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Define the user for running the application
USER app

# Set the working directory for the application
WORKDIR /app

# Expose the ports that the application listens on
EXPOSE 8080
EXPOSE 8081

# Build image for compiling and building .NET applications
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the build configuration (e.g., Release, Debug)
ARG BUILD_CONFIGURATION=Release

# Set the working directory for the build process
WORKDIR /src

# Copy the project file into the container
COPY ["RinhaBackend2024.csproj", "./"]

# Restore the NuGet packages for the project
RUN dotnet restore "./RinhaBackend2024.csproj"

# Copy the rest of the application source code into the container
COPY . .

# Set the working directory to the project directory
WORKDIR "./"

# Build the application
RUN dotnet build "./RinhaBackend2024.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Image for publishing the application
FROM build AS publish

# Publish the application
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RinhaBackend2024.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image for running the published application
FROM base AS final

# Set the working directory for the final image
WORKDIR /app

# Copy the published application into the final image
COPY --from=publish /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "RinhaBackend2024.dll"]
