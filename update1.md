
## ✅ **📁 Project Setup**

### 🔷 Backend (Minimal API with EF Core + SQLite)

* ✅ Created a Minimal API project using ASP.NET Core
* ✅ Added `AppDbContext` and `User` model using Entity Framework Core
* ✅ Used SQLite as the local database (`users.db`)
* ✅ Created API endpoints for:

  * `GET /api/user` → Get all users
  * `POST /api/user` → Create a new user
  * `PUT /api/user/{id}` → Update a user
  * `DELETE /api/user/{id}` → Delete a user
* ✅ Protected API from duplicate emails (server-side validation)
* ✅ Returned `409 Conflict` for duplicate users

---

### 🔷 Frontend (Blazor WebAssembly)

* ✅ Created a Blazor WebAssembly project (`MinimalFrontend`)
* ✅ Connected Blazor to the backend API (`http://localhost:5104`)
* ✅ Updated `HttpClient` base address in `Program.cs`

```csharp
builder.Services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri("http://localhost:5104/") });
```

---

## ✅ **🧑‍💻 UI and Pages**

### 🧾 `CreateUser.razor`

* ✅ Built a form using `<EditForm>` and `InputText`
* ✅ Used `DataAnnotationsValidator` for form validation
* ✅ Created `User.cs` model in frontend for binding
* ✅ Checked for duplicate emails (client-side)
* ✅ Sent `POST` request to backend
* ✅ Handled `409 Conflict` response if email already exists
* ✅ Showed success or error messages with conditional rendering

### 📋 `UserList.razor`

* ✅ Fetched users from `GET /api/user`
* ✅ Displayed them in a table layout
* ✅ Created a nice fallback UI for loading and empty states

---

## ✅ **📦 Layout & Navigation**

### 🧭 `NavMenu.razor`

* ✅ Moved into `Layout` folder (correct place)
* ✅ Updated sidebar to include links to:

  * Home
  * Counter
  * Weather
  * ✅ Create User
  * ✅ User List
* ✅ Added custom Bootstrap icon support via embedded SVGs in CSS

### 🧱 `MainLayout.razor`

* ✅ Confirmed layout structure wraps the app correctly
* ✅ Sidebar and top bar layout working responsively

---

## ✅ **🛡️ Validation and User Experience**

* ✅ Used `[Required]`, `[EmailAddress]`, and `[Phone]` on models
* ✅ Showed feedback if form is invalid or user already exists
* ✅ Reset form after successful submission
* ✅ Used `ValidationSummary` and `alert` boxes to guide the user

---

## ✅ **(Optional but Encouraged for Future)**

| Option                          | Benefit                               |
| ------------------------------- | ------------------------------------- |
| Add toast notifications         | Better user experience                |
| Enable API logging              | Easier debugging                      |
| Add paging/sorting to user list | Better scalability for large datasets |
| Deploy to Azure                 | Make your app publicly accessible 🌐  |
| Add authentication              | Secure user data                      |

---

## 🎓 **Skills You’ve Practiced**

✅ Full-stack development
✅ Blazor WebAssembly (frontend)
✅ Minimal API with EF Core (backend)
✅ REST API design
✅ Form validation
✅ HTTP communication (GET, POST, PUT, DELETE)
✅ Client-side and server-side checks
✅ C# best practices
✅ UX principles (validation, success messages)

---

## 🏁 Final Result
