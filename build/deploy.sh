#!/bin/bash
cd ..

docker-compose down
docker-compose build
docker-compose up -d

cd ./build/nginx
cp default /etc/nginx/sites-available/default
service nginx restart

cd ..

shell2http -host 92.63.96.49 -port 8080 /deploy "git pull && ./deploy.sh" &> /dev/null &

echo "Deploy: DONE"