1. Open Nuget Project Manager
2. Run: update-database from PM>
	-- This creates the GuildCars Database and the AspnetUsers,AspnetUserRoles, AspnetRoles tables and sets up initial users and roles.
3. Run SQL script : Tables.sql 
4. Run SQL Script : Sprocs.sql
5. dbReset stored proc should run automatically. If you have no data,then run this proc.

NOTE:
There are picture files to use for testing in the ReadMe folder.

Do not upgrade to latest bootstrap. This causes formatting issues with the screen layout that has yet to be worked out for the new version.
