# 3902TeamRed

Current Revision: 12/3/22

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

The Legend of Zelda done our way.  Current iteration is complete with full implementation of entire first dungeon, <br/>
with new features including custom controls and a level creator. <br/>



<!-- FOLDER DESCRIPTIONS -->
## Folder Descriptions

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block" target="_blank">Block</a> - Block generation and collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/Block.cs" target="_blank">Block.cs</a> - Enables Updateable and Drawable Capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockFactory.cs" target="_blank">BlockFactory.cs</a> - Produces all blocks
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockRectangle.cs" target="_blank">BlockRectangle.cs</a> - Holds default block size data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/IBlock.cs" target="_blank">IBlock.cs</a> - Block Interface

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Camera" target="_blank">Camera</a> - Camera and Transitions
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Camera/Camera.cs" target="_blank">Camera.cs</a> - Enables Updateable and Drawable Capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Camera/GameCamera.cs" target="_blank">GameCamera.cs</a> - Camera object that enables the transition gradually between rooms instead of clipping to them
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Camera/GameCamera.cs" target="_blank">ICamera.cs</a> - Camera Interface

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision" target="_blank">Collision</a> - Collision of any collidable objects
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/CollisionDetection.cs" target="_blank">CollisionDetection.cs</a> - Determines if a collision occurs
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/CollisionResolution.cs" target="_blank">CollisionResolution.cs</a> - Handles collisions when they do occur
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyBlockCollisionCommand.cs" target="_blank">EnemyBlockCollisionCommand.cs</a> - Enemy/Block collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyEnemyCollisionCommand.cs" target="_blank">EnemyEnemyCollisionCommand.cs</a> - Enemy/Enemy collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyPlayerCollisionCommand.cs" target="_blank">EnemyPlayerCollisionCommand.cs</a> - Enemy/Player collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyProjectileCollisionCommand.cs" target="_blank">EnemyProjectileCollisionCommand.cs</a> - Enemy/Projectile collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/ICollidable.cs" target="_blank">ICollidable.cs</a> - Collision Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerBlockCollisionCommand.cs" target="_blank">PlayerBlockCollisionCommand.cs</a> - Player/Block collision
* * <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerDoorCollisionCommand.cs.cs" target="_blank">PlayerDoorCollisionCommand.cs.cs</a> - Player/Door collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerEnemyCollisionCommand.cs.cs" target="_blank">PlayerEnemyCollisionCommand.cs.cs</a> - Player/Enemy collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerItemCollisionCommand.cs" target="_blank">PlayerItemCollisionCommand.cs</a> - Player/Item collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerProjectileCollisionCommand.cs" target="_blank">PlayerProjectileCollisionCommand.cs</a> - Player/Projectile collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/ProjectileBlockCollisionCommand.cs" target="_blank">ProjectileBlockCollisionCommand.cs</a> - Projectile/Block collision

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Content" target="_blank">Content</a> - Sprites and Imagery files

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller" target="_blank">Controller</a> - Interface for controllers and default key/mouse mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/ControlsKeyboard.cs" target="_blank">ControlsKeyboard.cs</a> - Keyboard used when modifying keyboard controls
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/IController.cs" target="_blank">IController.cs</a> - Controller Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/KeyboardController.cs" target="_blank">KeyboardController.cs</a> - Default Keyboard settings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/KeyboardDrawings.cs" target="_blank">KeyboardDrawings.cs</a> - Drawings used when displaying the controls screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseCommand.cs" target="_blank">MouseCommand.cs</a> - Allows for mouse clicking
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseController.cs" target="_blank">MouseController.cs</a> - Allows for Updateable and Registerable capabilites

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Door" target="_blank">Door</a> - Interface for controllers and default key/mouse mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Door/Door.cs" target="_blank">Door.cs</a> - Contains all of the features for doors
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Door/DoorFactory.cs" target="_blank">DoorFactory.cs</a> - Produces all doors
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Door/IDoor.cs" target="_blank">IDoor.cs</a> - Interface for doors


### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy" target="_blank">Enemy</a> - Enemy generation/Movement/Collision/Damaging
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/Enemy.cs" target="_blank">Enemy.cs</a> - Enables Updateable and Drawable Capabilities and defines enemy properties
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyFactory.cs" target="_blank">EnemyFactory.cs</a> - Produces all enemies
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyFrame.cs" target="_blank">EnemyFrame.cs</a> - Holds/Updates Enemy positions and frames
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyRectangle.cs" target="_blank">EnemyRectangle.cs</a> - Holds Enemy image rectangle data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyVelocity.cs" target="_blank">EnemyVelocity.cs</a> - Handles changes in Enemy movement velocity
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/IEnemy.cs" target="_blank">IEnemy.cs</a> - Enemy Interface

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game" target="_blank">Game</a> - Opening/Loading levels/Running/Stopping the game
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Constants.cs" target="_blank">Constants.cs</a> - Default measurements for important sizes
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Enums.cs" target="_blank">Enums.cs</a> - Enums for the 3 states (STANDING, RUNNING, ATTACKING) and the 4 directions (UP, DOWN, LEFT, RIGHT)
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ExitCommand.cs" target="_blank">ExitCommand.cs</a> - Enables exit game capabilites
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Game1.cs" target="_blank">Game1.cs</a> - Core of the game containing base components such as level loader, game object manager, and public interfaces
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/GameObjectManager.cs" target="_blank">GameObjectManager.cs</a> - Handles updating and drawing all objects currently in game by tracking them in lists
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ICommand.cs" target="_blank">ICommand.cs</a> - Command Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/LevelLoader.cs" target="_blank">LevelLoader.cs</a> - Enables transitions between the different rooms of the level
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/LoadLevelCommand.cs" target="_blank">LoadLevelCommand.cs</a> - Command used to load a level
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/LoadRoomCommand.cs" target="_blank">LoadRoomCommand.cs</a> - Command used to load a room
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/PauseCommand.cs" target="_blank">PauseCommand.cs</a> - Command used to pause
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Program.cs" target="_blank">Program.cs</a> - The very bottom that allows everything to run
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Room.cs" target="_blank">Room.cs</a> - Describes features of a room

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item" target="_blank">Item</a> - Item generation/Movement/Collision/Pickup
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/IItem.cs" target="_blank">IItem.cs</a> - Item Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/IObject.cs" target="_blank">IObject.cs</a> - Object Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/Item.cs" target="_blank">Item.cs</a> - Enables Updateable and Drawable capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemFactory.cs" target="_blank">ItemFactory.cs</a> - Creates all Items
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemObject.cs" target="_blank">ItemObject.cs</a> - Allows for XML parsing
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemRectangle.cs" target="_blank">ItemRectangle.cs</a> - Holds Item image rectangle data

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Levels" target="_blank">Levels</a> - Files containing each of the different rooms as well as the artificial one

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Link" target="_blank">Link</a> - Image of Link
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Link/LinkRectangle.cs" target="_blank">LinkRectangle.cs</a> - The defaults of Link's position and appearance

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player" target="_blank">Player</a> - Player generation/Movement/Collision/Damaging/Attacking
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/IPlayer.cs" target="_blank">IPlayer.cs</a> - Player Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/Player.cs" target="_blank">Player.cs</a> - Allows for Updateable and Drawable capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/PlayerCommands.cs" target="_blank">PlayerCommands.cs</a> - Allows for Running/Standing/Attacking/Damage/Projectiles in all directions
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/PlayerFactory.cs" target="_blank">PlayerFactory.cs</a> - Creates all Players

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile" target="_blank">Projectile</a> - Projectile generation/Movement/Collision/Damaging
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/IProjectiles.cs" target="_blank">IProjectiles.cs</a> - Projectile Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/Projectile.cs" target="_blank">Projectile.cs</a> - Allows for Updateable and Drawable Capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/ProjectileFactory.cs" target="_blank">ProjectileFactory.cs</a> - Creates all Projectiles
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/ProjectileRectangle.cs" target="_blank">ProjectileRectangle.cs</a> - Holds Projectile image rectangle data

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay" target="_blank">ScreenDisplay</a> - Key mappings for the display of all necessary objects
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextProjectileCommand.cs" target="_blank">NextProjectileCommand.cs</a> - Display next Projectile to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextProjectileCommand.cs" target="_blank">PrevProjectileCommand.cs</a> - Display previous Projectile to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/DisplayRoomCommand.cs" target="_blank">DisplayRoomCommand.cs</a> - Used to switch rooms
 <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/HandleSpecialDisplays.cs" target="_blank">HandleSpecialDisplays.cs</a> - Used to display different special screens

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite" target="_blank">Sprite</a> - Image display for all Players/Items/Blocks/Enemies/Text
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/ISprite.cs" target="_blank">ISprite.cs</a> - Sprite Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/Sprite.cs" target="_blank">Sprite.cs</a> - Allows for Updateable and Drawable capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteFactory.cs" target="_blank">FactorySprite.cs</a> - Creates all Sprites
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteRectangle.cs" target="_blank">SpriteRectangle.cs</a> - Holds Sprite image rectangle data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/TextSprite.cs" target="_blank">TextSprite.cs</a> - Allows for text output to the screen

<!-- PROGRAM CONTROLS -->
## Program Controls
You only have to start with the following keys, but they can be updated in game. <br/>

Move up:    'W'<br/>
Move left:  'A'<br/>
Move down:  'S'<br/>
Move right: 'D'<br/>
Attack:     'N'<br/>

Quit Game: 'Q' <br/>
Pause Game: 'P' <br/>
Restart Game (only after victory): 'R' <br/>

Shoot Projectile: 'B' <br/>
Previous Projectile: 'J' <br/>
Next Projectile: 'K' <br/>

Display Inventory: 'Y' <br/>
Remove Inventory: 'T' <br/>

Display Controls Screen: 'X' <br/>
Remove Controls Screen: 'Z' <br/>
To update a control, open up the controls screen and first tap the key that the current control is mapped to. Then press the new mapping that you want to replace the key for. If the requested key is already mapped to another key elsewhere, the request won't register. In that case, choose a different key to map to. <br/>
YOU CANNOT CHANGE THE CONTROLLER MAPPINGS FOR VIEWING (X) AND EXITING (Z) THE CONTROLS SCREEN. <br/>

<!-- LEVEL CREATOR CONTROLS -->
## Level Creator Controls

Change object - Click on either a block, item, or enemy<br/>
Place object - Click or hold down the left mouse click<br/>
Remove object - Right click on said object<br/>
Place Door - Click on a door<br/>
Move to north room - 'W'<br/>
Move to west room - 'A'<br/>
Move to south room - 'S'<br/>
Move to east room - 'D'<br/>
Exit creator - 'ESC'<br/>
Exit Game - 'Q'<br/>

THE LEVEL SELECT SCREEN IS NOT SCROLLING; THEREFORE, TOO MANY LEVELS MAY TAKE UP SPACE. TO LOAD THE CORRECT LEVEL MAKE SURE 'Custom Level' (with a space) IS SELECTED.
<!-- NON-REQUIRED TOOLS AND PROCESSES -->
## Non-Required Tools and Processes

When2meet:   when2meet.com  (Find best times to meet as a team) <br/>
<a href="https://trello.com/b/5pvXlIry/team-redd" target="_blank">Trello</a>:      trello.com     (Task Managment)  <br/>
Sprite Cow:  spritecow.com  (Used to find sprite coordinates on sprite sheet) <br/>
Discord:     discord.com    (Used to collaborate vitually) <br/> <br/>

## Backlog
The backlog mainly contains minor and major features that need to be made to improve the game or code quality. The backlog features that remained in the backlog on Trello are not necessary and are simply additions that would help clean up our code.
*Please see the Trello list "Backlog" for a full detail of all items here, as well as complete descriptions.*

<!-- KNOWN BUGS -->
## Known Bugs
Link does not move in completely expected ways when multiple movement keys are pressed (WASD)<br/>
Enemies are able to push Link outside of the room<br/>
*Please see the Trello list "Buglog" for a full detail of all items here, as well as complete descriptions.*

## Sprint 5 Reflection
The team organized tasks mainly by dividing up the work based on missing features, with Abd Elrahman working custom controls, Emil and Owen working on Camera transitions, Will working on a level creator, Adam working on the title screen, and Hamdan working on cleaning inventory. We had initially planned on including a multiplayer feature as well; however, we realized during the sprint that it would not be feasible to do so because we would not have enough time to finish the feature.<br/><br/>

A potential improvement could have been to work on multiplayer more early on. However, the team had decided to work on many features early on, including a level creator and custom controls, which helped with dismissing the multiplayer feature. Integration between Discord (our primary communication) and Trello also helped ensure that everyone was up to date on the completion of features. 
