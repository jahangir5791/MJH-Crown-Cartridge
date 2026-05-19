const express = require('express');
const router = express.Router();
const authMiddleware = require('../middleware/authMiddleware');
const User = require('../models/User');

let matchQueue = [];

// Join matchmaking
router.post('/join', authMiddleware, async (req, res) => {
  try {
    const { gameMode, skillLevel } = req.body;
    
    const match = {
      userId: req.userId,
      gameMode,
      skillLevel,
      timestamp: Date.now()
    };

    matchQueue.push(match);
    
    if (matchQueue.length >= 2) {
      const players = matchQueue.splice(0, 2);
      const roomID = `room_${Date.now()}`;
      
      res.json({ 
        success: true, 
        roomID, 
        message: 'Match found!',
        opponent: players[1] 
      });
    } else {
      res.json({ 
        success: false, 
        message: 'Looking for opponents...',
        queuePosition: matchQueue.length 
      });
    }
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Leave matchmaking
router.post('/leave', authMiddleware, (req, res) => {
  matchQueue = matchQueue.filter(m => m.userId !== req.userId);
  res.json({ success: true, message: 'Left matchmaking queue' });
});

// Get queue status
router.get('/status', authMiddleware, (req, res) => {
  const position = matchQueue.findIndex(m => m.userId === req.userId);
  res.json({ position: position + 1, queueLength: matchQueue.length });
});

module.exports = router;
