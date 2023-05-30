#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductMicroservice/ProductAPI.csproj", "ProductMicroservice/"]
COPY ["ProductBLL/ProductBLL.csproj", "ProductBLL/"]
COPY ["ProductDAL/ProductDAL.csproj", "ProductDAL/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "ProductMicroservice/ProductAPI.csproj"
COPY . .
WORKDIR "/src/ProductMicroservice"
RUN dotnet build "ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAPI.dll"]