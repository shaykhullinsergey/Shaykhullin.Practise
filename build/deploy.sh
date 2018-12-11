#!/bin/bash

shell2http -host 62.109.18.11 -port 8080 /deploy "git pull && ./deploy.sh" &> /dev/null &
echo "shell2http: DONE"

cd ..

docker-compose down
docker-compose up --build -d
docker rmi $(docker images -f dangling=true -q) -f

echo "docker-compose: DONE"