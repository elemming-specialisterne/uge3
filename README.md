# Uge 3 API

Simple API to Create/Update/Read/Delete cereals.

## Description

An in-depth paragraph about your project and overview of use.

## Getting Started

### Dependencies

* Needs C#
* Needs an MySql database to run
* Set default connectionSting in ```CerealAPI\appsettings.Development.json``` or ```CerealAPI\appsettings.json```

### Installing

* Needs nuget packages in ```CerealAPI\CerealAPI.csproj```

### Executing program

* First setup the tables with ```dotnet ef database update```
* Then you can seed the Database with data from ```Data\Cereal.csv```  by calling ```dotnet run seeddata```
* Calling ```dotnet run``` should startup the api
* If the program is build in "development mode" then you can go to ```[default connectionSting]/Swagger/index.html```

## Authors

Contributors names and contact info

ex. Emil Lemming

## Version History

* 0.1
    * Initial Release

## Acknowledgments

* Specialisterne
* [Teddy smith](https://www.youtube.com/watch?v=_8nLSsK5NDo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0)