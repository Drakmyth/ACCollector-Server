$page = Invoke-WebRequest -Uri https://nookipedia.com/wiki/Fossil -Method Get

$tableIndex = 3 # 2 = non-standalone, 3 = standalone
$group = "Standalone"

$table = $page.ParsedHtml.getElementsByTagName("table")[$tableIndex]

$ACFossils = @()
$WWFossils = @()
$CFFossils = @()
$NLFossils = @()

$first = $true
foreach ($row in $table.rows) {

    if ($first) {
        $first = $false
        continue
    }

    if ($row.cells.length -eq 1) {
        $group = $row.cells[0].innerText.Trim()
        continue
    }

    $fossil = @{}
    $fossil.Name = $row.cells[0].innerText.Trim()
    $fossil.SalePrice =  [int]$row.cells[1].innerText
    $fossil.Group = $group
    $fossil = New-Object -TypeName PSObject -Prop $fossil
    
    $games = $row.cells[5].innerText

    if ($games.Contains("AC")) {
        $ACFossils += $fossil
    }

    if ($games.Contains("WW")) {
        $WWFossils += $fossil
    }

    if ($games.Contains("CF")) {
        $CFFossils += $fossil
    }

    if ($games.Contains("NL")) {
        $NLFossils += $fossil
    }
}

function Build-Fossil-Folder {
    param
    (
        [Parameter(Mandatory=$true)]$folderName,
        [Parameter(Mandatory=$true)]$fossilArray
    )

    $folder = @{}
    $folder.name = $folderName
    $folder.description = ""
    $items = @()

    foreach($fossil in $fossilArray) {
        $items += Build-Fossil $fossil
    }

    $folder.item = $items
    $folder._postman_isSubFolder = $true
    return New-Object -TypeName PSObject -Prop $folder
}

function Build-Fossil {
    param
    (
        [Parameter(Mandatory=$true)]$fossil
    )

    begin {
        Write-Host "Processing fossil: $($fossil.Name)"
    }

    process {
        $postman = @{}
        $postman.name = $fossil.Name

        $event = @{}
        $event.listen = "test"
    
        $script = @{}
        $script.type = "text/javascript"
        $script.exec = @("pm.test(`"Status code is 201`", function () {", "    pm.response.to.have.status(201);", "});")
        $script = New-Object -TypeName PSObject -Prop $script

        $event.script = $script
        $event = New-Object -TypeName PSObject -Prop $event

        $postman.event = @($event)
        $postman.response = @()

        $request = @{}
        $request.method = "POST"
    
        $header = @{}
        $header.key = "Content-Type"
        $header.value = "application/json"
        $header = New-Object -TypeName PSObject -Prop $header

        $request.header = @($header)
    
        $body = @{}
        $body.mode = "raw"
        $body.raw = "{`n`t`"name`": `"$($fossil.Name)`",`n`t`"salePrice`": $($fossil.SalePrice),`n`t`"group`": `"$($fossil.Group)`"`n}"
        $body = New-Object -TypeName PSObject -Prop $body

        $request.body = $body

        $url = @{}
        $url.raw = "{{host}}/api/games/{{gameId}}/fossils"
        $url.host = @("{{host}}")
        $url.path = @("api", "games", "{{gameId}}", "fossils")
        $url = New-Object -TypeName PSObject -Prop $url

        $request.url = $url
        $request.description = ""
        $request = New-Object -TypeName PSObject -Prop $request

        $postman.request = $request
        $postman = New-Object -TypeName PSObject -Prop $postman

        return $postman
    }
}

$folders = @()
$folders += Build-Fossil-Folder "ACFossils" $ACFossils
$folders += Build-Fossil-Folder "CFFossils" $CFFossils
$folders += Build-Fossil-Folder "NLFossils" $NLFossils
$folders += Build-Fossil-Folder "WWFossils" $WWFossils

$json = ConvertTo-Json -InputObject $folders -Depth 10
$json | Out-File C:\Users\shaunh\Documents\Code\ACCollector-Server\postman\fossils.json