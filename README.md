# Stacky-Dash-Clone
 Simple clone of the hyper casual game Stacky Dash. It has the main mechanics except the score calculating at the end of the level.
 
 ## Introduction
 
 I want to further develop my skills in mobile game development so I am making clones of some hyper-casual games to learn more about it. List of main features:
 
 * Moving forward, backward, left or right with swipe
 * Only moving in one direction at a time
 * Stacking cubes under the player when moving
 * Removing cubes on the bridge while passing
 * There is no score calculation at the end but there is code in script that calculates how many cubes left at the end

## Some Useful Scripts

### ControllerInput Script

In this script you can find swipe controls for mobile and can be used any other game that requires swiping. This script does not contain movement, it only detects swiping.

### StackScript Script & PlayerController Script

In those scripts you can find a stacking algorithm for getting cubes underneath and make player move upwards. There is also a part where stacks are removed too. You can take out the part that customized for this game and use the algorithm according to your game.

## Unity Packages

I only used Unity package named "Character Pack: Free Sample". It is a free package and it was the most suitable free package for my project.
