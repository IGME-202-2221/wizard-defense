# Project Wizard Defense

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Zach Etienne
-   Section: either 5 or 6

## Game Design

-   Camera Orientation: _Top-Down_
-   Camera Movement: _The camera doesn't move, only the players and the enemy do_
-   Player Health: _50 health_
-   End Condition: _Randomly selected enemies will come endlessly, and they will become faster and stringer as you destroy more of them._
-   Scoring: _Different enemy types will give different point values, from 50 points for the most basic enemy to 100 for a special enemy_

### Game Description

You are a lightning wizard, and you must hold back the corruption that seeks to destroy your castle and the rest of your hometown.

### Controls

-   Movement
    -   Up: _W/Up Arrow_
    -   Down: _S/Down Arrow_
    -   Left: _A/Left Arrow_
    -   Right: _D/Right Arrow_
-   Fire: _Left Click_

## You Additions

-   Castle Integrity
    -   You must defend your castle from the corrputed enemies. If they reach your castle, it will take damage. You lose if it is destroyed.
-   3 different enemy types:
    -   _Blob:_  fires slow-moving small projectiles, starts wiht 20 health, 50 pts when destroyed (the player does 6 damage with their bolt for reference)
    -   _Gunner:_ fires twice as fast but moves half as fast as the blob, starts with 25 health, 100 pts when destroyed
    -   _Beetle:_ doesn't shoot but moves quickly toward your castle, starts with 10 health, 100 pts when destroyed
-   Accuracy, health, and integrity Bonuses to score once you die or your castle is destroyed (this means that you cannot get an integrity bonus and a health bonus, since the game is endless)

## Sources

-   https://opengameart.org/content/topdown-wizard (this is the player character)
-   I drew all other assets

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_
-   Score and health are clipped by screen bounds
-   Enemies and wizard spawn and are able to move too close to the top panel
-   Basically just the top panel is wonky, everything else works as intended
-   Also I wanted to implement non-uniform random but couldn't get that into the thing by the due date. I'll add it in on my own time, just for the practice

### Requirements not completed

_If you did not complete a project requirement, notate that here_

