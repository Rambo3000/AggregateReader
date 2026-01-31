# Execute this PS1 file via Terminal in View
param(
    [switch]$test
)

$projectFilePath = "AggregateReader.csproj"
[xml]$projectFile = Get-Content $projectFilePath
$propertyGroup = $projectFile.Project.PropertyGroup | Where-Object { $_.Condition -eq $null }

if ($test.IsPresent) {
    $version = $propertyGroup.Version
    $date = Get-Date -Format "yyyyMMdd_HHmmss"
    $destination = ".\bin\AggregateReader " + $version + " beta $date.zip"
    Write-Host "----- Created new test version $version $date -----"
} else {
    $currentVersion = $propertyGroup.Version
    $versionComponents = $currentVersion -split '\.'
    $versionComponents[2] = [int]$versionComponents[2] + 1
    $newVersion = $versionComponents -join '.'
    $propertyGroup.Version = $newVersion
    $propertyGroup.FileVersion = $newVersion

    $destination = ".\bin\AggregateReader " + $newVersion + ".zip"
    $projectFile.Save($projectFilePath)
    Write-Host "----- Updated version numbers to $newVersion -----"
}

Write-Host "----- Publishing -----" 
dotnet publish -r win-x64 -c Release --nologo --self-contained

Write-Host "----- Cleaning publish folder -----" 
Remove-item ".\bin\Release\net10.0-windows\win-x64\publish\AggregateReader.pdb" -Force

Write-Host "----- Packing -----" 
$source = ".\bin\Release\net10.0-windows\win-x64\publish\"
If(Test-path $destination) {Remove-item $destination}
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($Source, $destination)

Write-Host "----- Cleaning up -----"
Remove-item ".\bin\Release\" -Recurse -Force

Write-Host "----- Open explorer -----"
Start ".\bin\"
