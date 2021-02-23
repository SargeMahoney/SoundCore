# SoundCore
 Rehearsal Room Management

 Open Source studio-application to put into practice the Clean Architecture.
 
This application is created with the aim of managing the appointments of a rehearsal room and the respective rooms.

The first version must have a scheduler for entering / editing / viewing appointments and a page for viewing / adding / editing new rooms.

Project Structure:

CORE Folder: 
	- Project Domain : for all the domain entities
	- Project Application: for all the domain logics and contracts

Infrastructure Folder:
	- Project Persistance: all the contracts implementation about persistance (repositories will be here)
	- Project Infrastructure:  all the contracts implementation about third part services like exporting data or sending notifications

App Folder:
	- TODO - will be a blazor application ( server and client)

Will be used:
	- Framework 5.0
    - Automapper
	- Dapper
	- Serilog
	- MediatR
	- Blazor Syncfusion Packets (for UI)
	- xUnit tests
	- Moq
	- Shoudly


THIS PROJECT IS OPEN SOURCE AND IS SUITABLE FOR TESTING. FEEL FREE TO CONTRIBUITE OR OPEN ISSUES.
BEGGINER-FRIENDLY!