First open the project(EvolentHealth2) by click on EvolentHealth2.sln on Visual studio 2019.

Step1. First change the connection string in web.config file according to your sql server database.
Step2. Run the commands on package manager console 
Step3. Choose appropriate project while running the commands.

PM > enable-migrations

PM > add-migration initial

PM> update-database -verbose

Step4. Run the project.

---------------------------------

Project Flow:

Database <==> Web API(REST Service)  <==> Project
