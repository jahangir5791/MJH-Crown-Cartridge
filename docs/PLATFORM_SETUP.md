# Platform Setup Guide

## Android Setup

1. Install **Android Studio**
2. Download **SDK Tools**:
   - Android SDK Platform 34
   - Android SDK Build-Tools 34
   - Android SDK Platform-Tools
3. In Unity: **Edit > Preferences > External Tools** → Set Android SDK path
4. **File > Build Settings** → Switch to **Android**
5. **Player Settings**:
   - Company Name: YourName
   - Package Name: com.yourcompany.mjhgame
   - Min SDK: API 24
   - Target SDK: API 34
6. Create **KeyStore**:
   - Unity > Player Settings > Publishing Settings > Create New Keystore
   - Save as `mjhgame.keystore`
7. Build **.aab** file

## iOS Setup

1. Install **Xcode** (macOS only)
2. Create **Apple Developer Account** ($99/year)
3. In Unity: **File > Build Settings** → Switch to **iOS**
4. **Player Settings**:
   - Bundle Identifier: com.yourcompany.mjhgame
   - Version: 1.0.0
5. **Build** → Opens in Xcode
6. In Xcode:
   - Signing & Capabilities → Select Team
   - Create Provisioning Profile
   - Product > Archive
   - Distribute App → App Store Connect

## Windows Setup

1. **File > Build Settings** → Switch to **Windows**
2. **Player Settings**:
   - Product Name: MJHGame
   - Company Name: YourName
3. Scripting Backend: **IL2CPP**
4. Build **.exe**

## macOS Setup

1. **File > Build Settings** → Switch to **macOS**
2. **Player Settings**:
   - Bundle Identifier: com.yourcompany.mjhgame
3. Build → **.app** file
4. **Notarization** (required for distribution):
   - `xcrun notarytool submit ... --keychain-profile "MyProfile"`

## Linux Setup

1. **File > Build Settings** → Switch to **Linux**
2. Build → **.x86_64** executable
3. Publish to **Steam** or **itch.io**

## WebGL Setup

1. **File > Build Settings** → Switch to **WebGL**
2. **Player Settings**:
   - Compression Format: **Gzip**
   - Enable **Progressive Loading**
3. Build → Upload to web server
4. Enable **PWA** (manifest.json, sw.js)
