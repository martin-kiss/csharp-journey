# Vehicle Speed Control

Reads vehicle entry/exit timestamps from a measurement file, calculates average speeds, displays a few statistics, and generates a list of speeding fines.

## How to run

`measurements.txt` needs to exist at:

`C:\temp\measurements.txt`

The file should contain vehicle data in the following format:

```text
license plate entry hour/minute/second/ms exit hour/minute/second/ms
```

Example:

```text
ABC123 8 15 20 500 8 20 10 250
```

The program asks for an hour and minute during execution to calculate the traffic at that time.

The generated fine list is saved to:

`C:\temp\fines.txt`

## Date

Created in **10 April 2026**.
