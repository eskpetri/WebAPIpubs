# WebAPIpubs
I started a new project in Visual Studio Community 2022 (64-bit) - Current Version 17.3.5 and made DBcontext using EF core power tools (Extension for Visual Studio). 
Then added Controllers using Entity Framework automated code generation. It took half hours to create DB to SQL Server (from ready sql file), create DBcontext and 12 Controllers and test them using swagger.
11 Controllers for tables have Get all, Get one, Put one, Post one and Delete one - select, insert, update and delete. Only Discount tables Controller complained about null values. 
For 1 view there are Get all and Get one - select. View are fast way to bring data for usage of FrontEnd. Keep in mind that Entity Framework need primary keys to operate. Have to study a little bit more to know what else there are that can be made very efficiently.

If there are similar tools for FrontEnd like EF core power tools and Visual Studio autocode creation for Controller via Entity Framework. It would save a lot of typing.

Now I have spend same amount of time typing this readme compared to basic structure. 

# Links
MS pubs sample DB to SQL server and building a Web API to it. I am studying effiency and stuff relating to entity network and EF core power tools at the moment.
https://github.com/microsoft/sql-server-samples/tree/master/samples/databases

EF Core Power Tools - There are videos and other material on README.md
https://github.com/ErikEJ/EFCorePowerTools

# Notes to my self ----------------------------------------------------

Study Entity Framework performance and check out consept of read only(Reading are directed to different DB) ie Cosmos DB and writing is handled via entity framework and needs to be replicated at some point in time to Cosmos DB.
Second thing to study is what are EF capasity to deliver vs Manually writing SQL. When you can see the difference? Is it 20 000 or 100 000 maybe 500 000 row tables combined to same size other tables. 
I just know that this kind of Framework has limits but where they are in practise. In small systems EF is way to go where you don't need pessimistic database locking.
You can use both side by side ie do pessimistic database locking using sql and do other stuff using EF. EF supports optimistic locking of DB. 
