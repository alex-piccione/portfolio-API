# run the API on local machine

echo "Build"
dotnet publish -c "Release" ./src/*.sln --output ./publish

echo "run!"
dotnet ./publish/API.dll

echo "Adios!"