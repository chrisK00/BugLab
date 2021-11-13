# BugLab
An open source bug/issue tracker with .Net 5 using Blazor WASM and Web API that can be used internally to manage different projects and see what needs to be done. It started out with only the necessary features and code in order to practice a more Agile approach and lots of refactoring.

## What this project has/makes use of
### Blazor
- Mudblazor - instead of bootstrap, let's us focus more on code and less on design/reponsivness

### API
- EF core, audit tracking, SQL server
- Authentication and Authorization using ASP identity and JWT tokens
- CQRS with MediatR - SRP and maintainability
- Mapster - a faster mapper
- Fluentvalidation - Clean validation instead of polluting models with data annotations
- Pagination 
- DTO's - models for transfering data
- Multi/N-tier architecture

### Test
- Fluentassertions - asserts with better error logs
- EFcore Test Support - creates a in memory sqlite database


## Contributions are highly appreciated!
- Open up an issue for whatever you think should be implemented and is necessary for this type of project
- Include as much information as possible in the issue, such as why this needs to be added/fixed.
- Name your branch depending on what type of issue it is, is it a feature then use feature/[issueNumber]-[title]
- Try to follow the already existing design in order to be consistent, but if you think that something could be done in a better way I would love to take a look a approach

- There are no dumb questions! feel free to message on discord ChrisK#8272

## Using the project
- The app uses a local connection string SQL server connection string so you don't have to deal with that part and the token key is just a hard coded string in appsettings. You just need to run update-database so that the database gets created
- Right click the solution and press properties, then select multiple startup projects. After that you can choose to have BugLab.Blazor and BugLab.API to start when you run the app

### Here are some things Todo:
- MediatR's request models are currently shared in order to boost dev speed but they should be refactored in to the Business layer. Id's are currently being fetched through the model due to the models being MediatR's but some will only require the id to be in the URL. You can also convert them to records instead of classes. You can have a file for each feature for example all bug commands (if they are records) can be inside a BugCommands file.
- The Blazor app is currently not making use of the built in authorize view or authorize attribute and not parsing any claims from the JWT token. We currently don't have any roles implemented so this is not a big deal
- I'm not a front-end designer and my focus is not on the design but rather functionality so feel free to improve it and accessibility
- Integration tests and more unit tests!
- Error handling mainly on the Blazor side when dealing with http requests, (the api side just needs a global exc handler)
- Using the users nav entity on the projects can be a little bit tricky due to EF does not have support for including many to many unidirectional relationships using the `.Include()`, we might want to manually create a join table and have a user prop in there, userid prop, projectId prop and then do Include().ThenInclude() (at this point we could  alt make use of reference by id and then the Project entity wont even need to directly have a list of Users/ProjectUsers). It seems to be something that is coming soon for EF6 though: https://github.com/dotnet/efcore/issues/3864 .
