# Conway's Game of Life

## Evolution Rules
*	Birth: Any dead cell with exactly three live neighbours becomes a live cell.
*	Survival: Any live cell with two or three live neighbours lives in the next generation.
*	Death by loneliness: Any live cell with fewer than two live neighbours dies, as in under-population.
*	Death by overcrowding: Any live cell with more than three live neighbours dies, as in over-population.

## Details

*	Particle placement (Q, W, E, R): Particles are placed (key Q, W, E, R) into the simulation area based on the center of the particle using direction keys (right, left, up, down).

*	Particle rotation (1, 2, 4): Key 1, 2, 4 can be used to rotate a specific particle (particle Q, W, R) 90 degrees in clockwise direction.

*	Cell deletion (3): Key 3 is used to delete a single cell where cursor is on.

*	Clear screen (0): Key 0 is used to clear simulation area.

*	Generate new random particle (T): User can generate new particle-R using key T.

*	Generate new random particle and place randomly (Y): User can generate new particle-R and place randomly by using key Y.

*	Generate next step (space): When user presses space key, the next iteration of the simulation is calculated and printed.
