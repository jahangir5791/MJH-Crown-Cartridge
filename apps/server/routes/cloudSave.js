const express = require('express');
const router = express.Router();
const authMiddleware = require('../middleware/authMiddleware');
const GameData = require('../models/GameData');

// Save game data
router.post('/save', authMiddleware, async (req, res) => {
  try {
    const { gameData } = req.body;
    
    let savedData = await GameData.findOne({ userId: req.userId });
    
    if (savedData) {
      savedData.data = gameData;
      savedData.updatedAt = Date.now();
      await savedData.save();
    } else {
      savedData = new GameData({ userId: req.userId, data: gameData });
      await savedData.save();
    }

    res.json({ success: true, message: 'Game saved successfully' });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Load game data
router.get('/load', authMiddleware, async (req, res) => {
  try {
    const savedData = await GameData.findOne({ userId: req.userId });
    
    if (!savedData) {
      return res.json({ success: true, data: null, message: 'No save data found' });
    }

    res.json({ success: true, data: savedData.data });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Delete save
router.delete('/delete', authMiddleware, async (req, res) => {
  try {
    await GameData.deleteOne({ userId: req.userId });
    res.json({ success: true, message: 'Save data deleted' });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

module.exports = router;
