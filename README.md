###### Assignment #2
## Lets play

### Goals:
After the second workshop, where you attempted implementing a project with MVC for the first time, the goals of this assignment are:
1) To allow you to correct mistakes and implement feedback from the workshop, enhancing your proficiency with MVC.
2) To integrate your previous knowledge of software design and the MVC/MVP patterns into a more complex project, requiring careful selection of design patterns and methods.
   
### Overview:
This assignment builds on the second workshop and is, in fact, an extended version of it. We will be developing a more complex game—Reversi—with additional requirements. You are encouraged to reuse and modify your workshop code. Keep the following in mind:

1) Pay close attention to the comments and suggestions from the workshop feedback. If you encountered issues with the Model-View connection, focus on implementing that part correctly this time. If your feedback included points about adhering to the Single Responsibility Principle for your models, make sure those areas are revised as well.

2) In real-world projects, MVC is often just one of many patterns used within larger, more complex applications. It’s rare to end up with only three projects (Model, View, Controller). You’ll need to apply the principles of SOLID to further decompose your code, ensuring it remains extensible and adaptable. Ask yourself key design questions: What are the high-level and low-level policies? Which parts of the code could be extended or replaced? For example, perhaps the AI logic should be moved to a separate project with a defined relationship to the model.

### Task
1. Implement a [Reversi](https://en.wikipedia.org/wiki/Reversi) game playable through the command-line interface (CLI). There are lot of places on the internet where you can try playing reversi, e.g. [here](https://cardgames.io/reversi/) or [here](https://www.crazygames.com/game/reversi-online)
2. You can use MVC or MVP pattern to handle user interface.
3. The game should adhere to the rules of Reversi, also known as Othello.
4. Players should be able to make moves by inputting coordinates for their desired move.
5. The game must support: a) player vs. player (PvP) mode, b) player vs. *simple* bot (PvE) mode, where bot makes random allowed move
6. In order to demonstrate possibilities of MVC\MVP pattern, you need to implement two different views for a game - a simple one, and extended one with possibility for a user to switch between them during the game.
7. User must be able to start a new game after completing previous without restarting an app.
8. To simulate real-world interaction, in PvE mode little random delay (from 3 to 5 seconds) must be applied after player's move before bots move
9. In PvE mode, active player can undo one move during 3 seconds after making it.
10. Move duration must be limited to 20 seconds. Random move must be performed if user failed to make a move during this time.
11. Player can ask for a hint and get all possible moves highlighted.
12. User can ask for his statistics about gaming (includng previous sessions): total games played by time, statistics of results with different bots (wins-loses-draw).
13. Include  unit tests to validate the functionality of the game components.  Unit tests should cover critical aspects such as move validation, game state transitions, and edge cases.

You can get +1 point if you implement Hard bot - third option, where bot chooses a move that maximizes its' points.

### Simple view

```
Reversi Game - Simple View
--------------------------
A B C D E F G H
1 . . . . . . . .
2 . . . X O . . .
3 . . X O X . . .
4 . X O O X . . .
5 . . X O X . . .
6 . . . X O . . .
7 . . . . . . . .
8 . . . . . . . .

Available commands:
- move [coordinate] (e.g., D4)
- hint
- undo
- quit
```

### Enhanced view

```
Reversi - Interactive CLI View
────────────────────────────────────────────
Player X (You) vs Hard Bot (O)

    A   B   C   D   E   F   G   H
  ┌───┬───┬───┬───┬───┬───┬───┬───┐
1 │   │   │   │   │   │   │   │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
2 │   │   │   │ X │ O │   │   │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
3 │   │   │ X │ O │ X │   │   │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
4 │   │ X │ O │ O │ X │   │   │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
5 │   │   │ X │ O │ X │   │ * │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
6 │   │   │   │ X │ O │   │ * │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
7 │   │   │   │ * │ * │ * │   │   │
  ├───┼───┼───┼───┼───┼───┼───┼───┤
8 │   │   │   │   │   │   │   │   │
  └───┴───┴───┴───┴───┴───┴───┴───┘

Player X, your move! (D4)

Hint: Possible moves are marked with *
```

### Grading policy
Maximum points: 8
- 3 points - basic game logic with 2 views and ability to win and lose in PvP, restart;
- 1 point - PvE modes
- 2 point - hints and undos
- 1 point - time limits and statistics
- 1 point - unit tests
- +1 extra point for Hard bot mode
  

### Extra Learning materials
At first, rewatch a lecture on Moodle and process carefully TicTacToe example. Be careful - there is a lot of confusing materials about MVC on the internet, I recommend to start with original [explanation by Martin Fowler](https://martinfowler.com/eaaDev/uiArchs.html), author of Refactoring book and a short video fragment from [Robert Martin talk](https://youtu.be/Nsjsiz2A9mg?si=CobGPXOk6evh2wEr&t=1893) on a conference.

After this you can read other materials on the internet but be aware that you can find a lot of wrong arrows and ideas.

