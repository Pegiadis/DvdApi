# Use the base image for ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the base image for .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["DvdApi/DvdApi.csproj", "DvdApi/"]
RUN dotnet restore "DvdApi/DvdApi.csproj"

# Copy the remaining source code
COPY . .

WORKDIR "/src/DvdApi"

# Build the application
RUN dotnet build "DvdApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "DvdApi.csproj" -c Release -o /app/publish

# Use the base image for ASP.NET Core runtime for the final container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DvdApi.dll"]
