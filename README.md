# MediaBuyingSystems

This is the Assembly Rover project designed for Media Buying Systems.
This project contains console application, its depenedent class libraries and unit test project.

-------------------------
Input
-------------------------

The input flow is described in console and it is guaranteed the valid input entrence.
Here are the inputs;

* Grid size: [1-100]
* Component size >1
* Component locations [0-ComponentSize]
* Rover location [0-ComponentSize]

Example input:

2
2
1,1
0,0
0,1

-------------------------
Output
-------------------------

This is a recursive algorithm that applies the Depth First Search graph traversal algorithm.
From starting the rover position it finds the next available component.
If the component is successfully found, the rover starts again its current position to find next available component.
This step repeats until the all components are reached.
The traversed path will be returned as output in string format.

Example output:

NPSWP
