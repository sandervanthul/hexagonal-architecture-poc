# hexagonal-architecture-poc

Dotnet app which shows an application of the hexagonal architecture with different extern technologies. 

The driver side has two different technologies namely a console app and a web app (asp.net core). The driven side uses three different repositories namely a filesystem (json), a database (entity framework) and an in memory database implemented with an array. The maincomponent sets up the configurable dependencies. The configurable dependency for the driver side are automatically instantiated at application startup using generics. The driven side configurable dependency can be changed manually.

To switch between the different technologies on the driven side, open MainComponent.cs in the CompositionRoot project. Here you will find the following code:

![image](https://user-images.githubusercontent.com/74194913/228869881-10f27b31-8da2-4258-816b-86c4447760b3.png)

You can now change the implementation of the IObtainQuotesPort to either of the three technologies you wish. The implementations are named as follows: QuotesByFamousPeopleUsingArray, QuotesByScientistsUsingEf and QuotesByProgrammersUsingJson.

Hopefully this demo application helps with understanding hexagonal architecture.
