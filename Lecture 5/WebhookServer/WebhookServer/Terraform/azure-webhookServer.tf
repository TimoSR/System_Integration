terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.43.0"
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

resource "azurerm_resource_group" "webhook" {
  name     = "system-integration"
  location = "West Europe"
}

resource "azurerm_container_group" "webhook-api-dev-cgroup" {
  name                = "webhook-containers"
  location            = azurerm_resource_group.webhook.location
  resource_group_name = azurerm_resource_group.webhook.name
  ip_address_type     = "public"
  dns_name_label      = "your-unique-dns-name-label"
  os_type             = "Linux"

  container {
    name   = "webhook-container"
    image  = "00tir2009/webhookserver"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 7443
      protocol = "TCP"
    }

    ports {
      port     = 7080
      protocol = "TCP"
    }
  }

  tags = {
    environment = "testing"
  }
}
