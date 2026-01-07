# Security Policy

## 🔐 Supported Versions

This project is provided for **educational and personal use only**.
There are no long-term support guarantees.

| Version | Supported |
|--------|-----------|
| 1.0.x  | ✅ Limited |
| < 1.0  | ❌ No     |

---

## 🚨 Reporting a Vulnerability

If you discover a security vulnerability, please follow these steps:

1. **DO NOT** disclose the issue publicly.
2. **DO NOT** open a public GitHub issue describing the vulnerability.
3. Contact the project maintainer privately (if contact information is provided in the repository).

When reporting, include:
- A clear description of the vulnerability
- Steps to reproduce
- Potential impact
- Any suggested mitigations (optional)

---

## 🔑 Credentials & Sensitive Data

- This application stores **username and passkey locally** on the user’s system.
- Credentials are saved in:
  ```
  %AppData%\FileListClient\settings.json
  ```
- No credentials are transmitted to any third-party service.
- The application does **not** log credentials.

⚠️ Users are responsible for securing their local system.

---

## 🌐 Network Security

- All API communication is performed via **HTTPS**
- No traffic interception, proxying, or packet manipulation is performed
- The app only communicates with the official FileList API endpoint

---

## ⚠️ Scope Limitations

This project:
- Does NOT attempt to bypass authentication or rate limits
- Does NOT exploit or probe API weaknesses
- Does NOT include obfuscation or evasion techniques
- Is NOT intended for malicious usage

---

## 🛑 No Bug Bounty

This project does **not** offer a bug bounty program.

Security reports are handled on a **best-effort basis**.

---

## 📌 Final Note

Use this software responsibly.
Any misuse, modification, or redistribution that violates third-party terms
is strictly the responsibility of the end user.
