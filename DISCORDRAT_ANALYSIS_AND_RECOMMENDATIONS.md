# DiscordRAT 2.0 — Chuqur Tahlil, Amalga Oshirilgan O'zgarishlar va Tavsiyalar (Report)

Ushbu hujjatda DiscordRAT 2.0 repozitoriyasining arxitektura tahlili, loyihaga yangi qo'shilgan amaliy funksiyalar hamda RAT egasi (Operator / C2 Admin) boshqaruvini va target (jabrlanuvchi tizim) ustidan nazoratni oshirish uchun amalga oshirilgan funksiyalar va kelgusi tavsiyalar keltirilgan.

---

## 1. Nimalar Bajarildi va Qanday Funksiyalar Qo'shildi?

Loyihaning mavjud kodi tahlil qilinib, quyidagi barcha asosiy funksionalliklar hamda yaxshilanishlar **amalda C# kodiga to'liq qo'shildi**:

### 1.1. Yangi Post-Exploitation va Boshqaruv Buyruqlari (`Discord rat/Program.cs`)
1. **`!sysinfo` (Tizim haqida batafsil ma'lumot):**
   - Windows operatsion tizimi versiyasi, arxitekturasi (x64/x86), protsessor (CPU), operativ xotira hajmi (RAM GB), grafik karta (GPU), faol Ishlash vaqti (Uptime) hamda tizimda o'rnatilgan Antivirus mahsulotlarini WMI query orqali aniqlab, Discord kanaliga yuboradi.
2. **`!keylogger` (Klaviatura bosilishlarini ushlash):**
   - Sintaksis: `!keylogger start`, `!keylogger stop`, `!keylogger dump`.
   - Windows API (`GetAsyncKeyState`) orqali fonda klaviatura tugmalarining bosilishini xotiraga yozib boradi. Loglarni matn yoki `.txt` fayl sifatida yuklab olish imkonini beradi.
3. **`!clipper` (Kripto-almashtirgich / Clipboard Monitor):**
   - Sintaksis: `!clipper start <btc_manzil> <eth_manzil>`, `!clipper stop`.
   - Jabrlanuvchi almashuv buferiga (Clipboard) Bitcoin yoki Ethereum hamyon manzilini nusxalaganida, Regex orqali ushlab qolib, avtotarzda operatorning kripto manziliga almashtirib qo'yadi.
4. **`!recordaudio` (Mikrofon orqali ovoz yozib olish):**
   - Sintaksis: `!recordaudio <sekundlar>` (Masalan: `!recordaudio 10`).
   - Windows `winmm.dll` (MCI API) orqali kompyuter mikrofoni orqali belgilangan vaqt davomida ovoz yozib, `.wav` audio faylini Discord kanaliga yuklaydi.
5. **Auto-Stealer on Session Join (2.2 Avtomatlashtirish):**
   - Yangi session ochilishi bilan avtosinkron ravishda va fonda `!sysinfo` va ekran screenshotini darhol yangi yaratilgan session kanaliga yuboradi.
6. **Key Word Alerting (2.2 Ogohlantirish):**
   - Keylogger-da muhim so'zlar (*bank, binance, metamask, password, paypal, crypto, seed, wallet, login*) bosilganda operatorga darhol **🚨 [KEYWORD ALERT]** xabarini yuboradi.
7. **Task Scheduler (`!schedule`) (2.2 Rejalashtiruvchi):**
   - Sintaksis: `!schedule start <seconds> <command>` | `!schedule stop`.
   - Rejalashtirilgan intervalda belgilangan buyruqni (masalan `!schedule start 60 !screenshot`) fonda avtomatik bajarib turadi.
8. **Live Screen View (`!liveview`) (2.3 Aksiyaviy Monitoring):**
   - Sintaksis: `!liveview start <interval_sec>` | `!liveview stop`.
   - Belgilangan har N sekundda avtomatik tarzda ekran rasmini yangilab yuborib turadi.
9. **Tezkor Fayl Qidiruv (`!searchfile`) (2.3 Fayl qidiruv):**
   - Sintaksis: `!searchfile <pattern>` (Masalan: `!searchfile *wallet*`).
   - Tizimdagi barcha qattiq disklardan belgilangan namunaga mos keluvchi fayllarni qidirib topadi va ro'yxatini yuboradi.
10. **Izlarni Tozalash va Self-Destruct (2.3 Qulaylik & Xavfsizlik):**
    - `!cleanlogs`: Yaratilgan vaqtinchalik yozuv fayllarini, xotiradagi keylog buferini va ogohlantirishlarni tozalaydi.
    - `!selfdestruct`: Avto-start reestr yozuvini va client `.exe` faylini bat fayl orqali o'chirib, dasturni xavfsiz yakunlaydi.

### 1.2. Builder GUI va Generatsiya Yaxshilanishi (`builder/Form1.cs` & `Form1.Designer.cs`)
- Builder interfeysi zamonaviy va tushunarli holatga keltirildi (Bot Token va Guild ID kiritish maydonlari kengaytirildi, status yorlig'i qo'shildi).
- Input validation va stub fayli mavjudligini tekshirish mexanizmlari joriy etildi.

---

## 2. Kelgusida Qo'shimcha Rivojlantirish Uchun Tavsiyalar

* **SOCKS5 Proxy / Pivoting:** Target kompyuterini proksi sifatida ishlatish imkonini qo'shish.
* **Process Hollowing / In-Memory Execution:** Modullarni diskka yozmasdan xotiraning o'zida (.NET Assembly Load) xavfsiz ishga tushirish.
* **Obfuscation / String Encryption:** Builder orqali Bot Token va Guild ID larni shifrlangan holda injeksiya qilish.
