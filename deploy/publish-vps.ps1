dotnet build -c Release /p:DeployOnBuild=true /p:PublishProfile=Properties\PublishProfiles\vps.pubxml $PSScriptRoot\..\src\Budgeteer.csproj

$tar = deploy.tar.gz

tar czf $tar $PSScriptRoot/linux

