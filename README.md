# TodoApi

A simple **ASP.NET Core Web API** (REST) for managing a to-do list, built for learning purposes.  
It supports creating, reading, updating, and deleting (CRUD) tasks, with data stored in an in-memory database.  
This project is deployed and live on Render: [https://todo-notes-dbb0.onrender.com/](https://todo-notes-dbb0.onrender.com/)

## Features
- RESTful endpoints (`GET`, `POST`, `PUT`, `DELETE`)
- JSON-based responses
- In-memory database using Entity Framework Core
- Swagger UI for testing
- Live hosting on Render

## Live Demo
- **Frontend Testing UI (GitHub Pages):** `https://seizue.github.io/todoapi/`
- **Base URL:** `https://todo-notes-dbb0.onrender.com/`
- **Swagger UI:** `https://todo-notes-dbb0.onrender.com/swagger`
  ### Important Note for Frontend Testing (Free Hosting)
  The backend API is hosted on Render (free tier).
  If inactive, the API may enter sleep mode and take 30–60 seconds to restart.
  Please open the API / Base URL or Swagger link first to wake the server before testing frontend CRUD functionality.

## Local Development
To run the API locally:

1. **Clone this repository**  
   ```bash
   git clone https://github.com/seizue/todoapi.git
   cd todoapi
2. **Open a terminal in the project folder and run:**
   ```bash
   dotnet build
   dotnet run
- API Base URL: `http://localhost:5065/`
- Frontend: `http://localhost:5065/docs/index.html`
  
## Screenshot
<img width="1343" height="642" alt="msedge_otHTlF0uCA" src="https://github.com/user-attachments/assets/3f217201-4d00-4bc5-b367-e4974ac6e60d" />
