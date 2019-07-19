# The Bakery
### By Rochelle Roberts, Software Engineer
-----

## Description
* The Bakery is a C# Console App simulating the fun of buying baked goods

## Technologies Used
* C#
* .NET
* MSTest

## Installation
* Clone project repo
* From the project's root directory, open console and type dotnet run

```sh
$ git clone https://github.com/rochellev/TheBakery.git
$ cd TheBakery
$ cd Bakery
$ dotnet restore
$ dotnet run
```

## Specs

| Behaviors       | Input          | Output      |
| ---------------- |:------------:| :--------------:|
| Start program | dotnet run | welcome message |
| See prices |  User responds "yes" to see menu | Program prints out available items and prices |
| User can purchase items | User type menu item and quantity | 
Cost for those items added to total |
| User can complete order | user types "checkout" | Total printed |
| Buy 2 Bread get 1 Bread free | user buys 2 Breads | 1 bread added for free |
| Buy 3 Pastries at discount | user buys 3 Pastries | Discount applied |



## Project Directory
1. Model Directory
    * contains project's .cs files 
    * this is where your classes go
2. Project.csproj
    * things needed to install 
    * dotnet restore -- will install dependencies

## Project.Tests Directory
1. ModelTests Directory
    * your tests will be here
2. Project.Tests.csproj
    * make sure update the ProjectReference !
    * run dotnet restore to install the dependencies
