# Productify

Productify is a project built using .NET 8 that follows the Onion Architecture pattern. It consists of four projects: Productify.Models, Productify.Repo, Productify.Service, and Productify.API. These projects are organized to maintain a separation of concerns and promote modularity and scalability.

## Projects

### 1. Productify.Models

This project contains all the database model classes used in the application. These classes represent the entities in our domain model.

### 2. Productify.Repo

Productify.Repo contains the database context and repository classes responsible for data access. It provides a layer of abstraction over the database operations and implements generic methods for CRUD operations.

### 3. Productify.Service

Productify.Service contains the business logic and implementations for various operations in the application. It utilizes the repository pattern from Productify.Repo to interact with the database.

### 4. Productify.API

Productify.API is an ASP.NET Web API project that serves as the entry point for the application. It exposes endpoints to perform CRUD operations and other functionalities. This project interacts with Productify.Service to execute business logic.

## Installation

To run the Productify project locally, follow these steps:

1. Clone the repository to your local machine:

