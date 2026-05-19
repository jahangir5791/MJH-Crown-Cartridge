export const PROTOCOL_VERSION = '1.0.0';

export const MESSAGE_TYPES = {
  GAME_ACTION: 'game_action',
  PLAYER_MOVE: 'player_move',
  SHOOT: 'shoot',
  ENEMY_SPAWN: 'enemy_spawn',
  SCORE_UPDATE: 'score_update',
  GAME_OVER: 'game_over'
};

export function encodeMessage(type, data) {
  return JSON.stringify({ type, data, version: PROTOCOL_VERSION });
}

export function decodeMessage(message) {
  return JSON.parse(message);
}
