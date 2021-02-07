# MMTShop

The application consists of the following:

MMTShop -> the .NET Core application that holds the API endpoints

MMTShop.Consumer -> the Console Application that consumes the API

MMTShop.DTO -> the class library containing the DTOs

MMTShop.Interfaces -> the class library containing the interfaces

MMTShop.Models -> the class library containing the models

MMTShop.Resources -> the class library containing resources

MMTShop.Services -> the class library containing the services

MMTShop.SQL -> the class library containing the SQL files. There is a Schema.sql file which holds the database schema and commands that populate the database. There are three other .sql files, one for each stored procedure

MMTShop.Tests -> the project that contains the unit tests

The database connection string should be edited under MMTShop -> appsettings.json -> ConnectionStrings -> MMTShopConnection

The application url under MMTShop -> Properties -> lunchSettings.json -> MMTShop -> applicationUrl should remain the same because it's used by MMTShop.Consumer
