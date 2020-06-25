FROM fsharp:netcore AS build

# restore tools
WORKDIR /app/.config
COPY .config .
RUN dotnet tool restore

# restore nuget packages
WORKDIR /app
COPY paket.dependencies .
COPY paket.lock .
RUN dotnet paket restore

WORKDIR /app/src/hello_world
COPY src/hello_world/*.fsproj .
COPY src/hello_world/paket.references .
RUN dotnet restore

WORKDIR /app/src/Unit.Tests
COPY src/Unit.Tests/*.fsproj .
COPY src/Unit.Tests/paket.references .
RUN dotnet restore

# copy source code
WORKDIR /app/src
COPY src .

# unit tests
WORKDIR /app/src/Unit.Tests
ENTRYPOINT dotnet test

# # publish HelloWorld
# WORKDIR /app/src/hello_world
# RUN dotnet publish --no-restore -c Release -o out

# # run HelloWorld
# FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine
# WORKDIR /bin
# COPY --from=build /app/src/hello_world/out .
# EXPOSE 8080
# ENTRYPOINT [ "dotnet", "HelloWorld.dll" ]