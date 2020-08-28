New-AzResourceGroup `
    -Name rg-volleyballIntegrationTesting `
    -Location "Central US"

New-AzResourceGroupDeployment `
    -Name appServiceWithSqlServer `
    -ResourceGroupName rg-volleyballIntegrationTesting `
    -TemplateFile "azuredeploy.json" `
    -TemplateParameterFile "azuredeploy.parameters.json"
