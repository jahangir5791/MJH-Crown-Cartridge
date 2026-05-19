# API Documentation

## Base URL: `http://localhost:3000/api`

### Authentication

**Headers:** `Authorization: Bearer <token>`

### Endpoints

#### POST /auth/register
Body: `{ email, password, username, platform }`  
Response: `{ token, user }`

#### POST /auth/login
Body: `{ email, password }`  
Response: `{ token, user }`

#### POST /match/join
Body: `{ gameMode, skillLevel }`  
Response: `{ success, roomID, message }`

#### POST /room/create
Body: `{ roomName, maxPlayers, gameMode }`  
Response: `{ success, roomID, room }`

#### POST /cloudSave/save
Body: `{ gameData }`  
Response: `{ success, message }`

#### GET /cloudSave/load
Response: `{ success, data }`
