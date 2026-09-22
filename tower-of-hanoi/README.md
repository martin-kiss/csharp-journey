A console version of the classic Tower of Hanoi puzzle. Pick how many 
disks to play with (3 minimum), then move disks between towers A, B, 
and C until they're all stacked on the target tower.

## How to run
dotnet run

Enter a two-letter move like `ab` to move a disk from tower A to 
tower B. Type `k` to quit.

## Notes
Moving from an empty tower can crash the program.

The win check only looks at whether a tower is full with the top 
disk being 1 — it doesn't check *which* tower. So moving a disk away 
and immediately back (e.g. from A to B, then B back to A) can 
incorrectly trigger the "you won" message, since tower A ends up full 
again.
