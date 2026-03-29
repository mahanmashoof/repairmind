# Stage 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY RepairMind.Core/ RepairMind.Core/
COPY RepairMind.Infrastructure/ RepairMind.Infrastructure/
COPY RepairMind.API/ RepairMind.API/

RUN dotnet restore RepairMind.API/RepairMind.API.csproj
RUN dotnet publish RepairMind.API/RepairMind.API.csproj -c Release -o /app/publish

# Stage 2 — Run
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RepairMind.API.dll"]

#**Stage 1** — uses the full SDK to build and publish the app
#*Stage 2** — uses the smaller runtime-only image to run it
#Two stages = smaller final container, build tools not shipped to production

## 3. Create a .dockerignore file

#*Tell Docker what to leave out of the container — like .gitignore but for Docker.*

#Create `.dockerignore` at the solution root:

#**/bin/
#**/obj/
#**/logs/
#*.db
#.git/