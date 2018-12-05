"Lead Leo Home"
=================

Game Development final project for CSC476. "Lead Leo Home" is a complex game that involves different level
patterns and character interactions. There are 4 levels that the player must guide Leo the dog through.
If the player fails to lead him home within the allotted time, Animal Control will swoop in and take
Leo to the pound. Therefore you must try to complete each level as fast as you can!

----------
Controls:
----------
WASD or up, down, left, right to control Leo the dog.

--------
Levels:
--------
1:The Woods
-
  There are 4 different directions to choose. There are minor hints around the room that will point
  to which direction the player should take. Pick a wrong direction and you'll end up back at the
  start! Choose correctly 7 times in a row, and Leo will emerge into the next level; The Fields.
  
2:The River
-
  The next obstacle Leo faces is a wide river that will sweep him away if he tries to swim across.
  The usual method to cross the river was by bridge, but the bridge is broken! A less conventional
  method would be to hop across the stones to the other side, but there isnt a complete path! Using
  his head, Leo must find sticks to pile up at the top of the River to make a dam-thus halting the flow
  of the river. Find all 4 sticks hidden around the map, and carry them to the top of the river to dam it.
  Completing this level leaves Leo at the edge of the highway, just across the ways from his home!
  
3:The Fields
-
  Here, Leo must navigate through the mazeway that is these tall-grass fields. Not only that, but
  small critters are roaming around that will distract Leo if he gets too close! Lead Leo through
  the mazeway as fast as possible while avoiding critters to progress to The River.
  
4:The Highway
-
  Cars are zipping past left and right, so Leo must be careful crossing the road! The player has 3 lives to
  maneuver Leo across the highway safely and finally return him home! Fail to make it across in 3 lives and Animal
  Control will pick Leo up for endangering the people on the Highway. Make it across though, and Leo will return home
  safe and sound!
  
-----
UI:
-----
A timer will display to the player how long the overall run has been, as well as the time it took to complete
each previous level. Sample UI is as follows:
-----------------------------------------------------------------------------------------------------------
The Woods: 2:53.22 || The River: 1:00.00 || The Fields: -:--.-- || The Highway: -:--.--
Running Time: 3:53.22
-----------------------------------------------------------------------------------------------------------
In this case the player is on level 2 and is 1 minute into their attempt to complete it.

-------------
High Scores:
-------------
The player's best time for each level will be displayed above each level timer shown in the UI example above.
The game will also display the player's high score at the end of the game on the "Game Over" screen.
