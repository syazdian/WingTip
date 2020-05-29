# WingTip
WingTip implemented with Angular 9 and ASP .net core Web Api 3.1

Extra Libraries uses in ASP.net core
  - Moq for unit testing.
  
Extra Library used in Angular:
  - Sweetalert2 for alert messages
  - Bootstrap 4
  
=============================================

For running the project:
1- Be sure you SQL Server is running and local machine already has Wingtiptoys Database 

2- If your SQL SERVER credentials is not Local machine (.), Open the WingTip.Web project  in visual Studio, and go to "appsetting.json"
and update the ConnectionString

3- Run the WingTip.Web project in visual Studio, with IIS it should run on the following port and address:
https://localhost:44345/product

4- open WingTip.Angular project and in the Terminal first run "npm i" to install the "node_module" folder
5- run "ng serve" and open "http://localhost:4200/"

Enjoy!

=============================================

For unit testing;

Run the WingTip.Web project in visual Studio, go to WingTip2.Core.UnitTest, 
and in "Services" folder you can run both files.
