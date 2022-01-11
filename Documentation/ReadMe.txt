Mario commands
---------------
-w should make mario jump if he was not previously (and if he is not falling currently).
-s should make big and fire mario crouch.
-a and d should make Mario run left and right, respectively.
-x should make mario throw a fireball, if he is in the Fire State.

Game Commands
-------------
-q = Quit the game
-r = Reset the game
-m = Mouse controller

Code Analysis Warnings
----------------------
 -CA1500: empty now but may keep for future use
 -CA1059: XmlNode is necessary for LevelLoader.
 -CA1822: Double clicking any of the warnings simply
		  highlights the opening curly brace for the function mentioned.
		  The static class are not nessesary to be changed.
-Issues with gamepad controller files will be dealt with when using gamepad.
-CA1002: Instructed to use List.
 CA1024: It is unnecessary to change a public to private with a property.
				




Sprint Remainder
----------------
- Adding functionality back to the up/down/left/right keys (really only affects up key)
MAY NEED TO build the Content.mgcb before running


-The new collision detection/handler is written with the feedback given by the grader but imcomplete due to
the length of the time from getting feedback from Refactoring Sprint3 and due of Refactoring Sprint4, 
 the imcompleted collision detection/handler classes are inside the Collision Folder but did 
 not do or be called by anything. Will be done before initial implementation of Sprint5

-The old collision detection/handler is still there and are used for running the project, fixed and cleaned
all but the block class - The if statements should be simplified.

