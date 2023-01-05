# OverTurret
 OverCooked Parody

I made this for fun. I wanted to recreate the systems found in OverCooked, and modify to use it in a turret defense game style. :D
IDK how to write README files, so this is what I'm gonna write. 


## Pre.1.0
In this stage, I made a basic player, a basic turret, and a basic enemy. This will be the foundation of the game

## Pre.1.1
In this stage, I modified the turret model into material items. I also created logics so that the player can throw them. 

## Pre.1.2
In this stage, I added the table, allowing the players to place items on the table. 
 - The biggest problem here was that picking up items, throwing items, placing items on the table, and picking up items from the table all happened with spacebar. This is done because the alternate interact key (will be 'F' key in the future) will be used to merge items to make a turret.
 - To solve this problem, I had to set up the order the code detects the events. 
1. Player detects if there's a table nearby. If the player is holding an item, the item is placed on the table
2. Player detects if there's a table nearby (This is checked again so that it can be put in a flowing 'if else' statement). If the player is not holding an item, check if there is an item on the table. If there is, take the item. 
3. If Player is holding an item, throw the item. 
4. If Player is not holding an item, check if there's an item nearby. If there is, pick up the item. 
 - When done in this order, the player can smoothly pick up items and throw items while still interacting with the table. 

## Pre.1.3
In this stage, I added the Assembler, which is a variation of the table. The biggest difference other than the model is that it can hold up to three items. I wish I can delete some variables from parent class, but I don't think that's possible. However, I haven't made the assembling system yet. I have to work on recipes and other details to make it work, so that' will probably be my next update. 

## Pre.1.4
In this stage, I added the Assembler system. I created a resource folder where I can add all the recipes of turrets in the future. I used ScriptableObjects to make the recipes. 

Then, I let the players be able to assemble with 'F' key. When they press the 'F' key, the assembler goes through all recipes and look for a recipe that contains all items in the assembler. If there is a match, the product in instatiated. If there isn't, even though there isn't anything yet, I will add an animation that shows the recipe doesn't work. 

## Pre.1.5
In this stage, I made the enemy AI. Currently I made it follow the player, but later, I am planning to add a center beacon for enemies to attack. 

I also made the turrets be able to attack the enemies. It has a look range and an attack range. This will be useful later when I make it so that it takes a long time for the turret head to rotate.

Hopefully, I can make it so that the enemies can travel in different paths. If nothing works, I will probably make it so that there's a fixed path. 

## Pre.1.6
... Screw the upload system. 

## Pre.1.7
In this stage, I created the material box, which was supposed to be created on the previous update. Thanks to the file not getting uploaded, I had to recreate the model. However, this actually helped me to finalize on whether I should create a parts builder or a material box. In the end, I decided to do both. :P I will be making the parts builder in later stages. 

I also worked on item throwing system. Before, the player threw the items at a fixed distance. Now, the player throws it based on how long the player holds the space key. This is done by creating a "throw mode," which will be useful when I add animations later. 

As I worked on the throwing, I also decided to let the items land on tables. Thus, I made the player throw the items higher. Then, I made the items land on the table the item collides with. This was more confusing than expected (Thanks to this, I failed my 1 commit per day challenge.........). However, this helped me understand override functions and inheritance better. Yay...?


## Pre.1.8
In this stage, I worked on the cameras. Because the map is long, I would think one camera would not be enough. Thus, I made two cameras and let the players exchange between two. 

I am on a trip when I made this, so I didn't do much. Welp. Too bad. :P At least I did something. 

## Pre.1.9
In this stage, I created the beacon, and this allowed me to create a basic gameplay of the game. I created an Enemy Manager, where it spawns enemies at a certain interval at given spawnpoints. Later, I will add wave system, but that will be quite far in the future. 

I also changed the turret system. I added bullet counts and health. When the turrets use up all the bullets, it stops firing. In the future, I will make the enemies attack the turrets, and when the health becomes 0, I will make it explode. 

Smaller changes
 - Created a small branch of AssemblerRecipe called TurretRecipe. This will make it easier to set stats for each turrets
 - Added attack animation for the basic enemy. However, it is not being used right now. 

## Pre.1.10
In this stage, I worked more on the visual things, such as hologram effects and animations.
 - Animation for opening material boxes
 - Animation for attacking turrets
 - Hologram for items on the material boxes

Another big change is adding health and bullet system + enemy tracking system. I made it so that there will be limited number of enemies attack a turret (3 for basic). This would hopefully prevent crowding. Later, I will add an explosion so that the turrets will damage the enemies when it dies. 

I also edited small things, such as how players take items from material boxes, level balancing, etc. Hopefully, after the explosion is added, I can work on level designs. As I do, I should create a storyboard for the system. 
+ Idk when, but I need to change these into multiplayer in the future. 

## Pre.1.11
In this stage, I tweaked more gameplay related things. 

Firstly, I added the explosion. I think I need to work on the explosion a bit more, but it should work for now. It also damages nearby enemies, which I think helps a lot. However, as I test played, I realized that exploding and bullet counts are not enough to force the players to constantly make turrets. So, I made it so that turrets will drain health slowly. This would definitely force players to make or even strategize when to start making turrets. 

I also designed the map a little. I believe this map will be the first tutorial map of the game. Other than that, there wasn't much. 