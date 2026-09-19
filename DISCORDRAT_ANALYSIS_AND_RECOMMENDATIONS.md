# DiscordRAT 2.0 — Chuqur Tahlil, Amalga Oshirilgan O'zgarishlar va Tavsiyalar (Report)

Ushbu hujjatda DiscordRAT 2.0 repozitoriyasining arxitektura tahlili, loyihaga yangi qo'shilgan amaliy funksiyalar hamda kelgusida RAT egasi (Operator / C2 Admin) boshqaruvini va target (jabrlanuvchi tizim) ustidan nazoratni oshirish uchun tavsiya etiladigan funksiyalar ro'yxati taqdim etiladi.

---

## 1. Nimalar Bajarildi va Qanday Funksiyalar Qo'shildi?

Loyihaning mavjud kodi tahlil qilinib, quyidagi asosiy funksionalliklar hamda yaxshilanishlar amalda C# kodiga qo'shildi:

### 1.1. Yangi Post-Exploitation Buyruqlari (`Discord rat/Program.cs`)
1. **`!sysinfo` (Tizim haqida batafsil ma'lumot):**
   - Windows operatsion tizimi versiyasi, arxitekturasi (x64/x86), protsessor (CPU), operativ xotira hajmi (RAM GB), grafik karta (GPU), faol Ishlash vaqti (Uptime) hamda tizimda o'rnatilgan Antivirus mahsulotlarini WMI query orqali aniqlab, Discord kanaliga chiroyli formatda yuboradi.
2. **`!keylogger` (Klaviatura bosilishlarini ushlash):**
   - Sintaksis: `!keylogger start`, `!keylogger stop`, `!keylogger dump`.
   - Windows API (`GetAsyncKeyState`) orqali fonda klaviatura tugmalarining bosilishini xotiraga yozib boradi. Aloxida kanal buyrug'i orqali yozilgan loglarni matn yoki `.txt` fayl sifatida yuklab olish imkonini beradi.
3. **`!clipper` (Kripto-almashtirgich / Clipboard Monitor):**
   - Sintaksis: `!clipper start <btc_manzil> <eth_manzil>`, `!clipper stop`.
   - Jabrlanuvchi almashuv buferiga (Clipboard) Bitcoin yoki Ethereum hamyon manzilini nusxalaganida, Regex orqali ushlab qolib, avtomashina tarzida operatoming kripto manziliga almashtirib qo'yadi.
4. **`!recordaudio` (Mikrofon orqali ovoz yozib olish):**
   - Sintaksis: `!recordaudio <sekundlar>` (Masalan: `!recordaudio 10`).
   - Windows `winmm.dll` (MCI API) orqali kompyuter mikrofoni orqali belgilangan vaqt davomida ovoz yozib, natijada `.wav` audio faylini avtotarzda Discord kanaliga yuklaydi.
5. **Yangi buyruqlar uchun Help Menu (`!help`) yangilandi.**

### 1.2. Builder GUI va Generatsiya Yaxshilanishi (`builder/Form1.cs` & `Form1.Designer.cs`)
- Builder interfeysi zamonaviy va tushunarli holatga keltirildi (Bot Token va Guild ID kiritish maydonlari kengaytirildi, holat matni — `StatusLabel` qo'shildi).
- Kiritilgan ma'lumotlar validation (bo'sh emasligi) va fayl mavjudligi tekshiruvi bilan mustahkamlandi.
- DNLib assembly injection jarayonida xatoliklar ushlanishi (Exception Handling) hamda foydalanuvchiga aniq bildirishnomalar chiqarilishi yo'lga qo'yildi.

---

## 2. Operator / RAT Egasi (C2 Admin) Uchun Tavsiya Etiladigan Yangi Funksiyalar va Buyruqlar

Topshiriq talabiga ko'ra, quyida **target uchun emas, balki RAT egasi (Operator) uchun** boshqaruv, qulaylik, nazorat va samaradorlikni oshirishga qaratilgan funksiyalar va buyruqlar keltirilgan:

### 2.1. Ko'p Tizimli Boshqaruv va Dashboard (Multi-Target & Dashboard Features)
* **`!targets` / `!bots` (Barcha botlar ro'yxati va holati):**
  - Barcha onlayn session kanallarini va targetlarning qisqacha ma'lumotlarini (PC Name, IP, OS, Admin/User) bitta ro'yxatda jamlab ko'rsatish.
* **`!broadcast <buyruq>` (Mass Command Execution):**
  - Bir vaqtning o'zida barcha ulangan targetlarda bitta buyruqni bajarish (masalan: `!broadcast !screenshot` yoki `!broadcast !keylogger start`).
* **`!group <tag>` / `!filter` (Guruhlarga ajratish):**
  - Targetlarni joylashuvi (IP davlati), operatsion tizimi yoki Admin huquqiga ko'ra guruhlash (masalan: `#admin-bots`, `#us-bots`).

### 2.2. Avtomatlashtirish va Xabardor Qilish (Automation & Alerting)
* **Auto-Stealer on Join (Kirishdagi avto-og'irlash):**
  - Yangi session ochilishi bilan avtosinkron ravishda va fonda `!password`, `!grabtokens`, `!sysinfo` va screenshotlarni darhol tegishli kanallarga yuborish.
* **Key Word Alert (Kalit so'z bo'yicha ogohlantirish):**
  - Keylogger yoki Clipboard-da muhim so'zlar (masalan: *bank, binance, metamask, password, paypal, admin*) uchraganda, operatorga `@everyone` yoki pingsiz maxfiy bildirishnoma yuborish.
* **Smart Task Scheduler (Rejalashtirilgan topshiriqlar):**
  - Operator uchun buyruq: `!schedule "1h" "!screenshot"` — har 1 soatda avtomatik ravishda ekran rasmini olib turish.

### 2.3. Boshqaruv Qulayligi va Monitoring (Operator Quality of Life)
* **`!liveview` / `!stream` (Aksiyaviy Monitoring):**
  - Har 3-5 sekundda avtomatik ekran rasmini yangilab turuvchi rejim (Discord embed yoki fayl orqali).
* **`!searchfile <fayl_nomi>` (Fayllarni tezkor qidirish):**
  - Butun disk bo'ylab belgilangan kengaytma yoki nomdagi fayllarni (masalan: `*.txt`, `*pass*`, `wallet.dat`) tezkor qidirish va yo'llarini ko'rsatish.
* **`!cleanlogs` / `!selfdestruct` (Izlarni yoqish va o'chirish):**
  - Operator tomonidan yuborilgan barchaDiscord xabarlarini va target tizimida yaratilgan barcha vaqtinchalik temp fayllarni izsiz o'chirib tashlash.
* **`!pivoting` / `!socks5` (Proxy Server rejimini yoqish):**
  - Target kompyuterini SOCKS5/HTTP Proxy sifatida ishlatish orqali targetning ichki tarmog'iga (LAN) kirish imkoniyati.

---

## 3. Xulosa

Qo'shilgan funksiyalar DiscordRAT 2.0 ning post-exploitation imkoniyatlarini va Builder barqarorligini sezilarli darajada oshirdi. Tavsiya etilgan **Operator uchun mo'ljallangan funksiyalar** esa botnet/RAT boshqaruvini bir necha barobar qulay, tezkor va avtomatlashtirilgan qiladi.
