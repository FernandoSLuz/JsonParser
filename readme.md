#Json Parser code challenge

Description

Create a Unity project that reads a JSON file and shows a table on screen with the JSON data using Unity UI components

The JSON file describes a table with specified rows and columns. Rows and columns amount may vary, so the code should be flexible and instantiate UI components depending on the JSON file contents.

The table should display the column headers using a bold or bigger font, while all other table cells should just use normal font.

The JSON file will always be placed at Assets/StreamingAssets/JsonChallenge.json

-The application should be able to reload the JSON file and update the screen to display these changes. Use ether an onscreen button to reload the file or detect that it has been changed.
-Requirements / additional notes:
-Use Unity 2018.1 or later version
-Use the sample JSON to test, but do not count on it. Your code will be tested with other JSON content that may differ in the amount of columns, rows or data.
-There is no need to support scrolling vertically or horizontally.
-Write your processing code in C# scripts
-Do not spend time making the UI pretty. Just read the data and present it on screen.
-The process should run as a Standalone Desktop build (i.e, make sure to test creating a build and running it)
-Please deliver the full Unity project source.
