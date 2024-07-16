DISCLAIMER: This app doesnt work cause EF throws cannot translate query. More info in section 3.

1. DB
I will recomend to use some NoSQL DB server (e.g MongoDb) which are better to store and get aggregated data.

2. Serverless app (Azure Functions/Lambda)
This app is simulated with FunctionsController (cause I don't had time to create new project).
This function can be run daily eg. at midnight to aggregate daily Usage for Sim cards and store it in seperate table. 
Cause there is no need to read milions of entries from NetworkEvent table for reports each time.
Possible future actions: 
- Aggregate data per hours if daily would be to big.
- Remove or move old data from NetworkEvent table to improve searching

3. Queries
I did queries in EF but I haven't been using it for two years and I don't have more time to investigate it why it doesnt translate.
Probably it will work to just read data and do grouping on server in memory but it is not efficient at all and groupings should be done on sql server
using Stored Procedures or something similar in MongoDb and EF should only read and map results.
Alternative way could be to read data in batches and process but honestly I think first way should be faster ;)