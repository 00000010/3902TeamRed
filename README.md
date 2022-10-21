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

### Block - Block generation and collision
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/Block.cs" target="_blank">Block.cs</a> - Enables Updateable and Drawable Capabilities
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockFactory.cs" target="_blank">BlockFactory.cs</a> - Produces all blocks
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/BlockRectangle.cs" target="_blank">BlockRectangle.cs</a> - Holds default block size data
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Block/IBlock.cs" target="_blank">IBlock.cs</a> - Block Interface

### Content - Sprites and Imagery files

### Controller - Interface for controllers and default key mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/IController.cs" target="_blank">IController.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Controller/KeyboardController.cs" target="_blank">KeyboardController.cs</a>

### Decorators

### Enemy - Enemy generation/Movement/Collision/Damaging
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/Enemy.cs" target="_blank">Enemy.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyFactory.cs" target="_blank">EnemyFactory.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyFrame.cs" target="_blank">EnemyFrame.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyRectangle.cs" target="_blank">EnemyRectangle.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/EnemyVelocity.cs" target="_blank">EnemyVelocity.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Enemy/IEnemy.cs" target="_blank">IEnemy.cs</a>

### Game - Opening/Loading levels/Running/Stopping the game
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Constants.cs" target="_blank">Constants.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Enums.cs" target="_blank">Enums.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ExitCommand.cs" target="_blank">ExitCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Game1.cs" target="_blank">Game1.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/GameObjectManager.cs" target="_blank">GameObjectManager.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ICommand.cs" target="_blank">ICommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/LevelLoader.cs" target="_blank">LevelLoader.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/Program.cs" target="_blank">Program.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Game/ResetCommand.cs" target="_blank">ResetCommand.cs</a>

### Item - Item generation/Movement/Collision/Pickup
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/IItem.cs" target="_blank">IItem.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/Item.cs" target="_blank">Item.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemFactory.cs" target="_blank">ItemFactory.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemObject.cs" target="_blank">ItemObject.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Item/ItemRectangle.cs" target="_blank">ItemRectangle.cs</a>

### Link - Image of Link
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Link/LinkRectangle.cs" target="_blank">LinkRectangle.cs</a>

### Mouse - Mouse button mappings
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseCommand.cs" target="_blank">MouseCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Mouse/MouseController.cs" target="_blank">MouseController.cs</a>

### MovementDirection - Player movement handling
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Left.cs" target="_blank">Left.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Right.cs" target="_blank">Right.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/MovementDirection/Up.cs" target="_blank">Up.cs</a>

### Player - Player generation/Movement/Collision/Damaging/Attacking
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/IPlayer.cs" target="_blank">IPlayer.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/Player.cs" target="_blank">Player.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/PlayerCommands.cs" target="_blank">PlayerCommands.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Player/PlayerFactory.cs" target="_blank">PlayerFactory.cs</a>

### Projectile - Projectile generation/Movement/Collision/Damaging
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/IProjectiles.cs" target="_blank">IProjectiles.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/Projectile.cs" target="_blank">Projectile.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/ProjectileFactory.cs" target="_blank">ProjectileFactory.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Projectile/ProjectileRectangle.cs" target="_blank">ProjectileRectangle.cs</a>

### ScreenDisplay - Key mappings for the display of all necessary objects
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextBlockCommand.cs" target="_blank">NextBlockCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextEnemyCommand.cs" target="_blank">NextEnemyCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/NextItemCommand.cs" target="_blank">NextItemCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevBlockCommand.cs" target="_blank">PrevBlockCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevEnemyCommand.cs" target="_blank">PrevEnemyCommand.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/ScreenDisplay/PrevItemCommand.cs" target="_blank">PrevItemCommand.cs</a>

### Sprite - Image display for all Players/Items/Blocks/Enemies/Text
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/ISprite.cs" target="_blank">ISprite.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/Sprite.cs" target="_blank">Sprite.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteFactory.cs" target="_blank">FactorySprite.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/SpriteRectangle.cs" target="_blank">SpriteRectangle.cs</a>
* <a href="https://github.com/00000010/3902TeamRed/blob/dev/sprint0/Sprite/TextSprite.cs" target="_blank">TextSprite.cs</a>

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

<!-- TRELLO LINK -->
## <a href="https://trello.com/b/5pvXlIry/team-redd" target="_blank">Trello Link</a>


