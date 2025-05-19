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




