import './styles.css';
import { initGame } from './game';
import { initRouter } from './router';
import { initAPI } from './apiClient';

// Initialize app
document.addEventListener('DOMContentLoaded', () => {
  initAPI();
  initRouter();
  initGame();
});
