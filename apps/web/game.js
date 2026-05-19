import { apiClient } from './apiClient';

export function initGame() {
  const canvas = document.getElementById('gameCanvas');
  if (!canvas) return;

  const ctx = canvas.getContext('2d');
  canvas.width = window.innerWidth;
  canvas.height = window.innerHeight;

  let player = { x: canvas.width / 2, y: canvas.height / 2 };
  let enemies = [];

  function gameLoop() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    
    // Draw player
    ctx.fillStyle = '#4a90e2';
    ctx.beginPath();
    ctx.arc(player.x, player.y, 20, 0, Math.PI * 2);
    ctx.fill();

    requestAnimationFrame(gameLoop);
  }

  gameLoop();
}
