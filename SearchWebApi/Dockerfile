#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SearchWebApi.csproj", ""]
RUN dotnet restore "./SearchWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SearchWebApi.csproj" -c Release -o /app/build

FROM node:8.9.4 as clientBuild
WORKDIR /ClientApp
COPY src/SearchWebApi/ClientApp/ .
RUN npm install
RUN npm run build

FROM build AS publish
RUN dotnet publish "SearchWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchWebApi.dll"]