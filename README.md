# TestStore
Application to control an Order (basket) with 4 fixed products. 
- An order (basked) can be displayed.
- Products can be added, updated or removed from the basket.
- The total value of the order is displayed by default in USD, and can be converted and displayed in other currencies.
- All items in the basked can be displayed in a different currency independently.

## Running
Just execute the solution, and Swagger interface should show up in the browser. Feel free to use Postman instead.

## Frameworks, Packages, etc
.Net 6 WebAPI application
EntityFramework Core In-Memory Database
MediatR
AutoMapper

## Architecture
DDD + SOLID
N-Layer
CQRS
Generic Repository
Unit Testing in xUnit with Moq
Entity Validation Pattern
