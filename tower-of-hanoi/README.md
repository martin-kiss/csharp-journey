# Tower of Hanoi

A console version of the classic Tower of Hanoi puzzle. Choose the number of disks and move them between towers A, B, and C until all disks are stacked on the target tower.

## How to run

```bash
dotnet run
```

Choose the number of disks when prompted. At least 3 disks are required.

Enter a two-letter move such as `ab` to move a disk from tower A to tower B.

Type `k` to quit the game.

## Notes

Moving a disk from an empty tower can cause the program to crash.

The win condition currently checks whether any tower is full and has disk `1` on top, rather than checking the specific target tower. Because of this, moving a disk away and immediately back (for example, from A to B and then B back to A) can incorrectly trigger the win message.

## Date

18 December 2025
