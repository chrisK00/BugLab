# BugLab

MediatRs request models are currently shared in order to boost dev speed but they will be refactored in to the Business layer later on and most likely become records instead of classes 

## What this project has/makes use of
### Blazor
- Mudblazor - instead bootstrap, let's us focus more on code and less on design/reponsivness

### API
- EF core, audit tracking, SQL server
- Authentication and Authorization using ASP identity and JWT tokens
- CQRS with MediatR - SRP and maintainability
- Mapster - a faster mapper
- Fluentvalidation - Clean validation instead of polluting models with data annotations
- Pagination 
- DTO's - models for transfering data
- Multi tier architecture

### Test
- Fluentassertions - asserts with better error logs
- EFcore Test Support - creates a in memory sqlite database
