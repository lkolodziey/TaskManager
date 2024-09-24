FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EclipeWorksTaskManager/EclipeWorksTaskManager.csproj", "EclipeWorksTaskManager/"]
COPY ["EclipeWorksTaskManager.Domain.Core/EclipeWorksTaskManager.Domain.Core.csproj", "EclipeWorksTaskManager.Domain.Core/"]
COPY ["EclipeWorksTaskManager.Services/EclipeWorksTaskManager.Services.csproj", "EclipeWorksTaskManager.Services/"]
COPY ["EclipeWorksTaskManager.Infrastructure/EclipeWorksTaskManager.Infrastructure.csproj", "EclipeWorksTaskManager.Infrastructure/"]
RUN dotnet restore "EclipeWorksTaskManager/EclipeWorksTaskManager.csproj"
COPY . .
WORKDIR "/src/EclipeWorksTaskManager"
RUN dotnet build "EclipeWorksTaskManager.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EclipeWorksTaskManager.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EclipeWorksTaskManager.dll"]
