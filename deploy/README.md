# Deployment Guide

## Docker Deployment

```bash
docker build -t mjh-game .
docker run -p 3000:3000 mjh-game
VPS Deployment
Install Node.js, MongoDB, Nginx
Clone repository
npm install
Configure nginx
pm2 start apps/server/index.js
Cloud Deployment
AWS: EC2 + RDS
Google Cloud: App Engine + Cloud SQL
Heroku: Simplest deployment
