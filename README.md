# SEP3
Semesteral group project in 3rd semester of my ICT course

Overview of the tiers:
Blazor client server <<GraphQL>> .NET middleware server <<HTTPS REST>> Java SpringBoot RESTful-API PostgreSQL

This system allows the employees of a fictional company to perform tasks needed to run a business such as adding cars, managing bookings and more. In addition, the web application will provide an option for the customer to completely manage the booking by himself. This system utilises a 3-tier architecture with a client server running .NET Blazor, a middleware server that hosts a .NET GraphQL server and a cloud-deployed persistence server with a Java SpringBoot-RESTful API connecting to a remote PostgreSQL database.



.NET Blazor client connected trough GraphQL to a .NET middleware server running HotChocolate(GraphQL server framework), the middleware server is connected to a Java SpringBoot RESTful API whitch has a PostgreSQL database, implemeted with Hibernate. The API is currently deployed on a Hosting platform.

the code for RestAPI is in a different repository as the deployment requires this. [CarRental-Data](https://github.com/hadamhej/CarRental-SpringBoot-REST-API)
