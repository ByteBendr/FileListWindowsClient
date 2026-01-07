<p align="center">
  <a href="https://filelist.io/">
    <img alt="Filelist" src="https://i.epvpimg.com/TI5dbab.png">
  </a>
</p>

# FileList Client (Windows)

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![Platform](https://img.shields.io/badge/platform-Windows-informational)
![Framework](https://img.shields.io/badge/.NET-WinForms-purple)
![Status](https://img.shields.io/badge/status-educational%20use-yellow)

A lightweight **Windows desktop client** for browsing and downloading torrent files from **FileList.io**, built with **C# and WinForms**.  
The application uses FileList’s official API to search torrents, browse latest uploads by category, and download `.torrent` files directly to your system.

> ⚠️ This project is intended for **educational and personal use** by **registered FileList users only**.

---

## ✨ Features

- 🔐 Secure login using **FileList username + passkey**
- 🔎 Search torrents by name or IMDb ID
- 🆕 Browse latest torrents by category
- 🎛️ Advanced filters (moderated, internal, freeleech, double-up)
- 📥 Download `.torrent` files
- 📂 Configurable download folder
- 💾 Persistent settings
- 📊 Seeder / leecher info

---

## 🧠 How It Works

- Communicates with **FileList.io HTTP API**
- Authentication uses a **passkey hash**, not a password
- JSON parsing via **Newtonsoft.Json**
- Settings stored in `%AppData%\FileListClient\settings.json`
- Downloads metadata only (`.torrent` files)

---

## 🔑 Authentication – IMPORTANT

### ❗ Passkey ≠ Password

This app **never uses your FileList password**.

You must provide your **FileList passkey**, a unique API hash tied to your account, ***you can find it in your profile page in the Reset Passkey section***, or by accessing this link.

### [FileList Profile Page](https://filelist.io/my.php)

📸 You need **THIS PASSKEY (NOT THE PASSWORD)**:

![Where to find your FileList passkey](Passkey.png)

Treat your passkey like a secret API token.

---

## 📚 API Reference Credit

API behavior and parameters referenced from:

[ikevin127's Github Repository of the FileList app, where API Documentation is made available](https://github.com/ikevin127/filelist-app)

Used strictly as documentation/reference.

---

## 🧰 Requirements

- Windows
- .NET Framework
- Valid FileList.io account
- Active FileList passkey

---

## ▶️ Usage

1. Launch the app
2. Login with username + passkey
3. Search or browse torrents
4. Download `.torrent`
5. Open with your torrent client

---
## 📋 API Documentation

```
# General info

- All calls to the API have to be sent as a GET request
- All the arguments listed below are set as parameters in the call URL
- Every API call requires authentication with Username and Passkey
- Every user is limited to 150 API calls per hour

# Authentication

 Parameters:
   username
   passkey
 Example: https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]

 # Parameters & endpoints

 Parameters:
   action
 Valid values: search-torrents, latest-torrents
 Example: https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]&action=search-torrents

 - Additional parameters for action=search-torrents
   type               Valid values: imdb, name
   query              If you choose imdb as type, it is accepted in two forms: tt4719744 or 4719744;
   name               Accepted as an optional parameter if type=imdb. Also searches in the name field.
   category           Valid values: IDs from categories, multiple values ​​separated by a comma are accepted.
   moderated          Valid values: 0,1
   internal           Valid values: 0,1
   freeleech          Valid values: 0,1
   doubleup           Valid values: 0,1
   output             Valid values: json, rss. Default is JSON.
   season             Valid values integers
   episode            Valid values integers

 - Additional parameters for action=latest-torrents
   limit         Maximum number of torrents displayed in the request. Can be 1-100. Default value: 100
   imdb          Accepted as: tt4719744 or 4719744
   category      Valid values: IDs from categories, multiple values ​​separated by a comma are accepted.
   output        Valid values: json, rss. Default is JSON.

 - Examples:
   https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]&action=search-torrents&type=name&query=Gemini

   https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]&action=search-torrents&type=imdb&query=tt4719744&category=4,19

   https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]&action=latest-torrents

   https://filelist.io/api.php?username=[USERNAME]&passkey=[PASSKEY]&action=latest-torrents&output=rss

 # Category ID Codes

+----+------------------+
| id | name             |
+----+------------------+
|  1 | Filme SD         |
|  2 | Filme DVD        |
|  3 | Filme DVD-RO     |
|  4 | Filme HD         |
|  5 | FLAC             |
|  6 | Filme 4K         |
|  7 | XXX              |
|  8 | Programe         |
|  9 | Jocuri PC        |
| 10 | Jocuri Console   |
| 11 | Audio            |
| 12 | Videoclip        |
| 13 | Sport            |
| 14 | TV               |
| 15 | Desene           |
| 16 | Docs             |
| 17 | Linux            |
| 18 | Diverse          |
| 19 | Filme HD-RO      |
| 20 | Filme Blu-Ray    |
| 21 | Seriale HD       |
| 22 | Mobile           |
| 23 | Seriale SD       |
| 24 | Anime            |
| 25 | Filme 3D         |
| 26 | Filme 4K Blu-Ray |
| 27 | Seriale 4K       |
+----+------------------+

 # Error codes

 400 - Invalid search/filter
 401 - Username and passkey cannot be empty.
 403 - Too many failed authentications
 403 - Invalid passkey/username
 429 - Rate limit reached
 503 - Service unavailable
```

---

## ⚠️ Legal

See **DISCLAIMER.md** and **NOTICE.md** for full legal and responsibility limitations.

---

## 🧾 License

Educational / personal-use project.
