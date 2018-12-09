#!/bin/bash

shell2http -host 92.63.96.49 -port 8080 /deploy "git pull && ./deploy.sh" &> /dev/null &
echo "shell2http: DONE"

cd ./nginx
cp default /etc/nginx/sites-available/default
service nginx restart
echo "nginx: DONE"

cd ../..

docker-compose down
docker-compose up --build -d
docker rmi $(docker images -f dangling=true -q) -f

echo "docker-compose: DONE"