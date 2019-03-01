$chocoUrl   = "https://chocolatey.org/install.ps1"

iex ((New-Object System.Net.WebClient).DownloadString($chocoUrl))

choco install git -y