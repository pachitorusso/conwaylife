# Conaway's Game of Life. Author Francisco Russo

.NET API 7.0 API implementation of conaways game of life (https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)

I made the asumption the board has defined widht and a height (the game originally plays in an infinite board).

## Stack
* .NET 7.0
* MongoDB

# Requirements

* .NET 7.0 SDK
* Docker

## Steps to run

* Naviage to solution's folder
* Run *`docker-compose up` to spin up MongoDB
* Run *`dotnet run --project ConwayLife` and navigate to http://localhost:5034/swagger/index.html
* Run the API using swagger UI

## List of API for the given requirements

1. Allows uploading a new board state, returns id of board
    * /Game/NextState/{id} (GET)
2. Get next state for board, returns next state
    * /Game/NextStateGivenSteps/{id}/{steps} (GET)
3. Gets x number of states away for board
    * /Game/FinalState (POST)
4. Gets final state for board. If board doesn't go to conclusion after x number of attempts, returns error
    * /Game (POST)