import { apiClient } from './apiClient';

export function initRouter() {
  const routes = {
    '/': renderHome,
    '/login': renderLogin,
    '/register': renderRegister,
    '/game': renderGame,
    '/profile': renderProfile
  };

  function handleRoute() {
    const path = window.location.pathname;
    const route = routes[path] || renderHome;
    route();
  }

  window.addEventListener('hashchange', handleRoute);
  window.addEventListener('load', handleRoute);
}

function renderHome() {
  document.getElementById('app').innerHTML = '<h1>Welcome to MJH Game</h1>';
}

function renderLogin() {
  document.getElementById('app').innerHTML = '<h1>Login</h1>';
}

function renderRegister() {
  document.getElementById('app').innerHTML = '<h1>Register</h1>';
}

function renderGame() {
  document.getElementById('app').innerHTML = '<h1>Game</h1>';
}

function renderProfile() {
  document.getElementById('app').innerHTML = '<h1>Profile</h1>';
}
