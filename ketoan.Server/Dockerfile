# Stage 1: Build project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy file .csproj và restore dependencies
COPY ["ketoan.Server/ketoan.Server.csproj", "ketoan.Server/"]
RUN dotnet restore "ketoan.Server/ketoan.Server.csproj"

# Copy toàn bộ source code
COPY . .

# Chuyển vào thư mục chứa project để publish
WORKDIR "/src/ketoan.Server"
RUN dotnet publish "ketoan.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ketoan.Server.dll"]