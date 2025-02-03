FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["src/Web/Web.csproj", "src/Web/"]

RUN dotnet restore "src/Web/Web.csproj"

COPY src/ .

WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c Debug -o /app/build

RUN dotnet publish "Web.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Web.dll"]