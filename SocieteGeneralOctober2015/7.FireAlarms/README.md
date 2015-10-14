# Fire Alarms

## Objective

Thanks to your amazing study about flooding, you just got promoted. Now, you need to take care of fires.

You're given the map of the city, including the location of every bank and fire station. The goal of this challenge is to find, upon every fire alarm in a bank, the distance to the closest fire station.

## Data format

### Input

Row 1: two space-separated integers **W** and **L** between 2 and 50 representing the width and length of the map.  
Rows 2 to **W** + 1: **L** characters representing either:
* a bank 'B';
* a fire station 'F';
* an empty space '.'(dot) 

Row **W** + 2: an integer **N** between 1 and 20,000 representing the number of fire alarms in the city.  
Rows **W** + 3 to **W** + 2 + **N**: two space-separated integers **I** and **J** representing the coordinates of a detected fire in a bank of the city.  

To reach a bank from a fire station, there must be a path composed of empty spaces.  

Furthermore, there is at least one bank and one fire station. Several fire alarms can occur in the same bank. You can only either move horizontally or vertically between two points on the map.

### Output
N space-separated integers representing for each fire alarm the distance from the bank on fire to the closest fire station if it exists, -1 otherwise.
