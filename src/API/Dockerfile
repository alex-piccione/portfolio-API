FROM mcr.microsoft.com/dotnet/sdk:7.0 as builder
WORKDIR /app
COPY . .

RUN dotnet restore
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release --no-build --no-self-contained --output /publish

FROM mcr.microsoft.com/dotnet/runtime:7.0 as runner
WORKDIR /app
COPY --from=builder /publish .

CMD ["dotnet", ""]

# test locally, from src/API foilder, with 
# cd src/API
# docker build --tag portfolio-api-local:0.1 --no-cache .