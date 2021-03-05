#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

RUN ["apt-get", "update"]
RUN ["apt-get", "-y", "install", "libgdiplus"]
RUN ["apt-get", "-y", "install", "xvfb", "libfontconfig", "wkhtmltopdf"]
RUN ["apt-get", "-y", "install", "libc6-dev"]
RUN ["apt-get", "-y", "install", "openssl"]
RUN ["apt-get", "-y", "install", "libssl-dev"]

ENV ASPNETCORE_URLS=http://+:5000

WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronPdf/IronPdfMin.csproj", "IronPdf/"]
RUN dotnet restore "IronPdf/IronPdfMin.csproj"
COPY . .
WORKDIR "/src/IronPdf"
RUN dotnet build "IronPdfMin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IronPdfMin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IronPdfMin.dll"]