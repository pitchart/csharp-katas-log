# Your Task
You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet. Develop an API that translates the commands sent from earth to instructions that are understood by the rover.

# Requirements
- You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
- The rover receives a character list of commands.
- Implement commands that move the rover forward (F).
- Implement commands that turn the rover left/right (L,R).
- Implement wrapping at edges. But be careful, planets are spheres. Connect the x edge to the other x edge, so (0,0) for x-1 to (4,0), but connect vertical edges towards themselves in inverted coordinates, so (0,0) for y-1 connects to (4,0).
- Implement obstacle detection before each move to a new position. If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point, stops the sequence and reports the obstacle.

# INPUTS
A series of commands as string (ex: MLMRRMM) 

# OUTPUTS
