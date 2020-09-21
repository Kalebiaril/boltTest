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
RUN dotnet build "SearchWebApi.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "SearchWebApi.csproj" -c Development -o /app/publish

FROM node:8.9.4 as clientBuild
WORKDIR /ClientApp
COPY ClientApp/ .
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_11.x  | bash -
RUN apt-get -y install nodejs
COPY --from=publish /app/publish .
COPY --from=clientBuild ./ClientApp ./ClientApp
ENTRYPOINT ["dotnet", "SearchWebApi.dll"]



