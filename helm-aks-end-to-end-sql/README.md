3 Steps to automate API deployment
- Step 1: Create AKS Cluster using Terraform
- Step 2: Create ACR and upload image and download pull secret
- Step 3: Create/Deploy Services to AKS using Helm

### Step 1: Create/Deploy AKS Cluster

Microsoft Windows [Version 10.0.26100.3194]
(c) Microsoft Corporation. All rights reserved.

D:\wrkspc\git_repo\tamilsmtp\aks>cd terraform-learn

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform init
Initializing the backend...
Initializing provider plugins...
- Finding hashicorp/azurerm versions matching "2.46.0"...
- Installing hashicorp/azurerm v2.46.0...
- Installed hashicorp/azurerm v2.46.0 (signed by HashiCorp)
Terraform has created a lock file .terraform.lock.hcl to record the provider
selections it made above. Include this file in your version control repository
so that Terraform can guarantee to make the same selections by default when
you run "terraform init" in the future.

Terraform has been successfully initialized!

You may now begin working with Terraform. Try running "terraform plan" to see
any changes that are required for your infrastructure. All Terraform commands
should now work.

If you ever set or change modules or backend configuration for Terraform,
rerun this command to reinitialize your working directory. If you forget, other
commands will detect it and remind you to do so if necessary.

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform plan -out tfplan

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
  + aks_node_rg = "aks_terraform_resources_rg"

───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

Saved the plan to: tfplan

To perform exactly these actions, run the following command to apply:
    terraform apply "tfplan"

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform show -json tfplan >> tfplan.json

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>terraform apply tfplan  
azurerm_resource_group.rg: Creating...
azurerm_resource_group.rg: Creation complete after 5s [id=/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourceGroups/aks_terraform_rg]    
azurerm_kubernetes_cluster.aks: Creating...
azurerm_kubernetes_cluster.aks: Still creating... [10s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [20s elapsed]
]
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
azurerm_kubernetes_cluster.aks: Still creating... [3m50s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m0s elapsed]
azurerm_kubernetes_cluster.aks: Still creating... [4m10s elapsed]
azurerm_kubernetes_cluster.aks: Creation complete after 4m18s [id=/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourcegroups/aks_terraform_rg/providers/Microsoft.ContainerService/managedClusters/terraform-aks]

Apply complete! Resources: 2 added, 0 changed, 0 destroyed.

aks_fqdn = "terraform-aks-rkntbi1p.hcp.westeurope.azmk8s.io"
aks_fqdn = "terraform-aks-rkntbi1p.hcp.westeurope.azmk8s.io"
aks_id = "/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourcegroups/aks_terraform_rg/providers/Microsoft.ContainerService/managedClusters/terraform-aks"
aks_node_rg = "aks_terraform_resources_rg"

D:\wrkspc\git_repo\tamilsmtp\aks\terraform-learn>

### Step 2: Create ACR and upload image and download pull secret

Microsoft Windows [Version 10.0.26100.3194]
(c) Microsoft Corporation. All rights reserved.

C:\Users\tamil>az acr create --resource-group aks_terraform_resources_rg --name shoppingacrtamil --sku Basic
NAME              RESOURCE GROUP              LOCATION    SKU    LOGIN SERVER                 CREATION DATE         ADMIN ENABLED
----------------  --------------------------  ----------  -----  ---------------------------  --------------------  ---------------
shoppingacrtamil  aks_terraform_resources_rg  westeurope  Basic  shoppingacrtamil.azurecr.io  2025-03-14T04:36:06Z  False

C:\Users\tamil>docker push shoppingacrtamil.azurecr.io/shoppingclient:v4
The push refers to repository [shoppingacrtamil.azurecr.io/shoppingclient]
3ea0f3f46fe2: Preparing
5f70bf18a086: Preparing
3cf9592f4858: Preparing
bd509805877c: Preparing
6644aa2c795a: Preparing
ef956b5e5fbc: Waiting
517b3236c982: Waiting
05df6742558b: Waiting
13538303ed9c: Waiting
5f1ee22ffb5e: Waiting
unauthorized:

C:\Users\tamil>az acr list -g aks_terraform_resources_rg --query "[].{acrName:name,location:location,sku:sku.name}" --output table
AcrName           Location    Sku
----------------  ----------  -----
shoppingacrtamil  westeurope  Basic

C:\Users\tamil>az acr login --name shoppingacrtamil
Login Succeeded

C:\Users\tamil>docker push shoppingacrtamil.azurecr.io/shoppingclient:v4
The push refers to repository [shoppingacrtamil.azurecr.io/shoppingclient]
3ea0f3f46fe2: Pushed
5f70bf18a086: Pushed
3cf9592f4858: Pushed
bd509805877c: Pushed
6644aa2c795a: Pushed
ef956b5e5fbc: Pushed
517b3236c982: Pushed
05df6742558b: Pushed
13538303ed9c: Pushed
5f1ee22ffb5e: Pushed
v4: digest: sha256:6bc0fc13beaf44597b3a9939f5dd244ece148b594ad3f9a13c52490906f077c2 size: 2415

C:\Users\tamil>docker push shoppingacrtamil.azurecr.io/shoppingapi:v3
The push refers to repository [shoppingacrtamil.azurecr.io/shoppingapi]
5b7a43a9781e: Pushed
5f70bf18a086: Mounted from shoppingclient
3cf9592f4858: Mounted from shoppingclient
bd509805877c: Mounted from shoppingclient
6644aa2c795a: Mounted from shoppingclient
ef956b5e5fbc: Mounted from shoppingclient
517b3236c982: Mounted from shoppingclient
05df6742558b: Mounted from shoppingclient
13538303ed9c: Mounted from shoppingclient
5f1ee22ffb5e: Mounted from shoppingclient
v3: digest: sha256:003605292636757c7b16c4979752b99f0b6ae7cbeb4a323161e3ea9fef3cb067 size: 2415


C:\Users\tamil>az aks update -n terraform-aks -g aks_terraform_rg\ --attach-acr shoppingacrtamil
AAD role propagation done[############################################]  100.0000%AzurePortalFqdn                                         CurrentKubernetesVersion    DnsPrefix      EnableRbac    Fqdn                                             KubernetesVersion    Location    MaxAgentPools    Name           NodeResourceGroup           ProvisioningState    ResourceGroup     ResourceUid               SupportPlan
------------------------------------------------------  --------------------------  -------------  ------------  -----------------------------------------------  -------------------  ----------  ---------------  -------------  --------------------------  -------------------  ----------------  ------------------------  ------------------
terraform-aks-rkntbi1p.portal.hcp.westeurope.azmk8s.io  1.29.2                      terraform-aks  False         terraform-aks-rkntbi1p.hcp.westeurope.azmk8s.io  1.29.2               westeurope  100              terraform-aks  aks_terraform_resources_rg  Succeeded            aks_terraform_rg  67d3a84a9d4a130001b42fb4  KubernetesOfficial

C:\Users\tamil>az acr list -g aks_terraform_resources_rg --query "[].{acrLoginServer:loginServer}" -o table
AcrLoginServer
---------------------------
shoppingacrtamil.azurecr.io

C:\Users\tamil>az acr repository list -n shoppingacrtamil -o table
Result
--------------
shoppingapi
shoppingclient

C:\Users\tamil>kubectl create secret docker-registry acr-secret --docker-server=shoppingacrtamil.azurecr.io --docker-username=shoppingacrtamil --docker-password=<password> --docker-email=<emailaddress>
secret/acr-secret created

C:\Users\tamil>kubectl get secrets
NAME                                TYPE                             DATA   AGE
acr-secret                          kubernetes.io/dockerconfigjson   1      38s
sh.helm.release.v1.shoppingapi.v1   helm.sh/release.v1               1      31m

C:\Users\tamil>az acr list -g aks_terraform_resources_rg --query "[].{acrName:name,location:location,sku:sku.name}" --output table

### Step 3: Create/Deploy Services to AKS using Helm
D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>az aks get-credentials -g aks_terraform_rg --name terraform-aks
Merged "terraform-aks" as current context in C:\Users\tamil\.kube\config


D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm create shoppingchart
Creating shoppingchart

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>cd shoppingchart

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm\shoppingchart>helm install myrelease mychart --set image.repository=myacr.azurecr.io/myapp --set image.tag=v1

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm install shoppingapi shoppingchart
NAME: shoppingapi
LAST DEPLOYED: Fri Mar 14 10:40:28 2025
NAMESPACE: default
STATUS: deployed
REVISION: 1
NOTES:
1. Get the application URL by running these commands:
     NOTE: It may take a few minutes for the LoadBalancer IP to be available.
           You can watch its status by running 'kubectl get --namespace default svc -w shoppingapi-shoppingchart'
  export SERVICE_IP=$(kubectl get svc --namespace default shoppingapi-shoppingchart --template "{{ range (index .status.loadBalancer.ingress 0) }}{{.}}{{ end }}")
  echo http://$SERVICE_IP:8080                                                                             
  
D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm upgrade shoppingapi shoppingchart 
Release "shoppingapi" has been upgraded. Happy Helming!
NAME: shoppingapi
LAST DEPLOYED: Fri Mar 14 11:13:10 2025
NAMESPACE: default
STATUS: deployed
REVISION: 2
NOTES:
1. Get the application URL by running these commands:
     NOTE: It may take a few minutes for the LoadBalancer IP to be available.
           You can watch its status by running 'kubectl get --namespace default svc -w shoppingapi-shoppingchart'
  export SERVICE_IP=$(kubectl get svc --namespace default shoppingapi-shoppingchart --template "{{ range (index .status.loadBalancer.ingress 0) }}{{.}}{{ end }}")
  echo http://$SERVICE_IP:8080

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>kubectl get pods
NAME                                      READY   STATUS    RESTARTS   AGE
shoppingapi-deployment-58d69788c9-46lb8   1/1     Running   0          32m

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>kubectl get all
NAME                                          READY   STATUS    RESTARTS   AGE
pod/shoppingapi-deployment-58d69788c9-46lb8   1/1     Running   0          33m

NAME                          TYPE           CLUSTER-IP    EXTERNAL-IP     PORT(S)          AGE
service/kubernetes            ClusterIP      10.0.0.1      <none>          443/TCP          108m
service/shoppingapi-service   LoadBalancer   10.0.234.74   50.85.104.247   8080:32372/TCP   33m

NAME                                     READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/shoppingapi-deployment   1/1     1            1           33m

NAME                                                DESIRED   CURRENT   READY   AGE
replicaset.apps/shoppingapi-deployment-58d69788c9   1         1         1       33m

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm rollback shoppingapi 1  
Rollback was a success! Happy Helming!

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>kubectl get all
NAME                                          READY   STATUS    RESTARTS   AGE
pod/shoppingapi-deployment-58d69788c9-46lb8   1/1     Running   0          34m

NAME                          TYPE           CLUSTER-IP    EXTERNAL-IP     PORT(S)          AGE
service/kubernetes            ClusterIP      10.0.0.1      <none>          443/TCP          110m
service/shoppingapi-service   LoadBalancer   10.0.234.74   50.85.104.247   8080:32372/TCP   34m

NAME                                     READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/shoppingapi-deployment   1/1     1            1           34m

NAME                                                DESIRED   CURRENT   READY   AGE
replicaset.apps/shoppingapi-deployment-58d69788c9   1         1         1       34m

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm history shoppingapi
REVISION        UPDATED                         STATUS          CHART                   APP VERSION     DESCRIPTION     
1               Fri Mar 14 10:40:28 2025        superseded      shoppingchart-0.1.0     1.16.0          Install complete
2               Fri Mar 14 11:13:10 2025        superseded      shoppingchart-0.1.0     1.16.0          Upgrade complete
3               Fri Mar 14 11:15:11 2025        deployed        shoppingchart-0.1.0     1.16.0          Rollback to 1

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm history shoppingapi
REVISION        UPDATED                         STATUS          CHART                   APP VERSION     DESCRIPTION     
1               Fri Mar 14 10:40:28 2025        superseded      shoppingchart-0.1.0     1.16.0          Install complete
2               Fri Mar 14 11:13:10 2025        superseded      shoppingchart-0.1.0     1.16.0          Upgrade complete
3               Fri Mar 14 11:15:11 2025        deployed        shoppingchart-0.1.0     1.16.0          Rollback to 1

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm list
NAME            NAMESPACE       REVISION        UPDATED                                 STATUS          CHART                   APP VERSION
shoppingapi     default         3               2025-03-14 11:15:11.783243 +0530 IST    deployed        shoppingchart-0.1.0     1.16.0

D:\wrkspc\git_repo\tamilsmtp\aks\helm-aks-end-to-end-sql\helm>helm uninstall shoppingapi
release "shoppingapi" uninstalled
