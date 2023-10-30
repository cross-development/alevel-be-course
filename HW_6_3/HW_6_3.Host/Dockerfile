FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HW_6_3/HW_6_3.Host/HW_6_3.Host.csproj", "HW_6_3/HW_6_3.Host/"]
RUN dotnet restore "HW_6_3/HW_6_3.Host/HW_6_3.Host.csproj"
COPY . .
WORKDIR "/src/HW_6_3/HW_6_3.Host"
RUN dotnet build "HW_6_3.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW_6_3.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HW_6_3.Host.dll"]