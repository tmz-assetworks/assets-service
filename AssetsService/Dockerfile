FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 6009

FROM base AS final
WORKDIR /app
COPY /publish /app
ENTRYPOINT ["dotnet", "AssetsService.Api.dll"]