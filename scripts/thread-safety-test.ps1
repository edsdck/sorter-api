# credits https://stackoverflow.com/a/31525044

$maxConcurrentJobs = 10
$baseUri = "https://localhost:7073/api/sort"
  
$Runspace = [runspacefactory]::CreateRunspacePool(1,$maxConcurrentJobs)
$Runspace.Open()

$body = @{
 "numbers"=7,3,3,1
} | ConvertTo-Json

$i=1
for(;$i -le 10;$i++)
{
    $ps = [powershell]::Create()
    $ps.RunspacePool = $Runspace

    [void]$ps.AddCommand("Invoke-WebRequest").
        AddParameter("Uri", $baseUri).
        AddParameter("Method", "POST").
        AddParameter("ContentType", "application/json").
        AddParameter("Body", $body)

    [void]$ps.BeginInvoke()

    Write-Host ("Initiated request for {0}" -f $i)
}