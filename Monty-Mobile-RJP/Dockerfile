#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Monty-Mobile-RJP/Monty-Mobile-RJP.csproj", "Monty-Mobile-RJP/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Monty-Mobile-RJP/Monty-Mobile-RJP.csproj"
COPY . .
WORKDIR "/src/Monty-Mobile-RJP"
RUN dotnet build "Monty-Mobile-RJP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monty-Mobile-RJP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monty-Mobile-RJP.dll"]