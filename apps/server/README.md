# MJH-Crown-Cartridge Backend Server

Multiplayer game backend with authentication, matchmaking, and cloud save.

## Tech Stack

- Node.js + Express
- Socket.IO (WebSocket for real-time)
- MongoDB (Database)
- JWT (Authentication)

## Features

- Google/Facebook/Apple OAuth
- Matchmaking system
- Room management
- Cloud save/load
- Multiplayer WebSocket

## Setup

```bash
npm install
cp .env.example .env
npm start
Environment Variables
MONGODB_URI=mongodb://localhost:27017/mjhgame
JWT_SECRET=your-secret-key
PORT=3000
API Endpoints
POST /api/auth/register - Register user
POST /api/auth/login - Login user
POST /api/auth/google - Google OAuth
POST /api/auth/facebook - Facebook OAuth
POST /api/auth/apple - Apple OAuth
POST /api/match/join - Join matchmaking
POST /api/room/create - Create room
POST /api/room/join/:roomID - Join room
POST /api/cloudSave/save - Save game
GET /api/cloudSave/load - Load game
