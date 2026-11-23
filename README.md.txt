# Library Management Console App

A console-based library management application built with C# to practice Object-Oriented Programming (OOP) principles.

## About the Project

This project simulates a simple library management system. It allows users to manage books and members, borrow and return books, and search for library items.

## Features

- Add books to the library
- Register library members
- Borrow books
- Return borrowed books
- Display all library items
- Display registered members
- Search for books by ID
- Search for books by title
- Display borrowed books for each member
- Handle errors using built-in and custom exceptions

## OOP Concepts

This project demonstrates the following concepts:

- **Encapsulation:** Protecting internal data using private fields and controlled access.
- **Inheritance:** Using an abstract base class for library items.
- **Abstraction:** Defining common behavior through abstract classes and interfaces.
- **Polymorphism:** Implementing different behaviors through method overriding.
- **Interfaces:** Using `IBorrowable` to define borrowing behavior.
- **Exception Handling:** Managing errors using try-catch and custom exceptions.

## Main Classes

- `Library`: Manages library items and members.
- `LibraryItem`: Abstract base class for library items.
- `Book`: Represents a book.
- `Member`: Represents a library member.
- `IBorrowable`: Defines borrowing and returning behavior.
- `Program`: Contains the console application entry point.

## Technologies

- C#
- .NET
- Object-Oriented Programming

## How to Run

1. Install the .NET SDK.
2. Clone or download this repository.
3. Open a terminal in the folder containing the project `.csproj` file.
4. Run:

```bash
dotnet restore
dotnet run
```

## Current Limitations

- Data is stored in memory.
- Data is lost when the application closes.
- The application uses a console-based interface.
- No database persistence is implemented.

## Learning Goals

The main goal of this project is to strengthen C# programming skills and understand practical OOP concepts through a real-world example.

---

**Author:** Your Name