# WebLogin

A .NET 6 console application that uses Selenium WebDriver to silently scrape real-time photovoltaic (PV) power-generation data from a local solar-inverter web interface and display it continuously on the console.

**Source last updated:** 2023-02-25

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