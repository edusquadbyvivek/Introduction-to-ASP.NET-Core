Here are the Instructions to build & run the Application.
I have implemented the Employee Module with the crud operations.
Application supports both Inmemory & SQLmemory data integration using Entity framework Core.
Right now application is running on InMemory Data.
In case of running the application aganist SQL Server, Please follow the below steps.
	Go to the startup.cs file
	Uncomment the line 40 & comment the line 38.
	Go to the appsettings.json file & change the valid connection string.
	Now you need to run the EF Core migration command as below.
	Open the command prompt, go to folder TTAssingment.Data & Run 'dotnet ef database update -s ..\TTAssignment\TTAssignment.csproj'

Application has user Authentication with my Azure Active directory.
Please write an email to edusquadbyvivek@gmail.com in order to get the password.
