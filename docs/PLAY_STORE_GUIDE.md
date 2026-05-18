# Play Store Publishing Guide

## Prerequisites

- Google Play Developer Account ($25 one-time)
- Android .aab file (Min SDK 24, Target SDK 34)
- Keystore file (`mjhgame.keystore`)

## Steps

### 1. Create App in Play Console
1. Go to [Google Play Console](https://play.google.com/console)
2. Click **Create App**
3. Fill in:
   - App name: **MJH-Crown-Cartridge**
   - Default language: **English**
   - App or Game: **Game**

### 2. Store Listing
Upload to `5_StoreAssets/PlayStore/store_listing/`:
- **Icon**: 512×512 PNG
- **Feature Graphic**: 1024×500 PNG
- **Screenshots**: At least 2 (16:9 or 9:16)
- **Promo Video** (optional): MP4

### 3. Content Rating
- Complete **Content Rating questionnaire**
- Get IARC rating

### 4. Privacy Policy
- Host privacy policy URL
- Add to app settings

### 5. Build & Upload
1. In Unity: **Player Settings > Publishing Settings**
2. Load keystore
3. Build **Internal Testing** .aab
4. Upload to **Internal Testing** track
5. Test with 20 testers for 14 days
6. Promote to **Closed Testing** → **Open Testing** → **Production**

### 6. Release to Production
- Create **Production release**
- Write **What's New** (changelog)
- Click **Start Rollout**
