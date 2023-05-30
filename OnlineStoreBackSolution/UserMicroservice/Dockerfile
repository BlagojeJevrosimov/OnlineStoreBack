#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserMicroservice/UserAPI.csproj", "UserMicroservice/"]
COPY ["BLL/UserBLL.csproj", "BLL/"]
COPY ["DLL/UserDAL.csproj", "DLL/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "UserMicroservice/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserMicroservice"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAPI.dll"]