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

resource "azurerm_container_group" "webhook-api-dev-cgroup" {
  name                = "webhook-api-dev-cgroup"
  location            = var.location
  resource_group_name = var.resource_group_name
  ip_address_type     = "Public"
  dns_name_label      = "my-project-webhook-dev"
  os_type             = "Linux"
  restart_policy      = "OnFailure"

  container {
    name   = "my-webhookserver"
    image  = "00tir2009/webhookserver_amd64"
    cpu    = "1"
    memory = "2"

    ports {
      port     = 7443
      protocol = "TCP"
    }

  }

  tags = {
    environment = "testing"
  }
}
