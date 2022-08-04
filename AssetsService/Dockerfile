#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6009
EXPOSE 443


FROM base AS final
WORKDIR /app
COPY /app/publish /app/publish .
ENV DB_HOST=10.0.0.5
ENV DB_NAME=asset_db
ENV DB_SA_PASSWORD=AssetWorks@123$
ENTRYPOINT ["dotnet", "AssetsService.Api.dll"]