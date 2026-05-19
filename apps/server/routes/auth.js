const express = require('express');
const router = express.Router();
const jwt = require('jsonwebtoken');
const bcrypt = require('bcryptjs');
const authMiddleware = require('../middleware/authMiddleware');
const User = require('../models/User');

// Register
router.post('/register', async (req, res) => {
  try {
    const { email, password, username, platform } = req.body;
    
    let user = await User.findOne({ email });
    if (user) {
      return res.status(400).json({ message: 'User already exists' });
    }

    const hashedPassword = await bcrypt.hash(password, 10);
    user = new User({ email, password: hashedPassword, username, platform });
    await user.save();

    const token = jwt.sign({ userId: user._id }, process.env.JWT_SECRET, { expiresIn: '7d' });
    res.json({ token, user: { id: user._id, email: user.email, username: user.username } });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Login
router.post('/login', async (req, res) => {
  try {
    const { email, password } = req.body;
    
    const user = await User.findOne({ email });
    if (!user) {
      return res.status(400).json({ message: 'Invalid credentials' });
    }

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) {
      return res.status(400).json({ message: 'Invalid credentials' });
    }

    const token = jwt.sign({ userId: user._id }, process.env.JWT_SECRET, { expiresIn: '7d' });
    res.json({ token, user: { id: user._id, email: user.email, username: user.username } });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Google OAuth
router.post('/google', async (req, res) => {
  try {
    const { googleId, email, username } = req.body;
    
    let user = await User.findOne({ googleId });
    if (!user) {
      user = new User({ googleId, email, username, authProvider: 'google' });
      await user.save();
    }

    const token = jwt.sign({ userId: user._id }, process.env.JWT_SECRET, { expiresIn: '7d' });
    res.json({ token, user: { id: user._id, email: user.email, username: user.username } });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Facebook OAuth
router.post('/facebook', async (req, res) => {
  try {
    const { facebookId, email, username } = req.body;
    
    let user = await User.findOne({ facebookId });
    if (!user) {
      user = new User({ facebookId, email, username, authProvider: 'facebook' });
      await user.save();
    }

    const token = jwt.sign({ userId: user._id }, process.env.JWT_SECRET, { expiresIn: '7d' });
    res.json({ token, user: { id: user._id, email: user.email, username: user.username } });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

// Apple OAuth (iOS)
router.post('/apple', async (req, res) => {
  try {
    const { appleId, email, username } = req.body;
    
    let user = await User.findOne({ appleId });
    if (!user) {
      user = new User({ appleId, email, username, authProvider: 'apple' });
      await user.save();
    }

    const token = jwt.sign({ userId: user._id }, process.env.JWT_SECRET, { expiresIn: '7d' });
    res.json({ token, user: { id: user._id, email: user.email, username: user.username } });
  } catch (error) {
    res.status(500).json({ message: 'Server error' });
  }
});

module.exports = router;
