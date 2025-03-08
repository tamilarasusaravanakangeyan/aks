# tam-aks-learn-service/tam-aks-learn-service/README.md

# tam-aks-learn-service

## Overview
This project is a .NET application designed to run in a containerized environment using Docker and Kubernetes. It serves as a learning resource for deploying .NET applications on Azure Kubernetes Service (AKS).

## Project Structure
- **src/**: Contains the source code for the .NET application.
  - **tam-aks-learn-service.csproj**: Project file with metadata and dependencies.
  - **Program.cs**: Entry point of the application.
- **Dockerfile**: Instructions to build a Docker image for the application.
- **deployment.yaml**: Kubernetes deployment configuration.
- **README.md**: Documentation for the project.

## Setup Instructions
1. Ensure you have Docker installed on your machine.
2. Clone the repository:
   ```
   git clone <repository-url>
   ```
3. Navigate to the project directory:
   ```
   cd tam-aks-learn-service
   ```

## Building the Docker Image
To build the Docker image, run the following command in the project directory:
```
docker build -t tam-aks-learn-service .
```

## Running the Application
To run the application locally using Docker, execute:
```
docker run -d -p 80:80 tam-aks-learn-service
```

## Deployment to AKS
1. Ensure you have access to an Azure Kubernetes Service cluster.
2. Apply the deployment configuration:
   ```
   kubectl apply -f deployment.yaml
   ```

## Usage
Once deployed, the application can be accessed via the service endpoint provided by AKS.

## License
This project is licensed under the MIT License.