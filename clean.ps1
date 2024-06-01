# Stop all containers
docker compose down

# Delete Persistent storage
Get-ChildItem -Path ".\*-data" -Directory | ForEach-Object {
    $dataPath = $_.FullName

    Get-ChildItem -Path $dataPath -Exclude "*.md" -Recurse | Remove-Item -Force -Recurse -Verbose
}

# Remove any networks
docker network prune -f

# Get-ChildItem -Path ".\deploy" -Directory | ForEach-Object {
#     $deployPath = $_.FullName

#     Get-ChildItem -Path $deployPath -Exclude ".gitkeep" -Recurse | Remove-Item -Force -Recurse -Verbose
# }

Write-Host "Clean up completed."
