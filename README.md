# hexagonal-architecture-poc

Dotnet app which shows an application of the hexagonal architecture with different extern technologies. 

## Introduction

The driver side has two different technologies namely a console app and a web app (asp.net core). The driven side uses three different repositories namely a filesystem (json), a database (entity framework) and an in memory database implemented with an array. The maincomponent sets up the configurable dependencies. The configurable dependency for the driver side are automatically instantiated at application startup using generics. The driven side configurable dependency can be changed manually.

## Setup

In order to get the database working there is some setup required. The only setup required is the Environment Variables.

### Visual Studio
1. Right click on the QuotesReader.Infrastructure.Console project and click 'properties'.
2. Click on debug.
3. Under general click on 'Open debug launch profiles ui'
4. Scroll down to Environment variables and enter the following text:
- under Name enter: 
    > SQL_SERVER_CONNECTION_STRING
- under Value enter: 
    > Server=(localdb)\mssqllocaldb;Database=Quotes
     
It should look like this

![image](https://user-images.githubusercontent.com/74194913/228912653-41520235-bcb4-4bcc-9844-df4f7b75c3fd.png)


### Rider
1. Click on 'Run' in the top right navigation bar and click on 'Edit Configurations'.
2. Click on .NET Project -> QuotesReader.Infrastructure.Console
3. On the right in the Environment variables bar, click on the icon:
![image](https://user-images.githubusercontent.com/74194913/228917675-884870bb-accc-4cee-8f75-a537a01fcc9e.png)  
4. Click on the + symbol and enter the following text:
- under Name enter: 
    > SQL_SERVER_CONNECTION_STRING
- under Value enter: 
    > Server=(localdb)\mssqllocaldb;Database=Quotes
 
It should look like this  
![image](https://user-images.githubusercontent.com/74194913/228918609-88a08878-f853-431b-95dc-15873cb338ad.png)   
5. Click OK then Apply and OK.
     
## Instructions

To switch between the different technologies on the driven side, open MainComponent.cs in the CompositionRoot project. Here you will find the following code:

![image](https://user-images.githubusercontent.com/74194913/228869881-10f27b31-8da2-4258-816b-86c4447760b3.png)

You can now change the implementation of the IObtainQuotesPort to either of the three technologies you wish. The implementations are named as follows: QuotesByFamousPeopleUsingArray, QuotesByScientistsUsingEf and QuotesByProgrammersUsingJson.

Hopefully this demo application helps with understanding hexagonal architecture.
