FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Krooze.EntranceTest.Web/Krooze.EntranceTest.Web.csproj", "Krooze.EntranceTest.Web/"]
RUN dotnet restore "Krooze.EntranceTest.Web/Krooze.EntranceTest.Web.csproj"
COPY . .
WORKDIR "/src/Krooze.EntranceTest.Web"
RUN dotnet build "Krooze.EntranceTest.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Krooze.EntranceTest.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Krooze.EntranceTest.Web.dll"]