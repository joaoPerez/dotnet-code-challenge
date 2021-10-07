# Pragmateam code challenge (.NET)

Please refer to the provided document for the code challenge requirements.

## Framework & languages
This project uses
* .Net Core 5.0 / C#
## Available scripts

### Root
- `dotnet run` - Start the server on (http://localhost:5000)

### Modifications made

- Changed architecture to DDD approach.
- Creation of interfaces and repository pattern, with dependecy injection and inversion.

* This modifications were made to make possible to test the application.

- The other modifications I could do is change the BeerModel source to another service, a Json, something to simulate an entry.
- Some filed could be change to constants or dictionary, depending on business rules and technical things, suchs as if is expected a database in the future.
- All models could be tranformed to rich domain entities.
- I also would like to do more verifications in order to test Exceptions.
- A important thing to change in this case is the separation between client and server (React and .Net) on two different projects.