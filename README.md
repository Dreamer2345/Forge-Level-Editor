
## Introduction

If you have played Dark Ritual enough, you may have realised that it consists of static and random levels which are delivered alternately.  This tool allows you to create new static levels or edit the existing ones that come with the game.
Defining a level is accomplished in four easy steps:

•	design your level using the selection of tiles

•	add sprites (enemies and objects the player interacts with) within the map

•	wire up any actions that one tile has on another, such as a lever that opens a door

•	define the player’s starting position


Once done, you can save the map and recompile the game and start playing.
So let’s get going!  In addition to downloading the level editor itself, you should also download the Dark Ritual source code. 

## Opening an Existing Map File

Typically, you will want to add levels to the existing game’s collection.  This can be done by selecting the Load option from the File menu.
 
<img src="/images/img1.png" data-canonical-src="/images/img1.png" />

Navigate to the Dark Ritual source code you downloaded earlier and locate the Maps.h file under the /src/maps directory.  Highlight the file and click Open.

 

Once you have loaded the file, you can browse the existing maps under the Maps menu.  The map currently being viewed (and edited) is denoted by having a tick beside it.  Maps are played in the order they appear in the list and you will notice that you can move a map up or down in the list using the Move menu options.

 


## Adding a new Level

Additional maps can be added to the collection by clicking the Add Map option from the Maps menu.  This will reveal the Add a New Map dialogue as shown below.

 

Maps must be given a unique name that is also a valid C++ variable name, ie. it must start with a character or underscore and can only contain characters, numbers and underscores.  Maps are limited to a width and height of 40 but really this is not really a limitation as that is a huge map!  The Timer setting denotes the amount of time a player has to complete the level with any left-over time rewarded as points.  The timer range is between 0 and 255 – the default value of 200 is typically enough for most medium complexity maps.


## Adding Tiles and Sprites

Once the map is defined, you can add tiles and maps using the tools at your disposal.  Note that in addition to the tools on the menu, you can right click on elements of the map to reveal a context menu that allows you to interact with the tile or sprite below it.  Furthermore, a handy list of the most recently used tiles and sprites is available to speed up the development process.

 

It is important to note that the maps are not validated!  You will need to adhere to the following guidelines.

Maps should:

•	be totally enclosed by walls.  I have no idea what would happen if you were able to walk off the edges of a map but suspect it will not be good.
•	have at least one Level Exit point. 
•	not expose the ‘reverse’ side of a wall tile to the player.  The player / wall collision detection has been written with the front of the tiles in mind – you can possibly walk through tiles from the wrong side.
•	have no more than 200 sprites.
•	note have tiles placed in the ‘outside’ corners of walls.  You will notice in the diagram above that the ‘outside’ corners are left empty (by either using the `Null` or `Empty` tile).  When the game renders the level, it will fill that with the appropriate fill pattern.

A number of the tiles require a brief description:

•	**Level Entry** – this is purely decorational and is used to indicate a progression from the previous level to the current level.
•	**Closed Chests (Key / Random)** – when opened, will give the player a key or a random item.  Use the key version when you have a door on the same or following level that requires a key.  Note that the random levels between the fixed levels will never consume keys.  Random items include coins, food and the occasional spell.   
•	**Closed Chests (Monster)** – when opened, the chest turns into an attacking monster.  
•	**Closed Chests (Altar Piece)** – contains an altar piece.  When placing a chest with an altar piece, the game will randomly distribute the actual piece across any chest marked as `Altar` or `Random` to provide some variation in the map so it is advised to place a number of the `Random` chests about.  Also note that the player only needs six altar pieces to win so use them sparingly.
•	**Switch Broken** – when using a broken switch, you will need to ensure that there are tools on this or a preceding level.
•	**Shop** – you will notice that the shop is split across 6 tiles.  Although the tiles can be used individually, why would you?  Please use them all.
•	**Altar** – the altar can only be used once in a game and on the last level (obviously).

## Adding Switch Doors and other Active Elements

A number of the tiles can interact with each other.  These combinations include `Lever/Spear Door`, `Lever/Exploding Barrel`, `Press Plate/Door` and `Worm Hole/Worm Hole`.
A simple example of a `switch` and `spear door` is shown below.  You may have noticed in the `Tiles` list that there are two columns named `IsSender` and `IsReceiver` which denotes whether the tile is something a player interacts with (the sender) or its state is altered by the action (the receiver).
In the image below, the highlight `Spear Door` tile is a receiver of an action.  A few lines below that you can see that the `Worm Hole` is marked as both a sender and a receiver as two worm holes can be configured to provide bidirectional travel.

 

The actions between tiles are defined on the Connections tab.  The connection defines a link from the sender to the receiver and is simply created by highlighting the corresponding tiles in this order.  As you add connections, they are validated in the right-hand side list.  Adding a connection between unrelated tiles or even from receiver to sender (ie backwards) will result in an invalid connection.

 

`Worm Holes` can be configured as uni- or bi-directional by adding a single or multiple connections.  Note in the example below that two connections have been added with the start X/Y and end X/Y reversed.  

 

## Defining a Starting Position

The final step to creating a level is to define the player’s starting position.  This can be achieved by selecting the `Player Start` tab and then clicking on the position within the map.  Once the starting position has been selected, it will be highlighted by a blue square.

 


## Saving the Map and Recompiling the Game.

Once you have completed your map design, you can save the changes by selecting `Save` from the `File` menu.  You are now ready to recompile the game with the new maps in place for testing .. I am going to assume you know how to compile a Pokitto progam using FemtoIDE or your favourite toolset.  If not contact me and I will help you!

 
