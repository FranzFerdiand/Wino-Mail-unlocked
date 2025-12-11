# Building and Installing Wino-Mail-unlocked

This fork of Wino Mail has been modified to **unlock the "Unlimited Accounts" feature** without requiring a Windows Store purchase.

## Prerequisites

### Required Tools
- **Windows 10/11** (version 1809 or later)
- **Visual Studio 2022** (Community edition or higher)
  - Install with the **Universal Windows Platform development** workload
  - Install the **Windows 10 SDK (10.0.26100.0)** or later
- **.NET SDK 9.0** or later

### Installation via winget
```powershell
winget install --id Microsoft.VisualStudio.2022.Community --silent --override "--add Microsoft.VisualStudio.Workload.Universal --add Microsoft.VisualStudio.Component.Windows11SDK.26100 --includeRecommended --passive"
```

## Building from Source

### 1. Clone the Repository
```powershell
git clone https://github.com/YOUR_USERNAME/Wino-Mail-unlocked.git
cd Wino-Mail-unlocked
```

### 2. Restore Dependencies
```powershell
dotnet restore WinoMail.slnx
```

### 3. Build the Solution
```powershell
& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" WinoMail.slnx -restore -p:Configuration=Debug -p:Platform=x64
```

**Expected Output:**
- 0 Errors
- ~240-250 Warnings (non-blocking)
- Build time: ~3-5 minutes

### 4. Locate Build Artifacts
After a successful build, packages are located at:
```
WinoMail.Packaging\AppPackages\WinoMail.Packaging_1.10.5.0_Debug_Test\
```

## Installation

### Option 1: Visual Studio Deployment (Recommended for Development)
1. Open `WinoMail.slnx` in Visual Studio 2022
2. Right-click **WinoMail.Packaging** → **Set as Startup Project**
3. Select **x64** platform from the toolbar
4. Press **F5** to deploy and run

### Option 2: Manual Installation from Build Artifacts

#### Prerequisites
- **Developer Mode** must be enabled:
  - Go to **Settings → Privacy & Security → For developers**
  - Enable **Developer Mode**

#### Steps

**1. Create and Install Self-Signed Certificate** (Admin PowerShell required):
```powershell
# Generate certificate
New-SelfSignedCertificate -Type Custom -Subject "CN=51FBDAF3-E212-4149-89A2-A2636B3BC911" -KeyUsage DigitalSignature -FriendlyName "WinoMail Dev Certificate" -CertStoreLocation "Cert:\CurrentUser\My" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")

# Export certificate (replace THUMBPRINT with output from above)
Get-ChildItem -Path Cert:\CurrentUser\My\THUMBPRINT | Export-Certificate -FilePath WinoMail_Dev.cer

# Install to Trusted People (requires Admin PowerShell)
Import-Certificate -FilePath WinoMail_Dev.cer -CertStoreLocation Cert:\LocalMachine\TrustedPeople
```

**2. Sign the Package** (if not already signed):
```powershell
& "C:\Program Files (x86)\Windows Kits\10\bin\10.0.26100.0\x64\signtool.exe" sign /fd SHA256 /sha1 THUMBPRINT "WinoMail.Packaging\AppPackages\WinoMail.Packaging_1.10.5.0_Debug_Test\WinoMail.Packaging_1.10.5.0_x86_x64_arm64_Debug.msixbundle"
```

**3. Remove Any Existing Installation** (if upgrading):
```powershell
Get-AppxPackage -Name "*WinoMail*" -AllUsers | Remove-AppxPackage -AllUsers
```

**4. Install the App Bundle**:
```powershell
Add-AppxPackage -Path "WinoMail.Packaging\AppPackages\WinoMail.Packaging_1.10.5.0_Debug_Test\WinoMail.Packaging_1.10.5.0_x86_x64_arm64_Debug.msixbundle"
```

## Verification

1. Launch **Wino Mail** from the Start Menu
2. Navigate to **Settings → Manage Accounts**
3. Verify:
   - ✅ No purchase panel is visible
   - ✅ You can add more than 3 email accounts

## What Was Changed?

### `Wino.Core.UWP/Services/StoreManagementService.cs`
The following methods were modified to bypass Windows Store license checks:

- **`HasProductAsync()`**: Now always returns `true`
- **`PurchaseAsync()`**: Now always returns `AlreadyPurchased`

This effectively grants the "Unlimited Accounts" feature to all users without requiring a Microsoft Store purchase.

## Troubleshooting

### Build Errors
- **Missing UWP SDK**: Ensure Visual Studio 2022 with UWP workload is installed
- **XAML Errors**: These typically only occur during CLI builds and are resolved by building in Visual Studio

### Installation Errors
- **0x80073CF9 (Package already installed)**: Remove the existing package first using `Remove-AppxPackage`
- **0x800B0109 (Certificate not trusted)**: Ensure the certificate is installed to `Cert:\LocalMachine\TrustedPeople`
- **0x80073CFB (Different content, same identity)**: Version conflict. Remove old version first.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

**Note**: This is an unofficial modification of Wino Mail. The original project can be found at [https://github.com/bkaankose/Wino-Mail](https://github.com/bkaankose/Wino-Mail).
