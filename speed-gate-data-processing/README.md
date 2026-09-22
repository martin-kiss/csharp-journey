Reads vehicle entry/exit timestamps from a measurement file, works out 
average speeds, prints a few stats (fastest vehicle, share of 
speeders, traffic at a given time), and writes a fine list to a 
separate output file.

## How to run
measurements.txt needs to exist at C:\temp\measurements.txt, formatted 
as: license plate, entry hour/minute/second/ms, exit 
hour/minute/second/ms. Running the program writes the results to 
C:\temp\fines.txt.
