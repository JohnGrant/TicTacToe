## TicTacToe: A simple game engine ##

This is a simple tic-tac-toe engine with a simple game implementation written in a few hours.

[![Build Status](https://isigma.visualstudio.com/JMG.TicTacToe/_apis/build/status/JohnGrant.TicTacToe)](https://isigma.visualstudio.com/JMG.TicTacToe/_build/latest?definitionId=1)

# Build

The engine was coded and built against the .Net Framework 4.6.1

# Assumptions

The game assumes player X always moves first. Also the consumer of the code will program against the game in such a way that spaces on the board are numbered as such:

```
    1 | 2 | 3
    ---------
    4 | 5 | 6
    ---------
    7 | 8 | 9
```

# Usage

### Initialize a Game

```
var game = new Game();
```

### Make a Move

To make a move create an instance of Move which will take the player and the position of the board.    
  
The result of the call to MakeMove will be an instance of type MoveResult. It will contain data indicating wether the move was valid for the current state of the game, a reason indicating why not in case of an invalid move, and finally the new state of the game.

```
var move = new Move(Players.X, 1);
var result = game.MakeMove(move);

Console.WriteLine(result.IsValid)       // True
Console.WriteLine(result.GameState);    // O_Move

``` 

### Invalid Move Result

When the move is invalid in the current state of the game the result tells you why.

```
var move = new Move(Players.O, 1);
var result = game.MakeMove(move);
Console.WriteLine(result.IsValid)   // False
Console.WriteLine(result.Message);  // Player X must move first.
``` 


### Game Ends

The game ends when the GameState transitions to a Draw, X_Wins, or O_Wins.  
Additional moves will generate an invalid move result.

```
IList<Move> XWinsData = new List<Move>()
	{
		new Move(Players.X, 1),
		new Move(Players.O, 7),
		new Move(Players.X, 2),
		new Move(Players.O, 8),
		new Move(Players.X, 3),
	};

MoveResult result = null;
var game = new Game();
foreach (var move in XWinsData)
	result = game.MakeMove(move);

Console.WriteLine(result.IsValid); // True
Console.WriteLine(result.GameState); // X_Wins
	
// one more additional move
result = game.MakeMove(new Move(Players.X, 1));
Console.WriteLine(result.IsValid); // False
Console.WriteLine(result.Message); // Game is over: X_Wins
	
// result is the same
Console.WriteLine(result.GameState); // X_Wins
```
