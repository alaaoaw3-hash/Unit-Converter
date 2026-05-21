# 📏 Unit Converter

A modern, interactive web-based unit converter supporting length, weight, and temperature conversions. The application is built using a C# ASP.NET Core Web API backend and a clean, responsive HTML/JS/CSS frontend.

This project was built to complete the **[roadmap.sh Unit Converter Challenge](https://roadmap.sh/projects/unit-converter)**.

---

## 🚀 Features

- **Supported Conversion Types**:
  - **Length**: Millimeters (`mm`), Centimeters (`cm`), Meters (`m`), Kilometers (`km`), Inches (`in`), Feet (`ft`), Yards (`yd`), Miles (`mi`).
  - **Weight**: Milligrams (`mg`), Grams (`g`), Kilograms (`kg`), Metric Tons (`t`), Ounces (`oz`), Pounds (`lb`).
  - **Temperature**: Celsius (`°C`), Fahrenheit (`°F`), Kelvin (`K`).
- **Interactive UI**:
  - Tabbed interface to switch between unit types.
  - Custom styled dropdown select menus with smooth hover states and focus rings.
  - Dynamic display showing raw and converted units side by side.
- **Robust Validation**:
  - Backend validation preventing invalid unit conversions and negative values (except for temperatures).
  - Explicit error handling for unmatched or null parameters.

---

## 🛠️ Tech Stack

- **Backend**: C# / .NET Core (ASP.NET Core Web API)
- **Frontend**: HTML5, Vanilla JavaScript (ES6+), Tailwind CSS (for layout and utilities), Custom CSS (for styling and animations)

---

## 📁 Project Structure

```text
├── Controllers/
│   ├── ConvertingControllers.cs  # API Controller exposing the convert endpoint
│   └── utilities.cs              # Core conversion logic, helper methods, & models
├── wwwroot/                      # Static files served by ASP.NET Core
│   ├── css/
│   │   └── styles.css            # Custom CSS styles (including dropdowns & effects)
│   ├── js/
│   │   └── script.js             # Frontend conversion handling, API fetch, & tab navigation
│   └── index.html                # Main application page
├── Program.cs                    # ASP.NET Core application setup & middleware configuration
├── Unit_Converter.csproj         # Project configuration file
└── Unit_Converter.sln            # Visual Studio Solution file
```

---

## ⚙️ Getting Started

### Prerequisites

Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed (version 8.0 or later recommended).

### Running the Application

1. Open your terminal and navigate to the project directory:
   ```bash
   cd Unit_Converter
   ```

2. Run the development server:
   ```bash
   dotnet run
   ```

3. Once started, open your web browser and navigate to the URL printed in the terminal (usually `http://localhost:5000` or `http://localhost:5080`).

---

## 🌐 API Reference

### Convert a Value

* **Endpoint**: `POST /api/convertNumber`
* **Content-Type**: `application/json`

#### Request Body Example
```json
{
  "UnitType": "Length",
  "Number": 5,
  "CurrentUnit": "m",
  "TargetUnit": "cm"
}
```

#### Response Example (200 OK)
```json
500
```