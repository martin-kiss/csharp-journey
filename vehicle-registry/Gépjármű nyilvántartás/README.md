# Vehicle Registry

A C# console application for managing a company's vehicles and authorized users.

The application keeps track of the company, its vehicles, users, and the relationships between users and vehicles. It also demonstrates object-oriented programming concepts, constructors, properties, validation, and LINQ queries.

## Features

* Company management
* Vehicle management
* User management
* Many-to-many relationship between vehicles and users
* Vehicle mileage tracking
* Automatic calculation of VAT-inclusive rental prices
* Automatic calculation of vehicle age
* Input validation using exceptions
* LINQ queries for filtering, sorting, grouping, aggregation, and searching

## LINQ Operations

The application demonstrates several LINQ operations, including:

* Filtering vehicles by authorized users
* Filtering vehicles by daily rental price
* Sorting vehicles by manufacture year
* Finding vehicles with more than 100,000 km
* Filtering users by department
* Calculating the number of vehicles belonging to the company
* Calculating average mileage
* Finding the vehicle with the highest daily rental price
* Finding users authorized to use at least two vehicles
* Grouping users by department
* Finding vehicles available to users from a specific department
* Calculating the total VAT-inclusive daily rental price
* Checking for vehicles without authorized users
* Finding the three vehicles with the highest mileage

## Project Structure

The project contains the following main classes:

* `Company` – represents the company and its vehicles
* `Car` – represents a vehicle and its authorized users
* `User` – represents an employee who can be authorized to use vehicles
* `Program` – creates the sample data and demonstrates the application's functionality

## Technologies

* C#
* .NET 9.0
* LINQ
* Object-Oriented Programming

## Running the Project

Clone the repository and open the project in an IDE such as Visual Studio.

Build and run the project using the standard .NET tooling.

The application runs as a console application and uses sample data created in `Program.cs`.

## Date

22 September 2026
