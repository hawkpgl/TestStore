# TestStore
Over engineered application to demonstrate technical concepts, patterns, approaches, and good coding practices.

## What does it do?
Controls an Order (basket) with 4 possible products. 
- Soup – $0.65 per tin 
- Bread – $0.80 per loaf 
- Milk – $1.15 per bottle 
- Apples – $1.00 per bag 

## Actions
- An order (basked) can be displayed.
- Products can be added, updated or removed from the basket.
- The total value of the order is displayed by default in USD, and can be converted and displayed in other currencies.
- All items in the basked can be displayed in a different currency independently.

## Running
Just execute the solution, and Swagger interface should show up in the browser. Feel free to use Postman instead.

## Frameworks, Packages, etc
- .Net 6 WebAPI application
- EntityFramework Core In-Memory Database
- MediatR
- AutoMapper

## Architecture
- DDD
- SOLID
- N-Layer
- CQRS
- Generic Repository
- Unit Testing in xUnit with Moq
- Entity Validation Pattern
