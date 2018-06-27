# Customer_Module
Please Download the Customer_Module Repository.

Unzip the folder.

In Customer folder (inside Customer_Module) you can see Customer.sln, Open this, which will open the application in Visual Studio(Any From 2015 or newer).


In Customer Application there is a folder CustomerClasses,which is having the Class Containing the whole logic for Insert,Update and Deletion of Data.

Form1.cs - you can see how the page will look like.

App.config File is having Connection String,which will connect our appilaction to MS SQL server 2014 or any.

To Connect the application you can go through these Steps -->ServerExplorer --> Data Connection --> rightclick --> Add New Connection -->Add Server name(which should appear in dropdown) --> Select Database (which you should have from the Database Repository named Customer.mdf having tbl_Customer) --> Click ok.

Now right click on the added Server connection --> In properties you can see the Connection String.

Copy that Connection String --> Paste in App.config file (In Application currently its having connection string which i was using, You must enter your connection string in order to connect application with SQL Server).

Now can see it after running , I am using Customer ID as a Primary key, so user can only read this and can not write anything in this field.

The other Fields are very similar to what was required, Name,Surname,Contact Number, Address. User can Add new Customer using Create button , can Update the Details Of Customer after selcting a particular Customer from the GridView, and also can Delete the Customer after selectiong a specific customer from GridView.

User can close Form using the close button which is appear on top rightmost corner.
