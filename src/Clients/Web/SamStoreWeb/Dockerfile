FROM node:latest as node

WORKDIR /app

COPY package.json .

RUN npm install --legacy-peer-deps
RUN npm install -g @angular/cli@latest

COPY . .