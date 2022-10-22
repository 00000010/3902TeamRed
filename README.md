# 3902TeamRed

Current Revision: 10/21/22

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
collision detection and handling, inclusion of all in game items and enemies, and a level loader for handling switching rooms <br/>



<!-- FOLDER DESCRIPTIONS -->
## Folder Descriptions

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block" target="_blank">Block</a> - Block generation and collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/Block.cs" target="_blank">Block.cs</a> - Enables Updateable and Drawable Capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockFactory.cs" target="_blank">BlockFactory.cs</a> - Produces all blocks
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockRectangle.cs" target="_blank">BlockRectangle.cs</a> - Holds default block size data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/IBlock.cs" target="_blank">IBlock.cs</a> - Block Interface

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision" target="_blank">Collision</a> - Collision of any collidable objects
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/CollisionDetection.cs" target="_blank">CollisionDetection.cs</a> - Determines if a collision occurs
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/CollisionResolution.cs" target="_blank">CollisionResolution.cs</a> - Handles collisions when they do occur
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyBlockCollisionCommand.cs" target="_blank">EnemyBlockCollisionCommand.cs</a> - Enemy/Block collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyEnemyCollisionCommand.cs" target="_blank">EnemyEnemyCollisionCommand.cs</a> - Enemy/Enemy collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/EnemyProjectileCollisionCommand.cs" target="_blank">EnemyProjectileCollisionCommand.cs</a> - Enemy/Projectile collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerBlockCollisionCommand.cs" target="_blank">PlayerBlockCollisionCommand.cs</a> - Player/Block collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerEnemyCollisionCommand.cs.cs" target="_blank">PlayerEnemyCollisionCommand.cs.cs</a> - Player/Enemy collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerItemCollisionCommand.cs" target="_blank">PlayerItemCollisionCommand.cs</a> - Player/Item collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/PlayerProjectileCollisionCommand.cs" target="_blank">PlayerProjectileCollisionCommand.cs</a> - Player/Projectile collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Collision/ProjectileBlockCollisionCommand.cs" target="_blank">ProjectileBlockCollisionCommand.cs</a> - Projectile/Block collision

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Content" target="_blank">Content</a> - Sprites and Imagery files

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller" target="_blank">Controller</a> - Interface for controllers and default key mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/IController.cs" target="_blank">IController.cs</a> - Controller Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/KeyboardController.cs" target="_blank">KeyboardController.cs</a> - Default Keyboard settings

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
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Program.cs" target="_blank">Program.cs</a> - The very bottom that allows everything to run
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ResetCommand.cs" target="_blank">ResetCommand.cs</a> - Enables restart capabilities and restores game to base state

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

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse" target="_blank">Mouse</a> - Mouse button mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseCommand.cs" target="_blank">MouseCommand.cs</a> - Allows for mouse clicking
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseController.cs" target="_blank">MouseController.cs</a> - Allows for Updateable and Registerable capabilites

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection" target="_blank">MovementDirection</a> - Player movement handling
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Left.cs" target="_blank">Left.cs</a> - Code to move Left
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Right.cs" target="_blank">Right.cs</a> - Code to move Right
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Up.cs" target="_blank">Up.cs</a> - Code to move Up

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
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextBlockCommand.cs" target="_blank">NextBlockCommand.cs</a> - Display next Block to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextEnemyCommand.cs" target="_blank">NextEnemyCommand.cs</a> - Display next Enemy to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextItemCommand.cs" target="_blank">NextItemCommand.cs</a> - Display next Item to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevBlockCommand.cs" target="_blank">PrevBlockCommand.cs</a> - Display previous Block to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevEnemyCommand.cs" target="_blank">PrevEnemyCommand.cs</a> - Display previous Enemy to screen
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevItemCommand.cs" target="_blank">PrevItemCommand.cs</a> - Display previous Item to screen

### <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite" target="_blank">Sprite</a> - Image display for all Players/Items/Blocks/Enemies/Text
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/ISprite.cs" target="_blank">ISprite.cs</a> - Sprite Interface
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/Sprite.cs" target="_blank">Sprite.cs</a> - Allows for Updateable and Drawable capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteFactory.cs" target="_blank">FactorySprite.cs</a> - Creates all Sprites
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteRectangle.cs" target="_blank">SpriteRectangle.cs</a> - Holds Sprite image rectangle data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/TextSprite.cs" target="_blank">TextSprite.cs</a> - Allows for text output to the screen

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

The team has been working (with Adam taking point) on getting a working implementation of multiplayer going
for the Legend of Zelda.  He has been working on the client and one server to allow for 2 person play and has gotten
a loosely working implementation going.

## Backlog
We did a lot of refactoring this sprint, and in the process, enemies lost their functionality to shoot projectiles. <br/>
We’ll have them shooting projectiles again next sprint. We’ll also add the ability to differentiate between Link <br/>
projectiles and enemy projectiles. </br>
Implement functionality to move between rooms through doors. <br/>
At the moment, Link’s collision with items is detected and the PlayerProjectileCommand which is a collision resolution <br/>
command is called as a result. <br/>
We still need to implement functionality to allow for Link to pick up items.<br/>


<!-- KNOWN BUGS -->
## Known Bugs
Link and enemies can move outside the room because the room background does not take the whole screen yet<br/>
When loading in a stalfos the keese sprite appears but it behaves like a stalfos<br/>
Collisions occur but Link violently shakes while he's colliding<br/>

## <a href="https://trello.com/b/5pvXlIry/team-redd" target="_blank">Trello link</a>



