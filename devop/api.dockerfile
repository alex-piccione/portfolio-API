FROM mcr.microsoft.com/dotnet/sdk:7.0 as builder
WORKDIR /app
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY Portfolio.API.sln .
COPY ./API ./API

RUN dotnet restore Portfolio.API.sln
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release ./API --no-build --no-self-contained --output /publish

FROM mcr.microsoft.com/dotnet/runtime:7.0 as runner
WORKDIR /app
COPY --from=builder /publish .

CMD ["dotnet", ""]

# test locally, from root folder, with 
# docker build --tag portfolio-api-local:0.1 --no-cache -f ./devop/api.dockerfile ./src
