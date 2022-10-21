# 3902TeamRed

Current Revision: 10/20/22

<!-- TEAM MEMBERS -->
## Team Members

Hamdam Almehairbi (almeharibi.3) <br/>
William Gilicinski (gilicinski.3) <br/>
Owen Hennessey (hennesey.64) <br/>
Abd Elrahman Ibrahim (Ibrahim.281) <br/>
Emil Pang (pang.216) <br/>
Adam Perhala (perhala.3) <br/>


<!-- ABOUT THE PROJECT -->
## About The Project

We have been working on our own version of the first level of the Legend of Zelda and we're so glad to let you get your first look.


<!-- FILE DESCRIPTIONS -->
## File Descriptions

Exit Command - Allows user to quit game <br/>
Game1 – Loads in the content and level loader <br/>
ICommand - Interface for Commands <br/>
IControllers - Interface for keyboard controllers <br/>
ISprite - Interface for the many in game sprites <br/>
IObject: Generic interface used for CollisionDetection and CollisionResolution <br/>
IProjectile/IEnemy/IItem/IPlayer/IBlock: Interfaces for the different objects in the game <br/>
Enemy/Item/Block/Projectile/Player: Concrete classes for the objects in the game <br/>
KeyBoardController - Implementation of the IController interface. Provides mapping for D pad keys allowing for movement of user sprite. <br/>
PlayerProjectilesCollisionCommand, …CollisionCommand – All 8 commands to resolve the collisions that occur in the game <br/>
CollisionDetection/CollisionResolution – To detect and resolve collisions <br/>
MouseCommand/MouseController- Provides for mouse motion and clicking <br/>
Sprite - Implements Sprite and allows for motion and drawing updates. <br/>
SpriteFactory, …Factory – Instantiate all the objects in the game<br/>
SpriteRectangle, …Rectangle - Allows for proper Sprite sizing <br/>
TextSprite - Allows for text output to the screen <br/>
LevelLoader – Loads the level and all of the game objects <br/>

<!-- PROGRAM CONTROLS -->
## Program Controls

Move up:    'W' or ⬆ <br/>
Move left:  'A' or ⬅ <br/>
Move down:  'S' or ⬇ <br/>
Move right: 'D' or ⮕ <br/>
Attack:     'N' or 'Z' <br/>

Damage Link: 'E' <br/>

Shoot Projectile: 'L' <br/>
Quit Game: 'Q' <br/>

Previous Block: 'T' <br/>
Next Block: 'Y' <br/>

Previous Item: 'U' <br/>
Next Item: 'I' <br/>

Previous Enemy: 'O' <br/>
Next Enemy: 'P' <br/>

Reset Link: 'R' <br/>

Load a new room: 'H' <br/>

<!-- NON-REQUIRED TOOLS AND PROCESSES -->
## Non-Required Tools and Processes

When2meet:   when2meet.com  (Find best times to meet as a team) <br/>
Trello:      trello.com     (Task Managment)  <br/>
Sprite Cow:  spritecow.com  (Used to find sprite coordinates on sprite sheet) <br/>
Discord:     discord.com    (Used to collaborate vitually) <br/> <br/>

The team has been working (with Adam taking point) on getting a working implementation of multiplayer going for the Legend of Zelda.  He has been working on the client and one server to allow for 2 person play and has gotten a loosely working implementation going.

## Backlog
We did a lot of refactoring this sprint, and in the process, enemies lost their functionality to shoot projectiles. We’ll have them shooting projectiles again next sprint. We’ll also add the ability to differentiate between Link projectiles and enemy projectiles. </br>
Implement functionality to move between rooms through doors.</br>
At the moment, Link’s collision with items is detected and the PlayerProjectileCommand which is a collision resolution command is called as a result. We still need to implement functionality to allow for Link to pick up items.</br>


<!-- KNOWN BUGS -->
## Known Bugs
Link can move outside the room because the room background does not take the whole screen yet</br>

## Trello link
https://trello.com/b/5pvXlIry/team-redd

