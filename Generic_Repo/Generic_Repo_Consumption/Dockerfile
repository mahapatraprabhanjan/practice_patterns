FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Generic_Repo_Consumption/Generic_Repo_Consumption.csproj Generic_Repo_Consumption/
COPY Generic_Repo/Generic_Repo.csproj Generic_Repo/
RUN dotnet restore Generic_Repo_Consumption/Generic_Repo_Consumption.csproj
COPY . .
WORKDIR /src/Generic_Repo_Consumption
RUN dotnet build Generic_Repo_Consumption.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Generic_Repo_Consumption.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Generic_Repo_Consumption.dll"]
