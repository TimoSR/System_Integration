terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.43.0"
    }
  }
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

resource "azurerm_mysql_server" "my_mysql_server" {
  name                         = var.server_name
  location                     = var.location
  resource_group_name          = var.resource_group_name
  administrator_login          = var.administrator_login
  administrator_login_password = var.administrator_login_password
  version                      = "5.7"
  ssl_enforcement_enabled      = true
  sku_name                     = "B_Gen5_1"
}

resource "azurerm_mysql_firewall_rule" "my_myqsql_firewall" {
  name                = "AllowAll"
  resource_group_name = var.resource_group_name
  server_name         = var.server_name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "255.255.255.255"
}

resource "azurerm_mysql_database" "my_myqsql_database" {
  name                = "mysql_m1"
  resource_group_name = var.resource_group_name
  server_name         = var.server_name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}
