﻿# Downloads Pester NuGet package to sub-folder packages:
$pesterVersion = "1.0.5"

$path = Resolve-Path .
$pesterPackagePath = "$path\packages\Pester.$pesterVersion"
if (!(Test-Path $pesterPackagePath)) {
  Write-Host "Getting pester from nuget"
  nuget install Pester -Version $pesterVersion -o "$path\packages"
}

# Loads the module:
Import-Module "$pesterPackagePath\tools\Pester.psm1"

cls

# Runs tests in sub-folder src:
Invoke-Pester "$path\src"