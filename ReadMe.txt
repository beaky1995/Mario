Mario commands
---------------
-up/w should change mario to an idle state if he was in a crouching state and a jumping state if he was not.
-down/s should change mario to an idle state if he was jumping state and a crouching state if he was not.
-left/a and right/d should change mario between left running, left idle, right idle, and right running.

Game Commands
-------------
-q = Quit the game
-r = Reset the game
-m = Mouse controller
-enter = Select level

Features
------------

1) Firebar
- Firebar is a rotating obstacle in Level 1-4. It works by creating multiple nodes of fireballs that form an obstacle
- Using a transformation, each individual link in the Firebar is rotated around the center.

2) Level Selector
- The level selector allows us to load multiple differnt levels at will
- Super Mario Brothers 1-1 and 1-4 are available for selection

3) Bowser
- Bowser is a boss that appears at the end of the level.
- It is implemented to have some random behavior that can be hard to predict, thus satisfying our requirement of a hardy foe.
- He can throw FireSpears and also jump large distances

4) Platform
- The platform is relatively straightforward. It moves horizontally with a specified distance from it's original location.
- Mario is able to catch a ride on the platform

5) Axe
- Touching the axe launches the ending sequence

6) Bridge
- After touching the Axe, the bridge will collapse, sending Bowser to his maker.
- The Bridge retracts piece by piece, causing dramatic effect.

7) FireSpear
- FireSpears are fast moving objects that are launched by Bowser. It causes mario to take damage.

8) Lava
- Lava kills mario when he falls in it.
- Lava is also supposed to spew random projectiles out of it.

Code Analysis Warnings
----------------------
 -CA1500: empty now but may keep for future use
 -CA1059: XmlNode is necessary for LevelLoader.
 -CA1822: Unsure as to meaning of this warning. The website explanation states, "It is safe to suppress a
	      warning from this rule for previously shipped code for which the fix would be a breaking change."
		  so we will attempt to fix later once more fully understood. Double clicking any of the warnings simply
		  highlights the opening curly brace for the function mentioned.
-Issues with gamepad controller files will be dealt with when using gamepad.
-CA1002: Instructed to use List.
-CA1501 & CA1024: It is unnecessary to change a public to private with a property.




