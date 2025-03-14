D:\>terraform init
D:\>terraform plan -out tfplan
D:\>terraform show -json tfplan >>tfplan.json
D:\>terraform apply tfplan

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform plan -out tfplan
azurerm_resource_group.rg: Refreshing state... [id=/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourceGroups/aks_terraform_rg]

Note: Objects have changed outside of Terraform

Terraform detected the following changes made outside of Terraform since the last "terraform apply" which may have affected this plan:

  # azurerm_resource_group.rg has been deleted
  - resource "azurerm_resource_group" "rg" {
        id       = "/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourceGroups/aks_terraform_rg"
      - name     = "aks_terraform_rg" -> null
        tags     = {}
        # (1 unchanged attribute hidden)
    }


Unless you have made equivalent changes to your configuration, or ignored the relevant attributes using ignore_changes, the following plan may include actions 
to undo or respond to these changes.

────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── 

Terraform used the selected providers to generate the following execution plan. Resource actions are indicated with the following symbols:
  + create

Terraform will perform the following actions:

  # azurerm_kubernetes_cluster.aks will be created
  + resource "azurerm_kubernetes_cluster" "aks" {
      + dns_prefix              = "terraform-aks"
      + fqdn                    = (known after apply)
      + id                      = (known after apply)
      + kube_admin_config       = (known after apply)
      + kube_admin_config_raw   = (sensitive value)
      + kube_config             = (known after apply)
      + kube_config_raw         = (sensitive value)
      + kubelet_identity        = (known after apply)
      + kubernetes_version      = "1.29.2"
      + location                = "westeurope"
      + name                    = "terraform-aks"
      + node_resource_group     = "aks_terraform_resources_rg"
      + private_cluster_enabled = (known after apply)
      + private_fqdn            = (known after apply)
      + private_link_enabled    = (known after apply)
      + resource_group_name     = "aks_terraform_rg"
      + sku_tier                = "Free"

      + addon_profile (known after apply)

      + auto_scaler_profile (known after apply)

      + default_node_pool {
          + max_pods             = (known after apply)
          + name                 = "system"
          + node_count           = 1
          + orchestrator_version = (known after apply)
          + os_disk_size_gb      = (known after apply)
          + os_disk_type         = "Managed"
          + type                 = "VirtualMachineScaleSets"
          + vm_size              = "Standard_DS2_v2"
        }

      + identity {
          + principal_id = (known after apply)
          + tenant_id    = (known after apply)
          + type         = "SystemAssigned"
        }

      + network_profile {
          + dns_service_ip     = (known after apply)
          + docker_bridge_cidr = (known after apply)
          + load_balancer_sku  = "standard"
          + network_mode       = (known after apply)
          + network_plugin     = "kubenet"
          + network_policy     = (known after apply)
          + outbound_type      = "loadBalancer"
          + pod_cidr           = (known after apply)
          + service_cidr       = (known after apply)

          + load_balancer_profile (known after apply)
        }

      + role_based_access_control (known after apply)

      + windows_profile (known after apply)
    }

  # azurerm_resource_group.rg will be created
  + resource "azurerm_resource_group" "rg" {
      + id       = (known after apply)
      + location = "westeurope"
      + name     = "aks_terraform_rg"
    }

Plan: 2 to add, 0 to change, 0 to destroy.

Changes to Outputs:
  + aks_fqdn    = (known after apply)
  + aks_id      = (known after apply)

────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────── 

Saved the plan to: tfplan

To perform exactly these actions, run the following command to apply:
    terraform apply "tfplan"

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform apply tfplan
azurerm_resource_group.rg: Creating...
azurerm_resource_group.rg: Still creating... [10s elapsed]
azurerm_resource_group.rg: Still creating... [20s elapsed]
azurerm_resource_group.rg: Creation complete after 21s [id=/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourceGroups/aks_terraform_rg]
azurerm_kubernetes_cluster.aks: Creating...
azurerm_kubernetes_cluster.aks: Still creating... [10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [20s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [30s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [40s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [50s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m20s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m30s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m40s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [1m50s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m20s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m30s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m40s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [2m50s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m20s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m30s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m40s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [3m50s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m20s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m30s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m40s elapsed]
azurerm_kubernetes_cluster.aks: Creation complete after 4m46s [id=/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourcegroups/aks_terraform_rg/providers/Microsoft.ContainerService/managedClusters/terraform-aks]

Apply complete! Resources: 2 added, 0 changed, 0 destroyed.

Outputs:

aks_fqdn = "terraform-aks-4oiubwpd.hcp.westeurope.azmk8s.io"
aks_id = "/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourcegroups/aks_terraform_rg/providers/Microsoft.ContainerService/managedClusters/terraform-aks"
aks_node_rg = "aks_terraform_resources_rg"

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>