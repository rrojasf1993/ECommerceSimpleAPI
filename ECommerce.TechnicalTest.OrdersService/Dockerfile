FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerce.TechnicalTest.OrdersService/ECommerce.TechnicalTest.OrdersService.csproj", "ECommerce.TechnicalTest.OrdersService/"]
COPY ["ECommerce.TechnicalTest.Cross/ECommerce.TechnicalTest.Cross.csproj", "ECommerce.TechnicalTest.Cross/"]
COPY ["ECommerce.TechnicalTest.Domain/ECommerce.TechnicalTest.Domain.csproj", "ECommerce.TechnicalTest.Domain/"]
COPY ["ECommerce.TechnicalTest.Data/ECommerce.TechnicalTest.Data.csproj", "ECommerce.TechnicalTest.Data/"]
COPY ["ECommerce.TechnicalTest.Services/ECommerce.TechnicalTest.Services.csproj", "ECommerce.TechnicalTest.Services/"]
RUN dotnet restore "ECommerce.TechnicalTest.OrdersService/ECommerce.TechnicalTest.OrdersService.csproj"
COPY . .
WORKDIR "/src/ECommerce.TechnicalTest.OrdersService"
RUN dotnet build "ECommerce.TechnicalTest.OrdersService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ECommerce.TechnicalTest.OrdersService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.TechnicalTest.OrdersService.dll"]
