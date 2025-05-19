# FriendsNetwork

This project built in .NET using C# implements Clean Architecture or Onion Architecture. This way implementing new functionality, finding bugs, or integrating a whatever software such as WebService, WebSocket, WebSite... is way easier than it used to be. I just wanted to give it a try and learn how it works to implement it in my upcoming projects.

---

# Database setup

The PostgreSQL repository points to the database configured in the appsettings.json in the Program.cs in the integration layer.
I mounted the database with a docker container (I dont want to install pgadmin) to keep things simple.

``` bash
docker pull bitnami/postgresql
docker run -p 5432:5432 -e POSTGRESQL_PASSWORD=s --name postgresql bitnami/postgresql:latest
```

Before running the project, we need to create the database with the following commands:

``` bash
dotnet ef migrations add InitialCreate --project FriendsNetwork.PostgreSQLRepository --startup-project FriendsNetwork.Api/FriendsNetwork.Api
dotnet ef database update --project FriendsNetwork.PostgreSQLRepository --startup-project FriendsNetwork.Api\FriendsNetwork.Api
```

# Run project

With dotnet (sdk 8) CLI, you can run the project with this simple instructions:

``` bash
cd FriendsNetwork.API\
dotnet clean
dotnet restore
dotnet run
```

In this case, what im doing is navigating to the API that integrates the business logic from the Clean Architecture, and running its Program.cs.




