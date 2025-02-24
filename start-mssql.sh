#!/bin/bash

# Check if the container exists
if [ "$(docker ps -a -q -f name=sqlserver)" ]; then
    # Check if the container is running
    if [ "$(docker ps -q -f name=sqlserver)" ]; then
        echo "Container 'sqlserver' is already running."
    else
        echo "Starting existing container 'sqlserver'."
        docker start sqlserver
    fi
else
    echo "Creating and starting new container 'sqlserver'."
    docker run -d \
      --name sqlserver \
      -e ACCEPT_EULA=Y \
      -e MSSQL_SA_PASSWORD=Welcome@123. \
      -p 1433:1433 \
      -v sqlserverdata:/var/opt/mssql \
      mcr.microsoft.com/mssql/server:2022-latest
fi