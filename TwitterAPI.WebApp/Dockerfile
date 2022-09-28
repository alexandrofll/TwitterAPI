#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TwitterAPI.WebApp/TwitterAPI.WebApp.csproj", "TwitterAPI.WebApp/"]
RUN dotnet restore "TwitterAPI.WebApp/TwitterAPI.WebApp.csproj"
COPY . .
WORKDIR "/src/TwitterAPI.WebApp"
RUN dotnet build "TwitterAPI.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwitterAPI.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwitterAPI.WebApp.dll"]