# 🧪 MatchingEngineAutomation

This project is an automated UI testing suite for [MatchingEngine.com](https://www.matchingengine.com/), focused specifically on the **Repertoire Management Module**.

---

## 📌 Project Objective

To automatically verify the visibility and accuracy of supported products listed under the *Repertoire Management Module* on MatchingEngine’s official website.

---

## 🧱 Folder Structure

MatchingEngineAutomation

├── Drivers  (Chrome WebDriver initialization)

├── PageObjects (Page Object Models (elements + actions) )

├── Tests (NUnit test classes)

├── Utilities  (Reusable assertions and wait helpers)

├── TestResults  (Test result output (ignored in .gitignore) )

├── TestReports  (Code coverage HTML reports (ignored in .gitignore) )

├── test.runsettings  (Code coverage configuration)

├── MatchingEngineAutomation.csproj

├── README.md  (Project documentation)


---

## 🧪 Test Scenario Automated

1. Navigate to [https://www.matchingengine.com](https://www.matchingengine.com)
2. Expand **Modules** in the header
3. Click on **Repertoire Management Module**
4. Scroll to the **Additional Features** section
5. Click on **Products Supported**
6. Assert the visibility of the heading:  
   *There are several types of Product Supported:*
7. Validate the presence of:
   - Albums
   - Singles
   - Streaming Content
   - Digital Downloads
   - Ringtones

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET 9
- **Test Framework:** NUnit
- **Browser Automation:** Selenium WebDriver (Chrome)
- **Reporting:** ReportGenerator (HTML Code Coverage)
- **Design Pattern:** Page Object Model (POM)

---

## 🚀 How to Run the Tests

# Restore packages
dotnet restore

# Build the project
dotnet build

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage" --settings test.runsettings

## Generate HTML Coverage Report

reportgenerator -reports:"TestResults\**\coverage.cobertura.xml" -targetdir:"TestReports" -reporttypes:Html

Then open:
TestReports/index.html

## NuGet Packages Used

1. Selenium.WebDriver
2. Selenium.WebDriver.ChromeDriver
3. DotNetSeleniumExtras.WaitHelpers
4. NUnit, NUnit3TestAdapter, Microsoft.NET.Test.Sdk
5. coverlet.collector (for code coverage)

## Git Ignore Highlights

Compiled files (bin/, obj/)

Test outputs (TestResults/, TestReports/)

Editor configs and system files

