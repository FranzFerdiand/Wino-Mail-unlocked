
<p align="center">
  <a href="https://github.com/FranzFerdiand/Wino-Mail-unlocked">
    <img src="https://www.winomail.app/images/wino_logo.png" width=90 height=90>
  </a>

  <h3 align="center">Wino Mail Unlocked</h3>

  <p align="center">
    Native mail client for Windows with unlimited accounts - no purchase required
  </p>
</p>

<br>

![pdark](https://user-images.githubusercontent.com/12009960/232114528-2d2c8e3c-dbe7-429a-94e0-6aecc73bdf70.png)

## ⚠️ Important Notice

This is an **unofficial fork** of [Wino Mail](https://github.com/bkaankose/Wino-Mail) that **removes the purchase restriction** for unlimited email accounts. 

**What's changed:**
- ✅ Unlimited account support (no 3-account limit)
- ✅ No Windows Store purchase required
- ✅ All original features intact

## Motivation

I'm a big fan of Windows Mail & Calendars due to its simplicity. Personally, I find it more intuitive for daily use cases compared to Outlook desktop and the new WebView2 powered Outlook version. Seeing [Microsoft deprecating it](https://support.microsoft.com/en-us/office/outlook-for-windows-the-future-of-mail-calendar-and-people-on-windows-11-715fc27c-e0f4-4652-9174-47faa751b199#:~:text=The%20Mail%20and%20Calendar%20applications,will%20no%20longer%20be%20supported.) dragged the original author into starting to work on Wino a couple of years ago. Wino's main motivation is to bring all the existing functionality from Mail & Calendars over time without changing the user experience that millions have loved since the Windows 8 days in Mail & Calendars.

## Features

- API integration for Outlook and Gmail
- IMAP/SMTP support for custom mail servers
- Send, receive, mark as (read,important,spam etc), move mails.
- Linked/Merged Accounts
- **Unlimited email accounts** (unlocked in this fork)
- Toast notifications with background sync.
- Instant startup performance
- Offline use / search.
- Modern and responsive UI
- Lots of personalization options
- Dark / Light mode for mail reader

## Installation

Since this is a freshly forked project, there are no pre-built releases yet. You'll need to build from source.

### Building from Source

See [BUILD.md](BUILD.md) for comprehensive instructions on:
- Installing prerequisites (Visual Studio 2022, Windows SDK)
- Building the project with MSBuild
- Creating and installing the self-signed certificate
- Installing the MSIX package

**Quick Build Steps:**
1. Install Visual Studio 2022 with UWP workload
2. Clone this repository
3. Build with MSBuild:
   ```powershell
   & "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" WinoMail.slnx -restore -p:Configuration=Debug -p:Platform=x64
   ```
4. Follow certificate creation and installation steps in [BUILD.md](BUILD.md)

Alternatively, open `WinoMail.slnx` in Visual Studio, set `WinoMail.Packaging` as startup project, and press **F5** to build and deploy.

## Contributing

This fork maintains the same contribution guidelines as the original project. Check out the [contribution guidelines](/CONTRIBUTING.md) before diving into the source code or opening an issue.

## Support the Original Developer

If you find this software useful, please consider supporting the original author:

- [Original Wino Mail Repository](https://github.com/bkaankose/Wino-Mail)
- [Donate via PayPal](https://www.paypal.com/donate/?hosted_button_id=LGPERGGXFMQ7U)
- [Project Website](https://www.winomail.app/)

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE.md](LICENSE.md) file for details.

**Original Project:** [Wino Mail by Burak KÖSE](https://github.com/bkaankose/Wino-Mail)

