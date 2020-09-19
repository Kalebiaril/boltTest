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

FROM build AS publish
RUN dotnet publish "SearchWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apt-get update
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_11.x  | bash -
RUN apt-get -y install nodejs
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchWebApi.dll"]