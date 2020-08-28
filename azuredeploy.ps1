New-AzResourceGroup `
    -Name rg-volleyballIntegrationTesting `
    -Location "Central US"

New-AzResourceGroupDeployment `
    -Name appServiceWithSqlServer `
    -ResourceGroupName rg-volleyballIntegrationTesting `
    -TemplateFile "azuredeploy.json" `
    -TemplateParameterFile "azuredeploy.parameters.json"

#Get-AzResourceGroup -Name rg-volleyballIntegrationTesting | Remove-AzResourceGroup -Force
