# 3902TeamRed

Current Revision: 10/01/22

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

We have been working on our own version of the Legend of Zelda and we're so glad to let you get your first look.


<!-- FILE DESCRIPTIONS -->
## File Descriptions

Exit Command - Allows user to quit game <br/>
Game1 - Provides basis for game to load up and start <br/>
ICommand - Interface for Commands <br/>
IControllers - Interface for keyboard controllers <br/>
ISprite - Interface for the many in game sprites <br/>
KeyBoardController - Implementation of the IController interface. Provides mapping for D pad keys allowing for movement of user sprite. <br/>
LuigiRunning…Command - Each provides commands that induce motion upon the user sprite. <br/>
MouseCommand/MouseController- Provides for mouse motion and clicking <br/>
Sprite - Implements Sprite and allows for motion and drawing updates. <br/>
SpriteFactory - Produces Sprite imagery <br/>
SpriteRectangle - Allows for proper Sprite sizing <br/>
TextSprite - Allows for text output to the screen <br/>

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

<!-- NON-REQUIRED TOOLS AND PROCESSES -->
## Non-Required Tools and Processes

When2meet:   when2meet.com  (Find best times to meet as a team) <br/>
Trello:      trello.com     (Task Managment)  <br/>
Sprite Cow:  spritecow.com  (Used to find sprite coordinates on sprite sheet) <br/>
Discord:     discord.com    (Used to collaborate vitually) <br/> <br/>

The team has been working (with Adam taking point) on getting a working implementation of multiplayer going
for the Legend of Zelda.  He has been working on the client and one server to allow for 2 person play and has gotten
a loosely working implementation going.

## Backlog
Besides the known bugs (documented below), there are no items currently in the backlog.

<!-- KNOWN BUGS -->
## Known Bugs

Currently there is a bug in the projectile class where if the projectile firing button where if it is held for
two long the projectile will continue to draw and lengthen.  Arrow projectile appears to screen and flies successfully but does not
originate from Link (Luigi) himself.  Link doesn't stay damaged when he changes direction.  Damage goes on infinitely.
Attack goes on infinitely.

## Trello link
https://trello.com/b/5pvXlIry/team-redd

