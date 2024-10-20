# Absolute Aim Academy

![AAA](https://github.com/user-attachments/assets/26c84e33-cc1b-4fa2-acd6-e67169494b3b)

Welcome to the Absolute Aim Academy, where your aim as a gunmen will be tested. Through various challenges, only the chosen with the most perfect aim can pass this academy. Can you?

## About Gmae
Absolute Aim Academy is an arcade style game where player needs to click various targets. The player given a minute and a maximum of 10 health each level. Each time the player click a target, the player get health. But if the player missclick or let the target dissapear, the player lose health. The player loses if health reaches zero. Survive until the timer ends to get to the next level.

## Mechanics

### Unique Targets
There's a total of 5 unique targets with different method on how to click them in the game: Normal, False, Multi, Arrow, and Inverse Arrow.

![Targets](https://github.com/user-attachments/assets/89c5fb8e-fcf1-499c-8fa1-6d98fb35b448)

Normal: Click once.
False: Don't click. Wait until dissapear.
Multi: Click as many times as the target specified.
Arrow: Click the tile it's pointing to.
Inverse Arrow: Click the tile reversed it's pointing to.


### Arrow Target Spawn
Arrow target is a type of target where the player have to click the tile it's pointing to, instead of of the tile it spawns.

![AAA Arrow](https://github.com/user-attachments/assets/d90dde79-00b2-41e3-ab3b-d1d1cae2b8eb)

Arrow Target that's pointing to certain direction (which is randomized) can't spawn on certain tiles. For example, Arrow Target pointing to up can't spawn on tiles on the upper rows.


### Level Variables
There's some variables that can be tuned to make each levels unique and fun.

![Screenshot 2024-10-21 025325](https://github.com/user-attachments/assets/aaadb8f3-2aab-4485-9179-42eb1fc287d7)

The developers can easily modify these variables through the Unity inspector.

## Scripts

| Script | Description |
| --- | --- |
| `GameManager.cs` | Manages the variables that needs to be saved and loaded e.g. score and game progress. |
| `LevelManager.cs` | Set the variables and it's systems that needed to setup each level. |
| `Board.cs` | Setup the board based on the variables from `LevelManager.cs`. |
| `TargetTile.cs` | Set the states of tile based on what target spawns. |
| `etc` | |

## Assets
Some of the art assets used in this game were created by me, except for the background which can be downloaded from here:
- https://kevins-moms-house.itch.io/four-seasons-platformer-tileset
