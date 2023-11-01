# Authenticator_project
Role based authorization in .NET 7 Using CQRs, MediatR, Serilog, Sqlite, AutoMapper, Jwt

## Overview

The Authenticator Project is a web API built with ASP.NET Core, providing authentication and authorization features. It implements the CQRS (Command Query Responsibility Segregation) and Mediator pattern to segregate read and write operations. The application uses an in-app SQLite database for data storage and employs Serilog for logging and AutoMapper for object mapping.

## Features

- **User Authentication and Authorization:** Authenticate users and control access based on their roles (FrontOffice, BackOffice, Admin) using JWT (JSON Web Tokens).
- **CQRS and Mediator Pattern:** Efficiently handle commands and queries by separating read and write operations.
- **Secure Password Storage:** Store user passwords securely using ASP.NET Core Identity's built-in password hashing and storage mechanisms.
- **SQLite In-App Database:** Utilize SQLite as the in-app database for efficient data storage.
- **Logging with Serilog:** Keep track of application events and errors using the Serilog logging library.
- **Object Mapping with AutoMapper:** Easily transform data between different models using AutoMapper.

## Getting Started

### Prerequisites

Before running the project locally, ensure you have the following:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) (or later version)
- SQLite


### How to get authorized
put the bearer text before the token. Just as this;

![Screenshot (57)](https://github.com/donkennie/Authenticator_project/assets/88739172/8055385e-ad86-4f67-8539-affff9b90dff)



Logging
The application uses Serilog for logging, and logs are written to the logs folder in the project directory. Customize Serilog settings in the appsettings.json file.
