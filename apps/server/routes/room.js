const express = require('express');
const router = express.Router();
const authMiddleware = require('../middleware/authMiddleware');

const rooms = {};

// Create room
router.post('/create', authMiddleware, (req, res) => {
  try {
    const { roomName, maxPlayers, gameMode } = req.body;
    const roomID = `room_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
    
    rooms[roomID] = {
      roomID,
      roomName,
      maxPlayers,
      gameMode,
      players: [{ userId: req.userId, role: 'host' }],
      createdAt: Date.now()
    };

    res.json({ success: true, roomID, room: rooms[roomID] });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Join room
router.post('/join/:roomID', authMiddleware, (req, res) => {
  try {
    const { roomID } = req.params;
    const room = rooms[roomID];
    
    if (!room) {
      return res.status(404).json({ message: 'Room not found' });
    }

    if (room.players.length >= room.maxPlayers) {
      return res.status(400).json({ message: 'Room is full' });
    }

    room.players.push({ userId: req.userId, role: 'player' });
    res.json({ success: true, room });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Leave room
router.post('/leave/:roomID', authMiddleware, (req, res) => {
  try {
    const { roomID } = req.params;
    const room = rooms[roomID];
    
    if (!room) {
      return res.status(404).json({ message: 'Room not found' });
    }

    room.players = room.players.filter(p => p.userId !== req.userId);
    
    if (room.players.length === 0) {
      delete rooms[roomID];
    }

    res.json({ success: true, message: 'Left room' });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Get room info
router.get('/:roomID', authMiddleware, (req, res) => {
  const { roomID } = req.params;
  const room = rooms[roomID];
  
  if (!room) {
    return res.status(404).json({ message: 'Room not found' });
  }

  res.json({ room });
});

module.exports = router;
