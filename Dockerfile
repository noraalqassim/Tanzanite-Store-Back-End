FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5125

ENV ASPNETCORE_URLS=http://0.0.0.0:5125

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["sda-3-online-Backend_Teamwork/Backend.csproj", "sda-3-online-Backend_Teamwork/"]

RUN dotnet restore "sda-3-online-Backend_Teamwork/Backend.csproj"

COPY . .
WORKDIR "/src/sda-3-online-Backend_Teamwork"
RUN dotnet build "Backend.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Backend.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]

