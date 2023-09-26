FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install --legacy-peer-deps
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=node /app/dist/sam-store-web /usr/share/nginx/html