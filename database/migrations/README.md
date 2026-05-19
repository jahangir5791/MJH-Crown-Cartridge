# Database Migrations

Run migrations:
```bash
mongosh < migrations/001_create_users.js
mongosh < migrations/002_create_game_data.js
Migration Files
001_create_users.js - Create users collection
002_create_game_data.js - Create game_data collection
