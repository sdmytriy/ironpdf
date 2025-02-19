#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

# install necessary packages
RUN apt update \
    && apt install -y sudo libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libappindicator3-1 libxrender1 libfontconfig1 xvfb
# update write permissions
RUN chmod 777 .

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