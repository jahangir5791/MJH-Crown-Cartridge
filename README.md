# MJH-Crown-Cartridge 🎮

A **cross-platform Unity game** that runs on **Windows, Mac, Linux, Android, iOS, and WebGL**. Publish to Play Store, App Store, and Microsoft Store.

## 📁 Project Structure

MJH-Crown-Cartridge/
├── 0_Launcher/          # Splash screen, platform detection
├── 1_Common/            # Shared systems (GameManager, Audio, UI)
├── 2_MJH-Cartridge/     # Shooter game module
├── 3_MJH-Crown/         # Kingdom strategy module
├── 4_Build/             # Build outputs for all platforms
├── 5_StoreAssets/       # Store assets for Play Store & App Store
├── 6_MobileNative/      # Android & iOS native bridges
├── 7_DesktopNative/     # Windows, Mac, Linux native features
├── apps/                # Backend server for multiplayer
└── docs/                # Documentation

## 🚀 Features

- ✅ **Cross-platform**: One codebase, 6 platforms
- ✅ **Launcher system**: Auto-detects platform and routes
- ✅ **Shooter game**: Zombie shooter with waves and power-ups
- ✅ **Kingdom game**: Strategy, building, unit training, battles
- ✅ **Mini-game**: Math puzzle for skill building
- ✅ **Cloud save**: iCloud (iOS) + Google Drive (Android)
- ✅ **Cross-platform input**: Touch, mouse, keyboard support
- ✅ **PWA support**: Offline-capable WebGL version

## 🎯 Platform Support

| Platform | Build Target | Store |
|----------|-------------|-------|
| Android | Android | Play Store |
| iOS | iOS | App Store |
| Windows | PC Standalone | Microsoft Store |
| macOS | macOS | Mac App Store |
| Linux | Linux Standalone | Steam/itch.io |
| WebGL | WebGL | Browser/PWA |

## 🛠️ Setup Instructions

### Unity Setup
1. Open Unity Hub → **Open Project** → Select this folder
2. Go to **File > Build Settings**
3. Add scenes from `0_Launcher/Scenes`, `2_MJH-Cartridge/Scenes`, `3_MJH-Crown/Scenes`
4. Switch platform (Android, iOS, Windows, etc.)
5. Click **Build**

### Android Build (Play Store)
Min SDK: API 24
Target SDK: API 34
Build .aab file

### iOS Build (App Store)
Open in Xcode
Create Provisioning Profile
Archive → App Store Connect

## 📚 Documentation

- `docs/PLATFORM_SETUP.md` - Platform-specific setup guide
- `docs/PLAY_STORE_GUIDE.md` - Play Store publishing guide
- `docs/APP_STORE_GUIDE.md` - App Store publishing guide
- `docs/API/` - Backend API documentation

## 📄 License

MIT License - See [LICENSE](LICENSE) file

## 🎮 Game Modes

1. **MJH-Cartridge**: Zombie shooter with waves, weapons, power-ups
2. **MJH-Crown**: Kingdom strategy with building, units, battles, puzzles

## 📞 Support

For issues or questions, open an issue on GitHub.
