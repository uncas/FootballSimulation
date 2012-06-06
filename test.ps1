# Downloads Pester NuGet package to sub-folder packages:
#nuget install pester -o packages -s C:\NuGetPackages

# Determines the path to the newest Pester package:
#$path = Resolve-Path .
#$pesterPackage = gci "$path\packages\Pester.*"
#if ($pesterPackage.count) {
#  $pesterPackage = $pesterPackage[$pesterPackage.count-1]
#}
#$pesterPackagePath = $pesterPackage.FullName
$pesterPackagePath = "D:\Projects\UncasOpenSource\PesterDemo\packages\Pester.1.0.4.55"

# Loads the module:
Import-Module "$pesterPackagePath\tools\Pester.psm1"

cls

# Runs tests in sub-folder src:
Invoke-Pester #"$path\src"