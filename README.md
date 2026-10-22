# Ebox Email Marketing Tool

A web app for small businesses to run Gmail-based email campaigns: import a contact list, personalise and send bulk emails from your own Gmail account, then track replies and send follow-ups. I built it as the product behind **Ebox Marketing Solutions**.

**Stack:** ASP.NET Web Forms (VB.NET) · SQL Server · Gmail SMTP with OAuth 2.0 (XOAUTH2) · Telerik RadGrid · Bootstrap

## Features

- **Gmail sign-in with OAuth 2.0.** Users link their own Gmail account and the app sends through it with XOAUTH2, so mail comes from the user's real address.
- **Contact import** from CSV, with a downloadable template and daily import limits per plan.
- **Bulk sending** to selected contacts, with a custom sender name, an optional company address, CC/BCC, attachments and inline images (with type and 20 MB size checks).
- **Templates:** default templates, plus saving, editing and reusing your own; HTML signatures with links.
- **Campaign tracking:** separate grids for unsent, sent and followed-up emails, with search, select-all, sent and follow-up dates, and CSV export or print for each.
- **Follow-ups** to contacts who were already emailed, with a monthly follow-up quota.
- **Accounts and plans:** registration with email activation, login (including Google sign-in), password reset with a verification code, a user dashboard and subscription limits.
- **Demo mode** with demo credentials, so visitors can try the tool before signing up.

## Run it locally

1. Open the folder as a **website** in Visual Studio (ASP.NET Web Forms, .NET Framework 4.x).
2. Restore NuGet packages from `packages.config`.
3. Add the two commercial components (not included in this repo): **EASendMail** (SMTP library; `SmtpMail("TryIt")` uses its trial licence) and **Telerik UI for ASP.NET AJAX** (`RadGrid`).
4. Copy `Web.config.example` to `Web.config` and fill in:
   - `SmtpUser` / `SmtpPassword`: the account the app sends system emails from. For Gmail, use an [app password](https://support.google.com/accounts/answer/185833).
   - `GoogleClientId` / `GoogleClientSecret`: an OAuth client from Google Cloud Console.
   - The SQL Server connection strings.

`Web.config`, credentials and uploaded user files are git-ignored.

## Notes

- The landing page design is based on a free MIT-licensed Bootstrap theme by Blackrock Digital LLC (Start Bootstrap); see [LICENSE](LICENSE). Font Awesome is used for icons.
- The payment page contains placeholder merchant details. A real deployment needs your own gateway credentials.
