# 🃏 CardGame
A multiplayer card game built using **ASP.NET Core Web API** and a **React frontend**.


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

## 🧪 Git Workflow when Dev'ing 😄

###  Check branches
``` bash
git branch
```
### Create and switch to a new branch
``` bash
git checkout -b <my-new-branch>
```
### Check file status
``` bash
git status
```
### Stage all changes
``` bash
git add .
```
### Commit changes
``` bash
git commit -m "your message here"
```
### Push to remote
``` bash
git push -u origin <my-new-branch>
```

## 📬 API Reference

### Access the Swagger UI for API exploration:
``` bash
Backend: http://localhost:5173/swagger/index.html
Frontend: http://localhost:5174/
```
