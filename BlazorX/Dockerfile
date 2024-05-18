FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorX/BlazorX.csproj", "BlazorX/"]
RUN dotnet restore "BlazorX/BlazorX.csproj"
COPY . .
WORKDIR "/src/BlazorX"
RUN dotnet build "BlazorX.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorX.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorX.dll"]
