# App Store Publishing Guide

## Prerequisites

- Apple Developer Account ($99/year)
- Mac with Xcode
- iOS .ipa file

## Steps

### 1. Create App in App Store Connect
1. Go to [App Store Connect](https://appstoreconnect.apple.com)
2. Click **My Apps** → **+** → **New App**
3. Fill in:
   - Platform: **iOS**
   - App Name: **MJH-Crown-Cartridge**
   - Bundle ID: **com.yourcompany.mjhgame**
   - SKU: **MJH001**

### 2. App Icons & Screenshots
Upload to `5_StoreAssets/AppStore/`:
- **Icon-1024**: 1024×1024 PNG
- **Screenshots**:
  - iPhone 6.5": 1242×2688
  - iPad 12.9": 2048×2732

### 3. App Privacy
- Complete **App Privacy** section
- Declare data collection (if any)

### 4. Build & Upload
1. In Unity: **File > Build Settings** → **iOS**
2. Build → Opens in Xcode
3. In Xcode:
   - **Signing & Capabilities**: Select Team
   - **Product > Archive**
4. **Window > Organizer** → **Distribute App**
5. **App Store Connect** → **Upload**

### 5. Submit for Review
1. Go to app in App Store Connect
2. Fill in:
   - **Description**
   - **Keywords**
   - **Support URL**
   - **Marketing URL** (optional)
3. Click **Add for Review**
4. Submit for Apple review (1–3 days)
