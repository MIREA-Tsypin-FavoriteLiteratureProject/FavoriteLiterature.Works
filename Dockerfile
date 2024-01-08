FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
COPY . .

LABEL maintainer="Tsypin Ilya <tsypin.i.p@mail.ru>"
LABEL version="1.0"
LABEL description="FavLit.Works project image"

RUN dotnet restore --configfile ./NuGet.Config
RUN dotnet build --no-restore
RUN dotnet publish -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=base /app/publish ./

ENV ASPNETCORE_HTTP_PORT=80
ENV ASPNETCORE_DEBUG_PORT=84
EXPOSE 80
EXPOSE 84
ENTRYPOINT ["dotnet", "/app/FavoriteLiterature.Works.API.dll"]