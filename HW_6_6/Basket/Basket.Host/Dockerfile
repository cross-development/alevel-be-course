FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HW_6_6/Basket/Basket.Host/Basket.Host.csproj", "HW_6_6/Basket/Basket.Host/"]
RUN dotnet restore "HW_6_6/Basket/Basket.Host/Basket.Host.csproj"
COPY . .
WORKDIR "/src/HW_6_6/Basket/Basket.Host"
RUN dotnet build "Basket.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.Host.dll"]