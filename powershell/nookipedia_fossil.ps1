$page = Invoke-WebRequest -Uri https://nookipedia.com/wiki/Fossil -Method Get

function Parse-Table() {
    param
    (
        [Parameter(Mandatory=$true)]$tableIndex
    )

    $group = "Standalone"
    $table = $page.ParsedHtml.getElementsByTagName("table")[$tableIndex]

    $Fossils = @()

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

        $fossilName = $row.cells[0].innerText.Trim()

        if ($fossilName.Contains("Coprolite")) {
            $fossilName = "Coprolite"
        } 
        $fossil.Name = $fossilName
        $fossil.SalePrice =  [int]$row.cells[1].innerText
        $fossil.Group = $group
    
        $games = $row.cells[5].innerText

        if ($games.Contains("AC")) {
            $fossil.Game = "AC"
            $fossilObj = New-Object -TypeName PSObject -Prop $fossil
            $Fossils += $fossilObj
        }

        if ($games.Contains("CF")) {
            $fossil.Game = "CF"
            $fossilObj = New-Object -TypeName PSObject -Prop $fossil
            $Fossils += $fossilObj
        }

        if ($games.Contains("NL")) {
            $fossil.Game = "NL"
            $fossilObj = New-Object -TypeName PSObject -Prop $fossil
            $Fossils += $fossilObj
        }

        if ($games.Contains("WW")) {
            $fossil.Game = "WW"

            if ($fossil.Name -eq "Coprolite") {
                $fossil.Name = "Dino Droppings"
            }

            $fossilObj = New-Object -TypeName PSObject -Prop $fossil
            $Fossils += $fossilObj
        }
    }

    return $Fossils
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

$nonStandaloneFossils = Parse-Table 2
$standaloneFossils = Parse-Table 3
$allFossils = $nonStandaloneFossils + $standaloneFossils

$folders = @()
$folders += Build-Fossil-Folder "ACFossils" ($allFossils | Where-Object { $_.Game -eq "AC" })
$folders += Build-Fossil-Folder "CFFossils" ($allFossils | Where-Object { $_.Game -eq "CF" })
$folders += Build-Fossil-Folder "NLFossils" ($allFossils | Where-Object { $_.Game -eq "NL" })
$folders += Build-Fossil-Folder "WWFossils" ($allFossils | Where-Object { $_.Game -eq "WW" })

$info = @{}
$info.name = "ACCollector Fossil Seeds"
$info.description = ""
$info.schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
$info = New-Object -TypeName PSObject -Prop $info

$collection = @{}
$collection.info = $info
$collection.item = $folders
$collection = New-Object -TypeName PSObject -Prop $collection

$json = ConvertTo-Json -InputObject $collection -Depth 10
$json | Out-File C:\Users\shaunh\Documents\Code\ACCollector-Server\postman\fossils.json