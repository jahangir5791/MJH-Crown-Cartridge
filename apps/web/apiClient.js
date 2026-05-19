const API_BASE_URL = 'http://localhost:3000/api';
let token = localStorage.getItem('token');

export const apiClient = {
  async get(endpoint) {
    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
      headers: { 'Authorization': `Bearer ${token}` }
    });
    return response.json();
  },

  async post(endpoint, data) {
    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
      body: JSON.stringify(data)
    });
    return response.json();
  },

  setToken(newToken) {
    token = newToken;
    localStorage.setItem('token', newToken);
  },

  clearToken() {
    token = null;
    localStorage.removeItem('token');
  }
};
