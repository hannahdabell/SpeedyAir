# SpeedyAir
To add a different json file, you need to change the OrderFileLocation in Helpers/OrderFileProcessor.cs, line 18.

As this doesn' t use a database (at time of writing) we have the Helpers/DataProvider that has any relevant hard coded test data in it. 
The departure airports, for now, are all hardcoded to YUL but the code has been written to allow this to change and the outputs will not need amending.

There is some code in here that isn't used right now, I wrote it when I was fleshing out the project and as there may be opportunity to add to this later, I wanted to save it in case it was helpful for that.