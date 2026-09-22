# Vehicle Speed Control

Reads vehicle entry and exit timestamps from a measurement file, calculates average speeds, displays traffic statistics, identifies the fastest vehicle, calculates the percentage of speeding vehicles, and generates a list of fines.

## How to run

The `measurements.txt` file needs to exist at:

`C:\temp\measurements.txt`

Each line should contain the following data, separated by spaces:

```text
license plate entry hour minute second ms exit hour minute second ms
```

The program calculates each vehicle's average speed based on a 10 km measurement section.

During execution, the program asks for an hour and minute and displays the number of vehicles passing the entry point at that time and the traffic intensity.

The generated fine list is saved to:

`C:\temp\fines.txt`

## Date

11 April 2026
