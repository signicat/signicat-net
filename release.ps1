# Get current version
$csprojPath = "$pwd/src/Signicat.SDK/Signicat.SDK.csproj"
$xml = New-Object XML
$xml.PreserveWhitespace = $true
$xml.Load($csprojPath)

$currentVersion = $xml.Project.PropertyGroup.VersionPrefix

if ([String]::IsNullOrWhiteSpace($currentVersion)) {
	Write-Host "Current version not found." -ForegroundColor Red
	exit 1
}

$versionParts = $currentVersion.TrimEnd("*-").Split(".")
$currentMajor = [Convert]::ToInt32($versionParts[0])
$currentMinor = [Convert]::ToInt32($versionParts[1])
$currentPatch = [Convert]::ToInt32($versionParts[2])

Write-Host "Current version: $currentMajor.$currentMinor.$currentPatch" -ForegroundColor Yellow

# Bump version
Write-Host "Which part of the version to bump (major|minor|patch)?"

$toBump = Read-Host

if ($toBump -eq "major") {
	$currentMajor++
	$currentMinor = 0
	$currentPatch = 0
}
elseif ($toBump -eq "minor") {
	$currentMinor++
	$currentPatch = 0
}
elseif($toBump -eq "patch") {
	$currentPatch++
}
else {
	Write-Host "$toBump is not a valid part of the version number." -ForegroundColor Red
	exit 1
}

$newVersion = "$currentMajor.$currentMinor.$currentPatch";

Write-Host "New version: $newVersion"

# Update .csproj
$xml.Project.PropertyGroup.VersionPrefix = $newVersion
$xml.Save($csprojPath)

Write-Host "Version updated in Project file. Enter the new version to confirm release."

$confirmedVersion = Read-Host

if ($confirmedVersion -ne $newVersion) {
	Write-Host "Release canceled" -ForegroundColor Red
	exit 1
}

# Git commit version bump
Write-Host "Committing new version"
git add $csprojPath
git commit -m "Release $newVersion"
git push origin master

# Create tag
$tag = "v$newVersion"
git tag $tag
git push origin $tag