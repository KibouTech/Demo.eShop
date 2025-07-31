# Asynchronous Programming

Learn: https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/

| **Platform / Framework** | **Has Sync Context?** | **UI Thread?** | **ConfigureAwait(false) Safe?** | **Notes**                                |
| ------------------------ | --------------------- | -------------- | ------------------------------- | ---------------------------------------- |
| WPF / WinForms           | ✅ Yes                 | ✅ Yes          | ❌ Risky                         | UI must resume on main thread.           |
| ASP.NET Core             | ❌ No                  | ❌ No           | ✅ Yes                           | No sync context; improves performance.   |
| Blazor Server            | ✅ Yes (custom)        | ✅ Yes          | ⚠️ Risky                        | Uses logical UI context over SignalR.    |
| Blazor WebAssembly       | ❌ No                  | ✅ Yes          | ✅ Safe                          | No .NET sync context; runs on JS thread. |
| Xamarin / MAUI           | ✅ Yes                 | ✅ Yes          | ⚠️ Risky                        | UI thread must be preserved.             |
| Console App (.NET Core)  | ❌ No                  | ❌ No           | ✅ Yes                           | No context to capture.                   |
| Unit Test Projects       | ❌ No (usually)        | ❌ No           | ❌ Not needed                    | Test runners don’t install sync context. |
