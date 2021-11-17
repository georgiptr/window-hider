# window-hider
Hide or show multiple windows based on partial window title match. This is the Windows version. [The Linux version is here](https://github.com/georgiptr/window-hider-linux).

### Removing distractions
These days multiple apps are fighting for your attention: Skype, WhatsApp, Viber, Messenger, Slack, Hangouts... If you could only mute them while working and once you are ready for a break to look at them again...

Now you can.

![Show Hide Animation](https://github.com/georgiptr/window-hider/raw/master/Images/showhide.gif)

```
WindowHider.exe hide viber whatsapp skype inbox messenger gmail "or some multi-word app title"
```

And their windows disappear. Even from the Windows Taskbar. The apps will continue working in the background.

```
WindowHider.exe show viber whatsapp skype inbox messenger gmail "or some multi-word app title"
```

Here they come again.

Another option is to use "toggle" which switches windows visibility.

```
WindowHider.exe toggle viber whatsapp skype inbox messenger gmail "or some multi-word app title"
```

All the words coming after show/hide/toggle are used to partially match the window title, case insensitive. Quotes to match a single title of multiple words is also supported.

### A great alternative: Windows 10 Virtual Desktops

Nowadays I'm using an even better alternative: [Windows 10 Virtual Desktops](https://community.windows.com/en-us/stories/virtual-desktop-windows-10). I place all distracting apps on one virtual desktop and all my important apps on another.

### Usage

```
WindowHider.exe (show|hide|toggle) partialWindowTitle1, partialWindowTitle2, ...
```

Note: The app prints on the console the full titles of all matched windows. Just in case you need them.

### Ideas

I keep Gmail's Inbox and Facebook's Messenger into a separate Chrome window. This way I hide them too.

If you haven't read [Cal Newport - Deep Work: Rules for Focused Success in a Distracted World](https://www.goodreads.com/book/show/25744928-deep-work) yet, please do.

### Download

Go to [Releases](https://github.com/georgiptr/window-hider/releases) page and download the latest .EXE

Note: Chrome may warn you that the file is unknown. You can upload the file for online virus check at [VirusTotal](https://www.virustotal.com) or compile it from the source code.

### Global Shortcuts

You can assign a global shortcut (like CTRL+SHIFT+1) for hiding and another one (like CTRL+SHIFT+2) for showing the apps. You can also have just one shortcut and use the "toggle" option which switches each window between visible/invisible states.

1. Put WindowHider.exe somewhere.
2. Open %APPDATA%\Microsoft\Windows\Start Menu\Programs
3. Create a shortcut of WindowHider.exe there, name it Hide
4. Right click Hide, Properties, Target: ...\WindowHider.exe toggle windowTitle1, windowTitle2, ...
5. Click on Shortcut key
6. Press the shortcut combination you want to use
7. Give it some time to work (3 seconds)
8. Do the same for Show

Now from anywhere in Windows press the shortcut combination to hide or show the apps.

Animated:

![Shortcuts Animation](https://github.com/georgiptr/window-hider/raw/master/Images/showhide2.gif)
