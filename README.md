<div align="center">
  <img src="WL-DL/icon.ico" width="128" alt="WL-DL Icon">
  <h1>WL-DL (WoltLab Package Downloader)</h1>
  <p><strong>A bilingual, lightweight Windows tool for fetching and backing up WoltLab packages.</strong></p>
</div>

<div align="center">
  <strong><a href="#english">English</a></strong> | <strong><a href="#deutsch">Deutsch</a></strong>
</div>

---

## <a id="english"></a>English

A lightweight, native Windows desktop tool designed to allow administrators to easily fetch and download packages directly from the WoltLab update and store servers.
Built in C# (.NET 2.0) and optimized for maximum compatibility.

### Features
- **User-Friendly Selection:** Fetches the XML package list and allows you to select exactly which packages you want to download via checkboxes.
- **Polite Scraping:** Includes a built-in request delay (300ms) to ensure WoltLab servers are never overloaded.
- **Bilingual UI:** Fully supports both English and German interfaces.
- **Secure Data Handling:** Your credentials (License and Serial Number) are strictly used for the active session and are **never** stored permanently on your drive.

### Disclaimer
**WL-DL is an unofficial, community-driven tool.** 
This project is not affiliated with, maintained, authorized, endorsed, or sponsored by WoltLab GmbH. This tool does not bypass any licensing checks. A valid WoltLab license and account are strictly required to download restricted packages. Use this tool responsibly.

### System Requirements
- **OS:** Windows 7, 8.x, 10, or 11.
  *(Unofficial Windows XP & Vista support: The application itself runs flawlessly on these older systems. However, you will need to manually enable TLS 1.2 via OS-level workarounds, otherwise server connections will fail).*
- **Framework:** .NET Framework 2.0 (or higher).

---

## <a id="deutsch"></a>Deutsch

Ein ressourcenschonendes, natives Windows-Desktop-Tool, das es Administratoren ermöglicht, Pakete von den WoltLab Update- und Store-Servern einfach abzurufen und herunterzuladen. 
Entwickelt in C# (.NET 2.0) und optimiert für maximale Kompatibilität.

### Features
- **Benutzerfreundliche Auswahl:** Ruft die XML-Paketliste ab und lässt dich per Checkbox exakt auswählen, welche Pakete du sichern möchtest.
- **Serverfreundlich (Polite Scraping):** Enthält eine eingebaute Verzögerung (300ms) zwischen den Downloads, um die Server von WoltLab nicht zu überlasten.
- **Mehrsprachig:** Unterstützt vollständig eine deutsche und englische Benutzeroberfläche.
- **Sichere Datenverarbeitung:** Deine Zugangsdaten (Lizenz- und Seriennummer) werden nur für die aktive Sitzung verwendet und **niemals** dauerhaft auf deiner Festplatte gespeichert.

### Haftungsausschluss (Disclaimer)
**WL-DL ist ein inoffizielles Tool aus der Community.** 
Dieses Projekt ist nicht mit der WoltLab GmbH verbunden und wird von dieser weder gepflegt, autorisiert, unterstützt noch gesponsert. Dieses Tool umgeht keinerlei Lizenzprüfungen. Für das Herunterladen kostenpflichtiger Pakete sind zwingend eine gültige WoltLab-Lizenz und die entsprechenden Zugangsdaten erforderlich. Die Nutzung erfolgt auf eigene Gefahr und Verantwortung.

### Systemanforderungen
- **Betriebssystem:** Windows 7, 8.x, 10 oder 11.
  *(Hinweis zu Windows XP & Vista: Das Programm an sich funktioniert problemlos auf diesen Systemen. Allerdings ist der Support inoffiziell, da TLS 1.2 über manuelle Umwege auf Betriebssystemebene aktiviert werden muss, um eine Verbindung zu den Servern herzustellen).*
- **Framework:** .NET Framework 2.0 (oder höher).

---

## Credits
- **Creator:** [xYannikx](https://github.com/xYannikx)
- **License:** MIT License
