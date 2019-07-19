# The Bakery
### By Rochelle Roberts
-----

## Description
* The Bakery is a C# Console App simulating the fun of buying baked goods

## Technologies Used
* C#
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
