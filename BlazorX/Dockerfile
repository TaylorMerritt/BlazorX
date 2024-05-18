# Stage 1: Build and publish the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore the project files
COPY ["BlazorX/BlazorX.csproj", "BlazorX/"]
RUN dotnet restore "BlazorX/BlazorX.csproj"

# Copy the rest of the application code
COPY . .
WORKDIR "/src/BlazorX"
RUN dotnet build "BlazorX.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "BlazorX.csproj" -c $BUILD_CONFIGURATION -o /app/out

# Stage 2: Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80

# Copy the publish output from the build stage
COPY --from=build /app/out .

# Start the application
ENTRYPOINT ["dotnet", "BlazorX.dll"]
