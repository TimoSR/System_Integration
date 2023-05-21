terraform {

  cloud {
    organization = "example-org-0bfb0b"

    workspaces {
      name = "mysql-example-workspace"
    }
  }
}

provider "azurerm" {
  subscription_id = var.subscription_id
  client_id       = var.client_id
  client_secret   = var.client_secret
  tenant_id       = var.tenant_id
  features {}
}

# vars.auto.tfvars

# Create a virtual network
resource "azurerm_virtual_network" "vnet" {
  name                = "myTFVnet"
  address_space       = ["10.0.0.0/16"]
  location            = "westeurope"
  resource_group_name = "system-integration"
}
