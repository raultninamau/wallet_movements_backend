FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers

COPY *.sln .

COPY src/api/Movements.Server/*.csproj ./src/api/Movements.Server/
COPY src/api/Movements.Rest.Api/*.csproj ./src/api/Movements.Rest.Api/
COPY src/core/domain/Movements.Domain/*.csproj ./src/core/domain/Movements.Domain/
COPY src/core/services/Movements.Services.Implementations/*.csproj ./src/core/services/Movements.Services.Implementations/
COPY src/core/services/Movements.Services.Interfaces/*.csproj ./src/core/services/Movements.Services.Interfaces/
COPY src/dao/Movements.Dao.Implementations/*.csproj ./src/dao/Movements.Dao.Implementations/
COPY src/dao/Movements.Dao.Interfaces/*.csproj ./src/dao/Movements.Dao.Interfaces/
COPY src/dao/Movements.Dao.SQLServer/*.csproj ./src/dao/Movements.Dao.SQLServer/

RUN dotnet restore

# copy everything else and build app
COPY src/api/Movements.Server/. ./src/api/Movements.Server/
COPY src/api/Movements.Rest.Api/. ./src/api/Movements.Rest.Api/
COPY src/core/domain/Movements.Domain/. ./src/core/domain/Movements.Domain/
COPY src/core/services/Movements.Services.Implementations/. ./src/core/services/Movements.Services.Implementations/
COPY src/core/services/Movements.Services.Interfaces/. ./src/core/services/Movements.Services.Interfaces/
COPY src/dao/Movements.Dao.Implementations/. ./src/dao/Movements.Dao.Implementations/
COPY src/dao/Movements.Dao.Interfaces/. ./src/dao/Movements.Dao.Interfaces/
COPY src/dao/Movements.Dao.SQLServer/. ./src/dao/Movements.Dao.SQLServer/

WORKDIR /app/src/api/Movements.Server
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:81
EXPOSE 81

COPY --from=build /app/src/api/Movements.Server/out ./
ENTRYPOINT ["dotnet", "Movements.Server.dll"]