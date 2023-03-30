# hexagonal-architecture-poc

Dotnet app which shows an application of the hexagonal architecture with different extern technologies. 

## Introduction

The application has two driver actors and three driven actors (excluding the tests). The application can be driven from a web application (asp.net core) and a console application. The driven side consist of three repositories namely a filesystem (json), a database (entity framework) and an in memory database implemented with an array. The application does not have recipients.  
The maincomponent sets up the configurable dependencies. The configurable dependency for the driver side is automatically instantiated at application startup using generics. The driven side configurable dependency can be changed manually. To see how see section [Instructions](#Instructions)

## Setup

In order to get the database working there is some setup required.

If you do not have the dotnet-ef tools installed, download it with the following command in the terminal:
> dotnet tool install --global dotnet-ef

Once installed run the following command in the terminal from within the project root folder:
> dotnet ef database update --project QuotesReader.Infrastructure
     
## Instructions

To switch between the different technologies on the driven side, open MainComponent.cs in the CompositionRoot project. Here you will find the following code:

![image](https://user-images.githubusercontent.com/74194913/228869881-10f27b31-8da2-4258-816b-86c4447760b3.png)

You can now change the implementation of the IObtainQuotesPort to either of the three technologies you wish. The implementations are named as follows: QuotesByFamousPeopleUsingArray, QuotesByScientistsUsingEf and QuotesByProgrammersUsingJson.

Hopefully this demo-application helps with understanding hexagonal architecture.
