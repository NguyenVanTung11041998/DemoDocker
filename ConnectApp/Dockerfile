#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConnectApp/ConnectApp.csproj", "ConnectApp/"]
RUN dotnet restore "ConnectApp/ConnectApp.csproj"
COPY . .
WORKDIR "/src/ConnectApp"
RUN dotnet build "ConnectApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConnectApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConnectApp.dll"]