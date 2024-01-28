FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LGK.Gecko/LGK.Gecko.csproj", "LGK.Gecko/"]
RUN dotnet restore "LGK.Gecko/LGK.Gecko.csproj"
COPY . .
WORKDIR "/src/LGK.Gecko"
RUN dotnet build "LGK.Gecko.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LGK.Gecko.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LGK.Gecko.dll"]
