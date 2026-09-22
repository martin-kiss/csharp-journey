# Vehicle Measurements

Reads vehicle license plates, timestamps, and measured speeds from a measurement file, then processes the data to display various statistics and calculate the distance traveled by a selected vehicle.

## How to run

The `jeladas.txt` file needs to exist at:

`C:\temp\jeladas.txt`

Each line should contain the following data, separated by tabs:

```text
license plate    hour    minute    speed
```

The program displays:

* The last recorded measurement
* The measurement times of the first vehicle
* The number of measurements at a given time
* The highest measured speed and the vehicles that reached it
* The calculated distance traveled by a selected vehicle

After processing the data, the program generates an `ido.txt` file containing the first and last recorded times for each vehicle.

The output file is saved to:

`C:\temp\ido.txt`

## Date

10 April 2026
