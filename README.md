# CityWeather API

## Overview
CityWeather is an ASP.NET Web API project that allows you to retrieve real-time weather information for various cities.

## How to Install and Run the Project

1. **Clone the repository**:


2. **Restore NuGet packages**:
    - Open Visual Studio.
    - Navigate to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution...**
    - Select the required packages and click **Restore**.

3. **Build the project**:
    - In Visual Studio, go to **Build** > **Rebuild Solution**.

4. **Run the project**:
    - Press **F5** or run it using **IIS Express**.

## How to Generate a New API Key
To use the weather API, you need a valid API key. If you do not have one, follow these steps to generate it:

1. Visit [WeatherAPI](https://www.weatherapi.com/) or your preferred weather API provider.
2. Sign up for an account if you do not already have one.
3. Navigate to the API keys section and generate a new API key.
4. Replace the placeholder `YOUR_API_KEY` in the project configuration or service class with the newly generated key.

## Available Endpoints
- **GET /api/weather**  
  Example: `http://localhost:5000/api/weather?city=Tel Aviv`
  
  Returns weather information in JSON format.

### Sample JSON Response
```json
{
    "Temperature_c": 25.6,
    "Temperature_f": 78.1,
    "Country": "Israel",
    "City": "Tel Aviv",
    "WindSpeed_kph": 10.5,
    "WindSpeed_mph": 6.5,
    "WindDirection": "NE"
}
```

## Troubleshooting
- If you encounter an error related to `csc.exe` or **Roslyn**, perform **Rebuild Solution**.
- Ensure that the API key is valid and correctly configured.

## Requirements
- Visual Studio 2019/2022
- .NET Framework 4.8 or later

## License
This project is licensed under the MIT License.
