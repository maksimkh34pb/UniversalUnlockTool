# Universal Unlock Tool

## Project structure
```
UniversalUnlockTool
│   README.md 
│
├─── LinuxUI                                     # Ui for Linux (later)
│   └───
│
├─── UniversalUnlockTool.Model                   # App logic 
│   └───
│
└─── UniversalUnlockTool.WPF.WindowUI             # UI for Windows
     ├─── Assets
     │    └───...
     │
     ├─── LocalModels         # Logic (only for Windows version)
     │    └─── LanguageSystem          # Switching languages in App
     │
     ├─── Resources      # Code assets
     │    └───Lang.*.xaml     # Language files
     │
     ├─── Skins     # UI styles
     │    ├─── BlackTheme.xaml      # Black (main and single) theme for app
     │    └─── Resources.xaml       # Brushes, colors, etc.
     │
     └─── UserControls          # Custom User Controls
           └─── TitleBar        # Title Bar
                 └─── ...

```