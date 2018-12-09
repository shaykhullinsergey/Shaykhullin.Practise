#!/bin/bash
cd ..

docker-compose down
git pull
docker-compose build
docker-compose up -d

cd ./build/nginx
mv default /etc/nginx/sites-avaliable/default
service nginx restart