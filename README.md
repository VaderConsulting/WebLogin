# WebLogin

A .NET 6 console app that scrapes live PV power output from a local solar-inverter web UI via Selenium. It polls the inverter status page headlessly and prints wattage to the console each second.

**Source last updated:** 2023-08-20
**Initiated:** 2023-02-26 · **Framework:** .NET 6 · **Solution:** `WebLogin.sln`

---

## Overview

Launches a headless Google Chrome instance (via ChromeDriver) and polls a solar inverter's embedded web page every second. Navigates to the inverter's status frame, reads the current power-output element (`webdata_now_p`), and prints the live wattage to the console in a continuous loop.

---

## Features

- **Headless browser automation** - Chrome runs invisibly in the background
- **Continuous polling loop** - reads wattage once per second
- **Frame navigation** - switches to the `child_page` iframe to reach status data
- **Graceful error handling** - catches exceptions and continues polling

---

## Technology Stack

| Component | Detail |
|-----------|--------|
| Runtime | .NET 6 |
| Browser Automation | Selenium.WebDriver 4.11.0 |
| Browser Driver | ChromeDriver 116.0.x |

---

## Usage

1. Update the target URL in `Program.cs` to match the inverter's local IP
2. `dotnet run --project WebLogin`
3. Press **Ctrl+C** to stop

## Requirements

- Visual Studio 2022, .NET 6.0
- NuGet: Selenium.WebDriver 4.11.0, Selenium.WebDriver.ChromeDriver 116.0.5845.9600
- Google Chrome matching the ChromeDriver major version

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `WebLogin` (`WebLogin/WebLogin.csproj`) | C# | Console app (net6.0) | Headless Chrome poller that reads live PV wattage from the inverter status page |

## How to open

Open `WebLogin.sln` in Visual Studio 2022, restore NuGet packages, set the inverter URL in `Program.cs`, and run.

## Attribution and provenance

Working copy from my Historical Dev folder.

Working copy from my Development folder `WebLogin`.

## License

MIT © 2026 VaderConsulting for Dave Robinson's code. See `LICENSE`.
