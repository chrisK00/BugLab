# BugLab
A bug/issue tracker with .Net 5 using Blazor WASM and Web API that can be used internally to manage different projects and see what needs to be done. It started out with only the necessary features and code in order to practice a more Agile approach and lots of refactoring. The app will be published later on

### Images
Login page [![msedge-Dx-Gv-K0-Kr2w.png](https://i.postimg.cc/8zNjRhGL/msedge-Dx-Gv-K0-Kr2w.png)](https://postimg.cc/GHgLrTHp)

My projects page [![myprojects.png](https://i.postimg.cc/rs5YyxZw/myprojects.png)](https://postimg.cc/zHXk0b1s)

My Bugs page [![mybugs.png](https://i.postimg.cc/FFS6xXFX/mybugs.png)](https://postimg.cc/yWVnV5SL)

Add bug to project [![addbug.png](https://i.postimg.cc/fThr2qkt/addbug.png)](https://postimg.cc/6TYcT0rt)

Give a user access to a project [![msedge-s-Rxd-ELn30-T.png](https://i.postimg.cc/MHBmQySh/msedge-s-Rxd-ELn30-T.png)](https://postimg.cc/bSznXSdT)

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
- Background services

### Test
- Fluentassertions - asserts with better error logs
- EFcore Test Support - creates a in memory sqlite database
- Moq for focused tests

## Contributions are highly appreciated!
- Open up an issue for whatever you think should be implemented and is necessary for this type of project
- Include as much information as possible in the issue, such as why this needs to be added/fixed.
- Name your branch depending on what type of issue it is, is it a feature then use feature/[issueNumber]-[title]
- Try to follow the already existing design in order to be consistent, but if you think that something could be done in a better way I would love to take a look at that approach

- There are no dumb questions! feel free to message on discord ChrisK#8272

## Using the project
- The app uses a local connection string SQL server connection string so you don't have to deal with that part and the token key is just a hard coded string in appsettings. You just need to run update-database so that the database gets created
- Right click the solution and press properties, then select multiple startup projects. After that you can choose to have BugLab.Blazor and BugLab.API to start when you run the app

### Here are some things Todo:
- You could refactor the commands/queries to become records instead, then you would have a Commands folder, with feature by folder, then a file with all the Commands for that feature and your handler files: Commands/Bugs/ in this folder we can find BugCommands.cs, AddBugHandler, DeleteBugHandler etc.... If you do this then you need to create a PaginationParams record we can inherit from, I normally choose composition over inheritence but in this app we wont inherit from something else and it's more convenient to do request.PageNumber over request.PaginationParams.PageNumber.
- The Blazor app is currently not making use of the built in authorize view or authorize attribute and not parsing any claims from the JWT token. We currently don't have any roles implemented so this is not a big deal
- I'm not a front-end designer and my focus is not on the design but rather functionality so feel free to improve it and accessibility
- Integration tests and more unit tests!
- Attachments (f.e image, gif)
- Home page can have a dashboard
- Color property on bugtypes
- Background service that sends a weekly stats mail regarding for example the project with most completed bugs, the project with most high prioritized bugs, how many bugs you have completed
- Error handling mainly on the Blazor side when dealing with http requests (global http request interceptor), (the api side also needs a global exc handler)
- Using the users nav entity on the projects can be a little bit tricky due to EF does not have support for including many to many unidirectional relationships using the `.Include()`, I could not find many code benefits with manually creating a join table and have a user prop in there, userid prop, projectId prop and then do Include().ThenInclude() (alt make use of reference by id and then the Project entity wont even need to directly have a list of Users/ProjectUsers). It seems to be something that is coming soon for EF6 though: https://github.com/dotnet/efcore/issues/3864 . This issue will require a lot of refactoring existing code but if you would like to give it a try and convince me that it improves the app code significally (I'm aware of it having a little readability improvment and that there is a performance boost because we don't have to do a join but at the same time it requires more code, management and performance is not an issue right now), here are some things you'll need for the first alternative: 

`Add a ProjectUser class with ProjectId, UserId and User.`

`Configure the relationship for UserEntityConfig:  builder.HasMany<ProjectUser>()
                .WithOne()
                .HasForeignKey(x => x.UserId);`

`Configure the ProjectEntityConfig  builder.HasMany(x => x.ProjectUsers)
                .WithOne();`

`Configure ProjectUser entity config builder.HasKey(x => new { x.ProjectId, x.UserId });`

`Call .Include() and .ThenInclude() where project are being referenced but replace them with _context.ProjectUsers where possible in order to prevent unnecessary items loaded`



