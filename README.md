# 🎵 RecordShop
A full-stack .NET application simulating a digital record store. Built as a solo project during bootcamp, RecordShop showcases clean architecture, layered service design, and test-driven development principles.

## 🧰 Tech Stack
- **Backend**: ASP.NET Core Web API (`RecordShop.Api`)
- **Business Logic**: C# service layer (`RecordShop.Business`)
- **Shared Models & DTOs**: (`RecordShop.Common`)
- **Testing**: xUnit (`RecordShop.Tests`)
- **Frontend**: [RecordShopFront](https://github.com/carlhope/RecordShopFront) – Blazor


## 📦 Features

- 🎧 CRUD operations for Artists and Records
- 🔍 Search and filter functionality
- 🧪 Unit tests for repositories and services
- 🗂️ DTO mapping and separation of concerns

> 🛒 *Cart functionality is planned for a future release.*


## 🧪 Testing Strategy

Unit tests are written using **xUnit**, focusing on isolating business logic through mocked repositories and services. The goal was to ensure correctness, maintainability, and coverage of key operations across the service layer. Tests were manually authored and refined to validate expected behavior and handle edge cases with precision.


## 🚀 Getting Started
Clone the repo:

```bash
git clone https://github.com/carlhope/RecordShop.git
```
Open RecordShop.sln in preferred IDE.

Run the API project (RecordShop.Api) to launch the backend.

Use [RecordShopFront](https://github.com/carlhope/RecordShopFront)
 to interact with the frontend.
