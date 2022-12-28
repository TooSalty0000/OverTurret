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
