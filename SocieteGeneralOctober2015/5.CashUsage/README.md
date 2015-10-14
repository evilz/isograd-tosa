# Cash usage

## Objective

The aim of this challenge is to determine which cash dispensers have delivered the largest amount of money. For this purpose you are provided with a log file that contains usage information. 

## Data Format

### Input
Row 1 : an integer **N** between 1 and 1000 indicating the number of entries in the log file.  
Row 2 to **N** + 1 : a string of 8 alphanumeric characters and an integer number between 10 and 1000 separated by a space. They represent the identifier of the cash dispenser and the amount withdrawn.

### Output
The identifiers of the 10 dispensers that have distributed the most money ordered by descending amounts. Identifiers should be separated by a space. If there are less than 10 dispensers in the log file, display them all. If multiple dispensers have delivered the same amount of cash then order them by identifier in ascending order.