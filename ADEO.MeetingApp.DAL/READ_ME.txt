Please run below command in Package manager console, if migrations are not present or fresh migration needs to be created.

Please also select "ADEO.MeetingApp.DAL" as Default project in Package manager console 

		Add-Migration initialDatabaseCreation
		update-database

You may also use the dummy data for Attendees table listed in file "Attendees_DummyData.txt"
