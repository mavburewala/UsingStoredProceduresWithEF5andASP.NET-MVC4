UsingStoredProceduresWithEF5andASP.NET-MVC4
===========================================
This report covers personal approach for implementing functional requirements of the application


Application Requirements:
1.	To create ASP.NET MVC application
Status:
As was required I created ASP.NET MVC 4 Application.  Moreover, I wrote Stored procedures for database handling. After that, I tested the web application on Chrome. Complete solution stack is:
•	SQL Server-built in Visual Studio 2012
•	Entity Framework 5(for LINQ to SQL)
•	Web API 1.0
•	Autofac 3.3.0 (for DI/IoC implementation)
•	Bootstrap 2.3.2 (for UI design)
•	AngularJs 1.2.9 (For making JavaScript Single page application-used for Add-Service feature)
•	JQuery 2.0 (Bootstrap depends on it)

NOTE:  [Complete project is attached as Visual Studio 2012 solution files, with text file containing all store procedures]



Functional Requirements:
1.	Search for a customer by name or postcode
2.	Select a customer to view their details
3.	List of all customers, their vehicles and services
4.	Enter a new service detail for a customer

I merged second and third functional requirements into one feature that is to get details of all customers or specific customer by providing customer-id. So now there are three main features of the application

Search for a customer by name or postcode
 This feature is provided on home page of the application.  You will find three fields (forename, surname, and postcode) to search for. You may search for customer based on any of these three or all of three. Incase, you leave all fields empty, search will return all customers.  On clicking on Search, data is posted to it’s own controller by “POST” call. 


Get Customer(s) Details
As mentioned above, this feature fulfills two functional requirements.(2nd, 3rd). If you provide it with some valid customer-id, it will return all details of the customer (his/her vehicles and their services), otherwise it will return all customers with their details. UI of this feature page needs refinement, I admit. 

Add Service
 This feature is being provided as Single-Page JavaScript application.  I used AngularJs here to show my familiarity with the framework. Though I confess I must have organized the JavaScript code instead of putting it in same file as of html code. On entering Service details, an ajax call is made to Web API controller via $http service of AngularJs. 
