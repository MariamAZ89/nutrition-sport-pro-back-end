# 🏋️‍♂️ NutriSportPro – Backend API

**NutriSportPro** is a full-featured platform for sports coaching and nutrition tracking. It empowers users to monitor their training, nutrition, and body evolution while benefiting from personalized guidance to reach their fitness goals.

---

## 📌 Description

The backend API is built with **ASP.NET Core 9** and provides all core functionalities for the platform including authentication, training data management, nutritional planning, and integration with third-party services.

👉 **Frontend repository**: [Nutrition Sport Pro – Frontend](https://github.com/MariamAZ89/nutrition-sport-pro-front-end/)

---

## 🚀 Features

### ✅ **V1 – Basic Features**

- Authentication (JWT-based)
- Creation of sports profile (age, weight, goals, etc.)
- Workout tracking (exercises, reps, sets, duration, etc.)
- Basic nutrition recommendations

### ✅ **V2 – Advanced Features**

- Personalized training plans based on user goals
- Nutrition tracking (calories, macros)
- Statistics and progress visualization

### ✅ **V3 – Premium (Gold) Features**

- Real-time chat with certified coaches
- AI-based meal plan generation
- Integration with smartwatches (Fitbit API, Google Fit, etc.)

---

## 🧠 Architecture

![Architecture diagram](https://github.com/user-attachments/assets/ecea9934-0a71-4244-a60b-e0945cfdc92f)

---

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core Web API (.NET 9)
- **Frontend**: React JS (Vite, TypeScript, Tailwind CSS, ShadCN UI)
- **Database**: SQL Server
- **Authentication**: JWT

---

## ⚙️ Getting Started

### 🔧 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js 22+](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)

### 📦 Installation

1. **Clone the repository**

```bash
git clone https://github.com/MariamAZ89/NutriSportPro.git
cd NutriSportPro
```

2. **Restore and run the API**

```bash
dotnet restore
dotnet run
```

3. **Configure database connection**

Edit the `appsettings.json` file and replace the default connection string with your own:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=NutriSportProDb;Trusted_Connection=True;"
}
```

---

## 🗂️ Project Structure

```
src/
└── NutriSportPro.API/
    ├── Configuration/        # EF Core entity configurations (e.g., ApplicationUserConfiguration)
    ├── Controllers/          # API controllers exposing endpoints for each domain
    ├── Data/                 # Database context and data seeding
    ├── Dtos/                 # Data Transfer Objects used for data transport between layers
    ├── Enums/                # Enumerations representing fixed sets of constants
    ├── Helpers/              # Utility classes and shared helper logic
    ├── HttpRequests/         # .http files to test API endpoints manually (via IDE support)
    ├── Migrations/           # EF Core database schema migrations
    ├── Models/               # Core domain models/entities representing business data
    ├── Requests/             # Custom request models (e.g., forms, filters)
    ├── Responses/            # Standardized API response models
    ├── Ressources/           # Infrastructure components: JWT config, global exception handling, middleware
    ├── Services/             # Application services handling business logic
    ├── _globalUsings.cs      # Global using directives for simplified file-level imports
    ├── AppContainer.cs       # Dependency injection and service registration
    ├── appsettings.json      # Configuration file (DB connection string, JWT settings, etc.)
    └── Program.cs            # Main application entry point
```

---

## 🧪 API Testing

- Includes `.http` files for easy API testing via tools like [REST Client for VSCode](https://marketplace.visualstudio.com/items?itemName=humao.rest-client).

---

## ✅ Best Practices

- Clean architecture with service layers
- Separation of concerns
- Secure authentication with JWT
- API versioning and modular structure

---

## 🔗 Related Repositories

- 👉 [Frontend – React App](https://github.com/MariamAZ89/nutrition-sport-pro-front-end/)

---

## 📬 Contact

- 📧 Email: [azami.maria89@gmail.com](mailto:azami.maria89@gmail.com)
- 🐱 GitHub: [MariamAZ89](https://github.com/MariamAZ89)

---

## 💪 Ready to transform your fitness journey?

Start your personalized coaching experience with **NutriSportPro** today!
