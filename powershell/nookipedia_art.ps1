$page = Invoke-WebRequest -Uri https://nookipedia.com/wiki/Art -Method Get

function Parse-Table() {
    param
    (
        [Parameter(Mandatory=$true)]$tableIndex
    )
    
    $table = $page.ParsedHtml.getElementsByTagName("table")[$tableIndex]
    $Arts = @()

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

        $art = @{}
        $art.Name = $row.cells[0].innerText.Trim()

        if ($tableIndex -eq 6) {
            $art.ArtType = "Sculpture"
        } else {
            $art.ArtType = "Painting"
        }
    
        $source = $row.cells[5].innerText.Trim()
        if ($source -eq "Crazy Redd's") {
            $source = "CrazyRedd"
            $defaultPurchasePrice = "3920"
        } else {
            $source = "Spotlight"
            $defaultPurchasePrice = "1960"
        }
        $art.Source = $source 

        $purchasePriceText = $row.cells[3].innerText
        if (-not $purchasePriceText) {
            $purchasePriceText = $defaultPurchasePrice
        }
        $art.PurchasePrice =  [int]$purchasePriceText.Split(' ')[0]

        $salePriceText = $row.cells[4].innerText
        if (-not $salePriceText) {
            $salePriceText = "490"
        }
        $art.SalePrice =  [int]$salePriceText

        $art = New-Object -TypeName PSObject -Prop $art

        $Arts += $art
    }

    return $Arts
}

function Build-Art-Folder {
    param
    (
        [Parameter(Mandatory=$true)]$folderName,
        [Parameter(Mandatory=$true)]$artArray
    )

    $folder = @{}
    $folder.name = $folderName
    $folder.description = ""
    $items = @()

    foreach($art in $artArray) {
        $items += Build-Art $art
    }

    $folder.item = $items
    $folder._postman_isSubFolder = $true
    return New-Object -TypeName PSObject -Prop $folder
}

function Build-Art {
    param
    (
        [Parameter(Mandatory=$true)]$art
    )

    begin {
        Write-Host "Processing Art: $($art.Name)"
    }

    process {
        $postman = @{}
        $postman.name = $art.Name

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
        $body.raw = "{`n`t`"name`": `"$($art.Name)`",`n`t`"type`": `"$($art.ArtType)`",`n`t`"purchasePrice`": $($art.PurchasePrice),`n`t`"salePrice`": $($art.SalePrice),`n`t`"availableFrom`": `"$($art.Source)`"`n}"
        $body = New-Object -TypeName PSObject -Prop $body

        $request.body = $body

        $url = @{}
        $url.raw = "{{host}}/api/games/{{gameId}}/art"
        $url.host = @("{{host}}")
        $url.path = @("api", "games", "{{gameId}}", "art")
        $url = New-Object -TypeName PSObject -Prop $url

        $request.url = $url
        $request.description = ""
        $request = New-Object -TypeName PSObject -Prop $request

        $postman.request = $request
        $postman = New-Object -TypeName PSObject -Prop $postman

        return $postman
    }
}

$ACArts = Parse-Table 2
$WWArts = Parse-Table 3
$CFArts = Parse-Table 4
$NLArts = Parse-Table 5
$NLSculptures = Parse-Table 6

$folders = @()
$folders += Build-Art-Folder "ACArts" $ACArts
$folders += Build-Art-Folder "WWArts" $WWArts
$folders += Build-Art-Folder "CFArts" $CFArts
$folders += Build-Art-Folder "NLArts" $NLArts
$folders += Build-Art-Folder "NLSculptures" $NLSculptures

$info = @{}
$info.name = "ACCollector Art Seeds"
$info.description = ""
$info.schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
$info = New-Object -TypeName PSObject -Prop $info

$collection = @{}
$collection.info = $info
$collection.item = $folders
$collection = New-Object -TypeName PSObject -Prop $collection

$json = ConvertTo-Json -InputObject $collection -Depth 10
$json | Out-File C:\Users\shaunh\Documents\Code\ACCollector-Server\postman\art.json