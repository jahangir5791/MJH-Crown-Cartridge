# Protocol Package

Game communication protocol for multiplayer.

## Message Format

```json
{
  "type": "game_action",
  "data": { ... },
  "version": "1.0.0"
}
Message Types
game_action - General game action
player_move - Player movement
shoot - Shooting action
enemy_spawn - Enemy spawn event
score_update - Score change
game_over - Game ended
