# Stop all containers
docker compose down

# Delete Persistent storage
Get-ChildItem -Path ".\docker\data\*-data" -Directory | ForEach-Object {
    $dataPath = $_.FullName

    Get-ChildItem -Path $dataPath -Exclude .gitkeep,*.md -Recurse | Remove-Item -Force -Recurse -Verbose
}

# Delete artifacts
Get-ChildItem -Path ".\docker\deploy" -Directory | ForEach-Object {
    $deployPath = $_.FullName

    Get-ChildItem -Path $deployPath -Exclude .gitkeep,*.md -Recurse | Remove-Item -Force -Recurse -Verbose
}

# Remove any networks
docker network prune -f

Write-Host "Clean up completed."
