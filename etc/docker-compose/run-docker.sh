#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p d02de00b-39fd-4a08-b4b9-2e30035e27d3 -t
    fi
    cd ../
fi

docker-compose up -d
