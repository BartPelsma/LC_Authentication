#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 9001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LC_Authentication/LC_Authentication.csproj", "LC_Authentication/"]
RUN dotnet restore "LC_Authentication/LC_Authentication.csproj"
COPY . .
WORKDIR "/src/LC_Authentication/"
RUN dotnet build "LC_Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LC_Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LC_Authentication.dll"]
