# Deploying .Net Microservices with sql database to Azure Kubernetes Services(AKS) and Automating with Azure DevOps
Deploying .Net Microservices into Kubernetes, and moving deployments to the cloud Azure Kubernetes Services (AKS) with using Azure Container Registry (ACR) and how to Automating Deployments with Azure DevOps and GitHub.

Topology:
![Topology](image/rglsaks_topology.jpg)

![AKS_RESOURCE_TOPOLGY](image/rglsaks_mc_topology.jpg)

![](image/connectionflow.png)

![](image/aks-node-resource-interactions.png)
Reference: https://learn.microsoft.com/en-us/azure/aks/core-aks-concepts#deployments-and-yaml-manifests

Create Resource Group:
```
az group create -n rglsaks --location centralindia
```


Create Vnet & Subnet:
```
az network vnet create -g rglsaks -n vnetlsakssql --address-prefix 10.0.0.0/8 --subnet-name subnetlsakssql --subnet-prefix 10.240.0.0/16
```


Create SQL Server:
```
az sql server create -n sqlsrvlsaks -g rglsaks --location centralindia --admin-user lsaksadmin --admin-password lsakspassword@25
```



Create SQL DB:
```
# az sql db create -g rglsaks --server sqldblsaks --name subnetlsakssql --service-objective S0
```
or

```
az sql db create -g rglsaks --server sqlsrvlsaks --name sqldblsaks --edition GeneralPurpose --family Gen5 --compute-model Serverless --capacity 1 --auto-pause-delay 60
```


Link Service end point with Subnet
```
az network vnet subnet update --name subnetlsakssql --vnet-name vnetlsakssql -g rglsaks --service-endpoints Microsoft.sql
```


Create Vnet rule:
```
az sql server vnet-rule create -g rglsaks --server sqlsrvlsaks --name vnetrulelsaks --vnet-name vnetlsakssql --subnet subnetlsakssql
```


Check SQL DB:
```
az sql db show -g rglsaks --server sqlsrvlsaks --name sqldblsaks
```


Show SLQ DB Connection String:
```
az sql db show-connection-string --name sqldblsaks --server sqlsrvlsaks --client ado.net
```


Create Sql Server Firewall rule to allow local laptop/specific device to connect the database:
```
az sql server firewall-rule create -g rglsaks --server sqlsrvlsaks --name AllowMyIP --start-ip-address 37.186.45.24 --end-ip-address 37.186.45.24
```


Entity Framework to create DB Tables:
```
dotnet ef migrations add MigrateProductModel
```


```
dotnet ef database update --connection "Server=tcp:sqlsrvlsaks.database.windows.net,1433;Initial Catalog=sqldblsaks;Persist Security Info=False;User ID=lsaksadmin;Password=lsakspassword@25;MultipleActiveResultSets=False;Encrypt=true;TrustServerCertificate=False;Connection Timeout=30;"
```


Create New Vnet:
```
az network vnet create -g rglsaks --name vnetlsaks --address-prefix 10.0.0.0/8 --subnet-name subnetlsaks --subnet-prefix 10.240.0.0/16
```


Check VNet:
```
az network vnet list -g rglsaks
```


Check Subnet:
```
az network vnet subnet show -g rglsaks --vnet-name vnetlsaks --name subnetlsaks --query id -o tsv
```


Create AKS Cluster within VNet
```
az aks create -g rglsaks -n lsaksapisqlclsn --node-count 1 --enable-addons monitoring --generate-ssh-keys --network-plugin azure --vnet-subnet-id "/subscriptions/abcxyz-64a6-4168-ac96-abcxyz/resourceGroups/rglsaks/providers/Microsoft.Network/virtualNetworks/vnetlsaks/subnets/subnetlsaks"
```


Create Azure Container registry
```
az acr create -g rglsaks --name shoppingacrtamil --sku basic
```


Config Map(can be automated in pipeline)Before Triggering Deployment Need to create config map:
```
D:\aks\aks-end-to-end-sql\aksl>kubectl apply -f shoppingapi-configmap.yaml
```



![Environment](image/environment.png)

![ServiceConnection](image/serviceconnection.png)

![pullsecret](image/pullsecret.png)

|-|Free tier|Standard tier|Premium tier|
|--|--|--|--|
|When to use|You want to experiment with AKS at no extra cost, You're new to AKS and Kubernetes|You're running production or mission-critical workloads and need high availability and reliability, You need a financially backed SLA, Automatically selected for AKS automatic clusters (if you create an AKS Automatic Cluster)|You're running production or mission-critical workloads and need high availability and reliability, You need a financially backed SLA, All mission critical, at scale, or production workloads requiring two years of one Kubernetes version support|
|Supported cluster types|Development clusters or small scale testing environments, Clusters with fewer than 10 nodes|Enterprise-grade or production workloads, Clusters with up to 5,000 nodes, |Enterprise-grade or production workloads,Clusters with up to 5,000 nodes|
|Pricing|Free cluster management, Pay-as-you-go for resources you consume|Pay-as-you-go for resources you consume|Pay-as-you-go for resources you consume|
|Feature comparison|Recommended for clusters with fewer than 10 nodes, but can support up to 1,000 nodes, Includes all current AKS features|Uptime SLA is enabled by default, Greater cluster reliability and resources, Can support up to 5,000 nodes in a cluster, Includes all current AKS features|Includes all current AKS features from standard tier|

Reference: https://learn.microsoft.com/en-us/azure/aks/free-standard-pricing-tiers

Cost(Per Day with sanity testing traffic):
|Service Name|Service Resource|Spend|
|--|--|--|
|SQL Database|vCore|$3.53|
|Virtual Machines|D2 v2/DS2 v2|$1.62|
|Log Analytics|Pay-as-you-go Data Ingestion|$0.45|
|Storage|P10 LRS Disk|$0.28|
|Virtual Network|Standard IPv4 Static Public IP|$0.25|
|Container Registry|Basic Registry Unit|$0.17|
|SQL Database|General Purpose Data Stored|$0.1|
|Bandwidth|Inter Continent Data Transfer Out - ASIA To Any|$0|
|Bandwidth|Intra Continent Data Transfer Out|$0|
|Storage|All Other Operations|$0|
|Load Balancer|Standard Data Processed - Free|$0|
|Azure Cognitive Search|Free Unit|$0|
|Bandwidth|Standard Data Transfer Out - Free|$0|
|SQL Database|1 vCore - Free|$0|
|Azure App Service|F1 App|$0|
|SQL Database|General Purpose Data Stored - Free|$0|
|Load Balancer|Standard Included LB Rules and Outbound Rules - Free|$0|

| Image | Status |
| ------------- | ------------- |
| Shopping Client | [![Build Status](https://tamilarasusaravanakangeyan.visualstudio.com/aks/_apis/build/status%2Fshoppingclient?branchName=main&stageName=Deploy%20stage&jobName=Deploy)](https://tamilarasusaravanakangeyan.visualstudio.com/aks/_build/latest?definitionId=8&branchName=main) |
| Shopping API | [![Build Status](https://tamilarasusaravanakangeyan.visualstudio.com/aks/_apis/build/status%2Fshoppingapi?branchName=main&stageName=Deploy%20stage&jobName=Deploy)](https://tamilarasusaravanakangeyan.visualstudio.com/aks/_build/latest?definitionId=7&branchName=main) |

### Overall Picture
See the overall picture. You can see that we will have 3 microservices which we are going to develop and deploy together.

![Overall Picture of Repository](image/image.png)

### Shopping MVC Client Application
First of all, we are going to develop Shopping MVC Client Application For Consuming Api Resource which will be the Shopping.Client Asp.Net MVC Web Project. But we will start with developing this project as a standalone Web application which includes own data inside it. And we will add container support with DockerFile, push docker images to Docker hub and see the deployment options like “Azure Web App for Container” resources for 1 web application.
### Shopping API Application
After that we are going to develop Shopping.API Microservice with MongoDb and Compose All Docker Containers.
This API project will have Products data and performs CRUD operations with exposing api methods for consuming from Shopping Client project.
We will containerize API application with creating dockerfile and push images to Azure Container Registry.
### Mongo Db
Our API project will manage product records stored in a no-sql mongodb database as described in the picture.
we will pull mongodb docker image from docker hub and create connection with our API project.
At the end of the section, we will have 3 microservices whichs are Shopping.Client — Shopping.API — MongoDb microservices.
As you can see that, we have
* Created docker images,
Compose docker containers and tested them,
Deploy these docker container images on local Kubernetes clusters,
Push our image to ACR,
Shifting deployment to the cloud Azure Kubernetes Services (AKS),
Update microservices with zero-downtime deployments.
### Deploy to Azure Kubernetes Services (AKS) through CI/CD Azure Pipelines
And the last step, we are focusing on automation deployments with creating CI/CD pipelines on Azure Devops tool. We will develop separate microservices deployment pipeline yamls with using Azure Pipelines.
When we push code to Github, microservices pipeline triggers, build docker images and push the ACR, deploy to Azure Kubernetes services with zero-downtime deployments.

![cicd](image/image1.png)

You’ll see how to deploy your multi-container microservices applications with automating all deployment process seperately.
