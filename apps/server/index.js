const express = require('express');
const http = require('http');
const socketIO = require('socket.io');
const mongoose = require('mongoose');
const cors = require('cors');
require('dotenv').config();

const app = express();
const server = http.createServer(app);
const io = socketIO(server);

// Middleware
app.use(cors());
app.use(express.json());

// Database connection
mongoose.connect(process.env.MONGODB_URI || 'mongodb://localhost:27017/mjhgame', {
  useNewUrlParser: true,
  useUnifiedTopology: true
})
.then(() => console.log('MongoDB connected'))
.catch(err => console.error('MongoDB connection error:', err));

// Routes
app.use('/api/auth', require('./routes/auth'));
app.use('/api/match', require('./routes/match'));
app.use('/api/room', require('./routes/room'));
app.use('/api/cloudSave', require('./routes/cloudSave'));

// WebSocket for multiplayer
io.on('connection', (socket) => {
  console.log('New client connected:', socket.id);

  socket.on('joinRoom', (roomID) => {
    socket.join(roomID);
    console.log(`User ${socket.id} joined room ${roomID}`);
  });

  socket.on('gameAction', (data) => {
    socket.to(data.roomID).emit('gameAction', data);
  });

  socket.on('disconnect', () => {
    console.log('Client disconnected:', socket.id);
  });
});

const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});
