# Stage 1: Build project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ketoan.Server/ketoan.Server.csproj", "ketoan.Server/"]
RUN dotnet restore "ketoan.Server/ketoan.Server.csproj"
COPY . .
RUN dotnet publish "ketoan.Server.csproj" -c Release -o /app/publish

# Stage 2: Run project
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "ketoan.Server.dll"]