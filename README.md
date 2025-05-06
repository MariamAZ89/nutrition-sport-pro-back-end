
# 🏋️‍♂️ Application NutriSportPro

## 📌 Decsription

The Sports Coaching and Nutrition application is a platform that allows users to track their training sessions and diet while receiving personalised advice. The aim is to help users achieve their fitness goals through detailed monitoring and tailored recommendations.

## 🚀 Features

### **V1 - Basic functions**

✅ User registration and login (JWT Auth)

✅ Create a sports profile (age, weight, goals, etc.)

✅ Tracking training (exercises, repetitions, weight, duration, etc.)

✅ Basic dietary recommendations

### **V2 - Advanced functionalities**

✅ Personalised training plans based on objectives

✅ Calorie and macro tracking via a nutritional database

✅ Statistics on changes in performance and body composition

### **V3 - Premium features (Gold)**

✅ Real-time chat with certified coaches

✅ Automatic generation of suitable food programmes

✅ Integration with connected watches (Fitbit API / Google Fit , AI)

---

## 🛠️ technologies used 

- **Back End** : ASP.NET Core Web API / Minimal API
- **Fron End** : React JS / ASP.NET Core MVC
- **Database** : PostgresSQL / SQL Server / MySQL
- **Auth** : JWT / OAuth (Google , Facebook)
- **Storage**: Azure Blob Storage / Firebase
- **API integrations** : OpenFoodFacts API (nutritional follow-up), Google Fit API (activity monitoring)

---

## 🎯 Installation and Configuration

### **Prerequisites**

- .NET 9 SDK
- Node.js (22+)
- PostgreSQL
- Firebase account (optional for file storage)

### **Installation steps**

1. **Clone the project**
   ```sh
   git clone http://github.com/[My-repo]/coaching-app.git
   cd coaching-app
   ```
2. **Backend**
   - Go to the folder `backend/`
   - Installing dependencies :
   ```sh
   dotnet restore
   ```
   - Modification of the connection string (database: default) `appsetting.json`
   - Launch API
   ```sh
   dotnet run
   ```
3. **Fronend**
   - Go to the folder `fronend/`
   - Installing dependencies :
   ```sh
   npm install
   ```
   - Modification of the API URL (backend : `coachingApi`) `.env`
   - Launch the application
   ```sh
   npm run dev
   ```

---

## 📂 Project structure

```
coaching-app/
|──backend/
   |── Controllers/
   |── Models/
   |── Services/
   |── Data/
   |── Program.cs
|──frontend/
   |── components/
   |── pages/
   |── styles/
   |── App.js
|──docs/
   |── Api_Documentation.md
|── README.md
```

---

## ✅ Best practice

- **Clean, well-structured code 🛠️**
- **API documentation with Postman 📖**
- **CI/CD for automatic deployment 🚀**

---

## 📬 Contact

📧 Email : `email`

🐱 GitHub : `Url`

🚀 **Ready to transform your fitness with our application?** 💪

