# Hyper-Cars
Hyper Cars is my individual project for C# MVC Frameworks - ASP.NET Core - October 2017

## General Requirements
#### Hyper Cars application should use the following technologies, frameworks and development techniques:
* Implement using ASP.NET Core framework.
* At least 8 web pages (views)
* At least 4 entity models
* At least 4 controllers
* **Use Visual Studio 2017**
* View Engine for UI - **Razor**
* Use sections and partial views, editor and display templates
* Make the front-end using JavaScript and consuming a rest service from Web API (optional)
* Database - **Microsoft SQL Server**
* Database Access - **Entity Framework Core**
* MVC Areas - areas for better code quality
* Theme - (todo)
* Responsive design - Bootstrap
* Users and Roles = ASP.NET Identity System.
* AJAX - load data async (optional)
* Unit Tests (todo)
* Error handling and data validation - Client and Server side
* Dependency Injection
* AutoМapping
* Prevent from security vulnerabilities like SQL Injection, XSS, CSRF, parameter tampering...

## Additional Requirements
#### Implement the best practices for Object Oriented design and high-quality code for the Web application:
* OOP Principles
* Data encapsulation
* Exception handling
* Well looking and easy to user UI
* Supporting of all modern Web browsers
* Use caching where appropriate
* Source control - **Github**

## Database Structure And Logic
### Tables and relations:

#### Cars:
* Id, Model, Price, BodyType, Travelled Distance, Type Of Transmission, Year Of Production, Horse Power, Color
#### Parts:
* Id, Name, Price, Condition, Model
#### Customers:
* Default ASP.NET Identity System Modified
#### Relations
* A customer can buy many cars and many parts. One car can be bought by one customer so does the parts.

## Business Logic of the application
### Three types of users:
* Anonymous (not registered and not logged in user)
* Logged in users
* Administrator

### Anonymous users are able to
* Register
* Login
* View Cars
* View Parts

### Logged in users are able to
* Create car for sale (Full CRUD on it)
* Create part for sale (Full CRUD on it)
* Buy car
* Buy part

### Administrators are able to
* See Admin panel - Create users

### Deadline
* Project should be completed before 22 December 2017
