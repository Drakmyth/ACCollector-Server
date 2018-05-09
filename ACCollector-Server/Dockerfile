# Stage 1 - Build
FROM microsoft/aspnetcore-build as buildimg
WORKDIR /src

# Cache restore result by copying csproj separately
COPY *.csproj .
RUN dotnet restore

# Copy code
COPY . .
RUN dotnet publish --output /publish -- configuration Release

# Stage 2 - Publish
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=buildimg /publish .
ENTRYPOINT ["dotnet", "ACCollector-Server.dll"]