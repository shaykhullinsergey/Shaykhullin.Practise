FROM node:10 as build
COPY . /var/react
WORKDIR /var/react/src/Practice.Frontend
RUN npm install
ENTRYPOINT [ "npm", "run-script", "dev" ]  