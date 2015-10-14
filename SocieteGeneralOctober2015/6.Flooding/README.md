# Flooding

## Objective

Following a flood, the bank needs to be evacuated. The building of modern design is rectangular and made of blocks. Each block has multiple levels that are linked by a stairway. Your office is located at the top left corner of the building and the exit is located at the bottom right corner. You can go through a block if and only if it is higher or equal that the water level. The water level is constant in the building. The goal of this challenge is to determine if you can exit the building.

## Data format

### Input
Row 1 : 3 integers **W**, **L** and **H** space separated representing the width and length of the building, and the height that the water has reached. **W** and **L** are between 2 and 50. **H** is between 1 and 100,000.  
Row 2 to **W** + 1 : **L** integers between 1 and 100,000 separated by a space representing the height of the block for a given row. The first value of row 2 is consequently the top left corner of the building and the last value of row **W** + 1 is the bottom right corner of the building.  
  
You can only move horizontally or vertically between two points of the map. Furthermore, top-left and bottom-right corners are at height 100,000, thus the entrance and exit are never underwater.

### Output
The string YES if you can go from your office to the exit by only going through blocks that are higher or equal than the water level. Otherwise, the string NO.
