FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HW_6_6/Web/EShop/EShop.csproj", "HW_6_6/Web/EShop/"]
RUN dotnet restore "HW_6_6/Web/EShop/EShop.csproj"
COPY . .
WORKDIR "/src/HW_6_6/Web/EShop"
RUN dotnet build "EShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.dll"]