Logging
-------
Used ILogger and Nlog to log information and errors. More detailed logging can be achieved.


Exception or Error Handling
---------------------------
Used .Net Core Middleware to configure global exception handling.
Created ExceptionMiddlewareExtensions file and ErrorDetails model under Extensions folder for global exception handling.


Dependency Injection
--------------------
Used .Net Core default dependency injection.Used Constructor Injection in the Project.


DTO(Data Transfer Objects)
--------------------------
Used DTO to create external interface for the API and mapped it using AutoMapper package.


Unit Testing
------------

Used MSTests for Unit Testing.
Created unit tests for business logic files in the Data and Controllers folder.
Used MoQ framework to mock objects for unit testing.



Utilities
--------
The path for the API file is referred from the appSettings.json file.
Created a code file AppSettings.cs to retrieve the path from appSettings.json config file.
Created file operations for reading and writing data(The read and write can be made better-like using IDisposables etc)


POSTMAN
-------
Used Postman tool for testing the API manually.


Improvement Areas: 
-----------------

More unit tests can be added. 
The entire read and update operations can be made asynchronous using Async and Await Keywords. 
File Operations area can be made Disposable using IDisposable or Using Statement.
Ocelot API Gateway integration can be done(Microservices architecture for more than one API's)

