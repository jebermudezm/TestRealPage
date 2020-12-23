FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/RealPage.Properties.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /src/RealPage.Properties.Services.WebApi/out ./

ENTRYPOINT ["dotnet", "RealPage.Properties.Services.WebApi.dll"]
