# 🃏 CardGame
A multiplayer card game built using **ASP.NET Core Web API** and a **React frontend**.

# Preview:
- <img width="1100" height="662" alt="image" src="https://github.com/user-attachments/assets/86855d9a-2ff5-459d-ab75-8521c7990a3b" />

- <img width="1100" height="662" alt="image" src="https://github.com/user-attachments/assets/b1cbfdfb-1174-4f9f-8a03-0173a20b5aa0" />

- <img width="1100" height="662" alt="image" src="https://github.com/user-attachments/assets/67f2639a-35cb-49cc-8665-86f91e9c79f0" />

- <img width="1100" height="662" alt="image" src="https://github.com/user-attachments/assets/f2acdcd5-0609-4a16-acb7-d19cf451c445" />

## ⚙️ Prerequisites
Make sure the following tools are installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)  
    Check version:
    ```bash
    dotnet --version
    ```

- Node.js: Check versions:
    ``` bash
    node -v
    npm -v
    ```

## 🔻 Clone the Repository

```bash
git clone git@github.com:SmithyDesigns/CardGame.git
cd CardGame
```

## 🧩 Backend Setup (ASP.NET Core)
- Navigate to the backend folder:

- Build and run the API:
    ``` bash
    cd CardGameApi
    dotnet build
    dotnet watch run
    ```

## 🔧 Apply EF Core migrations:
- Run
    ``` bash
    dotnet ef database update
    ```

## 🎨 Frontend Setup (React)
- Navigate to the frontend folder:
    ``` bash
    cd card-game-ui
    ```

- Install dependencies:
    ``` bash
    npm install
    ```

- Start the dev server:
    ``` bash
    npm run dev
    ```

## 📬 API Reference

### Access the Swagger UI for API exploration:
``` bash
Backend: http://localhost:5173/swagger/index.html
Frontend: http://localhost:5174/
```
