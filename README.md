# 3902TeamRed

Current Revision: 10/01/22

<!-- TEAM MEMBERS -->
##Team Members

Hamdam Almehairbi (almeharibi.3)
William Gilicinski (gilicinski.3)
Owen Hennessey (hennesey.64)
Abd Elraham Ibrahim (Ibrahim.281)
Emil Pang (pang.216)
Adam Perhala (perhala.3)


<!-- ABOUT THE PROJECT -->
## About The Project

We have been working on our own version of the Legend of Zelda and we're so glad to let you get your first look.


<!-- FILE DESCRIPTIONS -->
## File Descriptions

Exit Command - Allows user to quit game
Game1 - Provides basis for game to load up and start
ICommand - Interface for Commands
IControllers - Interface for keyboard controllers
ISprite - Interface for the many in game sprites
KeyBoardController - Implementation of the IController interface. Provides mapping for D pad keys allowing for movement of user sprite.
LuigiRunning…Command - Each provides commands that induce motion upon the user sprite.
MouseCommand/MouseController- Provides for mouse motion and clicking
Sprite - Implements Sprite and allows for motion and drawing updates.
SpriteFactory - Produces Sprite imagery
SpriteRectangle - Allows for proper Sprite sizing
TextSprite - Allows for text output to the screen

<!-- PROGRAM CONTROLS -->
## Program Controls

Move up:    'W' or ⬆
Move left:  'A' or ⬅
Move down:  'S' or ⬇
Move right: 'D' or ⮕

Shoot Projectile: 'L'
Quit Game: '0'

Previous Block: 'T'
Next Block: 'Y'

Previous Item: 'U'
Next Item: 'I'

Previous Enemy: 'O'
Next Enemy: 'P'

<!-- NON-REQUIRED TOOLS AND PROCESSES -->
## Non-Required Tools and Processes

When2meet:   when2meet.com  (Find best times to meet as a team)
Trello:      trello.com     (Task Managment) 
Sprite Cow:  spritecow.com  (Used to find sprite coordinates on sprite sheet)
Discord:     discord.com    (Used to collaborate vitually)

The team has been working (with Adam taking point) on getting a working implementation of multiplayer going
for the Legend of Zelda.  He has been working on the client and one server to allow for 2 person play and has gotten
a loosely working implementation going.

<!-- KNOWN BUGS -->
## Known Bugs

Currently there is a bug in the projectile class where if the projectile firing button where if it is held for
two long the projectile will continue to draw and lengthen.  Arrow projectile appears to screen and flies successfully but does not
originate from Link (Luigi) himself.  Link doesn't stay damaged when he changes direction.  Damage goes on infinitely.
Attack goes on infinitely.

