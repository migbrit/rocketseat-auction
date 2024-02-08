# Rocketseat Auction Project
## Auction API
This is a project developed during Rocketseat's Next Level Week (NLW) event, using the .NET stack.

## Project Summary
The project consists of an API for managing auctions, where entities such as Item, Offer, Auction, and User were created. UseCases, interfaces, repositories, dependency injection, and Entity Framework Core were implemented. Additionally, a simple authentication using fake base64 tokens was implemented. Unit tests were written using xUnit, Moq, and Bogus.

## Requirements
Installed .NET SDK
Configured .NET development environment
## How to Run the API
Clone this repository to your local environment.
Navigate to the project directory.
Open the terminal or command prompt in the project root.
Run the command dotnet run to start the API.
The API will be available at http://localhost:5000.

## Authentication
Authentication is done via fake base64 tokens. Include the token in the request header with the key Authorization.

## Unit Tests
Unit tests can be found in the /tests directory. They were written using xUnit, Moq, and Bogus. To run them, navigate to the test directory and execute dotnet test.

## Contribution
Contributions are welcome! Feel free to open an issue or submit a pull request.

## License
This project is licensed under the MIT License.
