FROM node:latest AS build-stage

WORKDIR /app

COPY . .

ARG ENVIRONMENT_CONFIGURATION=development

RUN npm install -g @angular/cli
RUN npm install --legacy-peer-deps 
RUN ng build --configuration=${ENVIRONMENT_CONFIGURATION}

FROM nginx:alpine

WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY --from=build-stage /app/dist/sam-store-web .

ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
