# Stage 1: Build the Angular application
FROM node:18.14 AS builder
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build -- --configuration production

# Stage 2: Serve the Angular application using Nginx
FROM nginx:latest
COPY ./nginx.conf /etc/nginx/conf.d/nginx.conf

# --- added this to clean the cache
RUN rm -rf /usr/share/nginx/html/*  

# ---- here i added /browser because the index.html file is in the /browser 
COPY --from=builder /app/dist/phonebook-app/browser /usr/share/nginx/html/ 

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]