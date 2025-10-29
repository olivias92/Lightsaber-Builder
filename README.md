# Lightsaber-Builder

NOTE: Please read this section or the .txt readme before running this application as problems may occcur

I.	Running the application
1.	Please do NOT build the solution. Do not run “clean solution” or “build” in any form. This will cause Visual Studio to “lock out” the entire folder due to permission problems.
2.	Navigate to the following sub folder of the solution (below) and run the “CapProject.sln” in Visual Studio 2022
<img width="752" height="382" alt="image" src="https://github.com/user-attachments/assets/c2c16b68-51bd-4b4e-826f-c5baa56138e0" />

3.	Once the project is open, do not run it yet. You must first rebuild the database and migration
a.	Navigate to the View tab and select “SQL Server Object Explorer”

<img width="500" height="426" alt="image" src="https://github.com/user-attachments/assets/d0ea9708-8ae9-4fd3-bb25-cf769824b79b" />

b.	Navigate through the dropdowns as shown below. If there is a database named “LightsaberDB,” right-click on it and delete the database
<img width="397" height="423" alt="image" src="https://github.com/user-attachments/assets/941e2534-c747-4a8c-8218-f61bb26926bc" />

 
c.	If the database wasn’t present, move to step 4. If it was, right-click on the Migrations folder in Solution Explorer and delete it as well as shown

 <img width="395" height="540" alt="image" src="https://github.com/user-attachments/assets/34680645-1ca8-4fe3-b306-d026aa0187d0" />


4.	Once this is done, the database and migrations can be rebuilt
a.	Navigate to the Tools > NuGet Package Manager > Package Manager Console

<img width="827" height="386" alt="image" src="https://github.com/user-attachments/assets/f47019ee-7138-414d-9692-0af3506d0cda" />


b.	In the NuGet Console, run the following commands in this order: 

i.	PM> Add Migration-Initial

ii.	PM> Update-Database

c.	After this, the database and migrations have been successfully rebuilt

5.	Reinstall Node.js
   
a.	Note this is in case errors occur or nodule_modes is missing from the folders

b.	In NuGet Package Manager Console run the following:

i.	PM> npm install

6.	Run the program by selecting the “https” button at the top

a.	If an error occurs at first with connect issues, run in another browser or accept the risk

b.	You may select a browser of your choice by selecting the dropdown next to the “https” button, and then web browser

7.	The application should now run as needed and look as shown below

   <img width="846" height="446" alt="image" src="https://github.com/user-attachments/assets/7d6e7f2e-1254-4432-b464-524c2bea7ba1" />

 
II.	About the Project
This project is organized using the ASP.NET Core Model-View-Controller (MVC) Framework with C# Razor code. It also includes the following:

  •	HTML/CSS
  
  •	JavaScript
  
  •	Three.JS
  
  •	Git (only for backup purposes and testing)
  
  •	SQL
  
The format of MVC are as follows:

•	Web pages (HTML/CSS/JS/Razor) are included in the Views folder

•	Contextual classes for database functions and other are included in the Models folder (C# 

o	Additionally for certain data transfers in the webpages, a ViewModel folder holds a file for better functionality with this

•	Files that controller redirections and some error handlings are included in the Controllers folder (C#)

Additional folders and files are as follows:

•	The Migrations folder holds database related code

•	The wwwroot folder contains the following:

•		Basic VS function folders (css, favicon.ico)

•		The js folder for all JavaScript files (including Three.JS)

•		The lib folder for popper.js and Bootstrap files

III.	Functions and Methods Used

With the languages and tools mentioned previously, this project does CURD operations (Create, Update, Read, and Delete) using a local database. The user will go through the following prompts in creating an object:

  •	Enter a name
  
  •	Select an Emitter component
  
  •	Select a Switch component
  
  •	Select a Hilt component
  
  •	Select a Pommel component
  
  •	Select a color of the blade
  
Together, these prompts create a new Lightsaber object in the database that the user can retrieve to edit or delete as they wish.

Images of each page will be shown in section V(See PDF readme for section V).

In the Controllers: The user’s inputs for each prompt are stored in sessions created by the application for access between pages. In both the creating and editing version of this, data is taken from the database and stored in the ViewModel for easier access/fallback options to ensure data is correct. Helper methods for populating dropdown menus are used as well.

In the Models: Variables are defined in Lightsaber.cs and Componenet.cs for fields in the database. To allow combinations of these two entities for better database functionality, there is the LightsaberComponent.cs file. For database implementation and seed data, there is the LightsaberContext.cs file.

In the Views: There are three files, Home, NewBuilds, and MyBuilds. Each of these folders corresponds to their own controller in the Controllers folder. Home holds simple pages such as home, help, and about. NewBuild holds all pages needed to create a Lightsaber object. The MyBuilds folder holds edited versions of the NewBuild pages along with a page to view all builds and options with them.



IV.	Developer’s Note

I will be the first to admit that this project is far from perfect in many ways. This application has bugs and errors, some of which I may not even know about. However, using what I have learned over the past two years has well equipped me for the progress that I’ve made this semester. 
I plan to update and improve this application over time, with more features in mind. Regardless of what the outcome will be, this semester’s work will be the foundation for the improvements that will make to this project and many others in the future.
I have been fond of both coding and the Star Wars Universe since high school and will continue to be for many years. This project is the outcome of that fondness. I hope you enjoy it as much as I’ve enjoyed making it.



