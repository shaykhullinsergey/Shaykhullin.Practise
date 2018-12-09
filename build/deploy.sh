#!/bin/bash
cd ..

docker-compose down
git pull
docker-compose build
docker-compose up -d

cd ./build/nginx
cp default /etc/nginx/sites-avaliable/
service nginx restart

cd ..

shell2http -host 92.63.96.49 -port 8080 /deploy "./deploy.sh" &> /dev/null &