# NormalChart

WinCC Advanced DataLog APP

![Image](/ScreenShots/1.jpg?raw=true)

![Image](/ScreenShots/2.jpg?raw=true)

With this you can:
- Log data using custom intervals or events inside PLC
- View data as table or chart
- Select date time and range for data
- Compare multiple charts
- Export data as CSV or Image

### Prerequisites

- WinCC flexible or advanced
- MSSQL Server
- Basic knowledge of VBA script

### Installing

Don't need to install just copy files to your work directory. You need 3 files

- ZedGraph.dll
- NormalChart.exe
- DBSetup.sql

a short video about setup
https://www.youtube.com/watch?v=3uZ70vLMB6w


## Getting Started

Download example project
https://drive.google.com/file/d/1IflmZVjEgmpi-la_DUQGQ_xlvKRZd5pj/view

Command line arguments\
-l <curveID1,curveID2,curveID3>  example NormalChart.exe -l 1,2 will load datalog with ID 1 and 2
-b  start program without window controls(borderless)\
-r <range_value> start programm with defined time range\
 0(default) - 15min\
 1 - 30 min\
 2 - 1 Hour\
 3- 12 Hours\
 4- 1 Day
 

## License

This project is licensed under the MIT License 

