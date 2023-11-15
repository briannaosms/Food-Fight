Saving and Loading
==================

The start and pause screen have text fields for creating and loading a save file. Save files are .csv files
(currently stored in the default run location for the Visual Studio project). A save file is made for each
of the following:

* the Player object
* Enemy objects
* Necessary level information 

How to Save and Load a Game During a Playthrough
------------------------------------------------
Players can save and load the game by using the corresponding text fields on the pause or start screen. Players
can override previous saves by simply entering the name of a previous save. Players can load a game at any
time during their playthrough.

Creating the .csv Files
-----------------------
The .csv files contain each entities' variables and corresponding values separated by commas. Each
variable is separated by a new line. In 'GameState.SaveGame', the following is done to successfully create all of the files:

* Check to verify that a save can be created in the specified path

* Create a file with the '_level.csv' extension to store level information (currently this information):

	* level name

	* health pack count

	* start time of the saved game

* Create a .csv file for each Player and Enemy object containing their variables using the entities' '.Save()' method

The Character class contains a virtual method called 'Save()' that is overriden in the Player and Enemy class.
The Player stores these variables using their 'Save()' method:

* Health
* MaxHealth
* strength
* experience
* HealthPackCount
* WeaponStrength
* WeaponEquipped
* Position.x
* Position.y

The Enemy stores these variables using their 'Save()' method:

* Health
* MaxHealth
* strength
* experience
* IsAlive

Loading the Level
-----------------
Each Player and Enemy implements their own version of the 'Load()' function too. The following is done to
read the .csv files for each entity:

* Read the lines from the file into a hashtable
* Retrieve the value from the hashtable and convert it to the appropriate type.

Each load function retrieves the same variables listed in the section on creating the .csv files. 

Each level also has a function called 'LoadData()'. This function is called after initializing everything
in the level at the bottom of the 'FrmLevel_Load()' function. Each level has a list called 'objectsToSave', which
just contains a reference to every object that needs to be loaded.

Each 'LoadData()' function in the levels does the following:

* Iterate through the 'objectsToSave' list and call the object's 'Load()' function
* cleanup weapons and health packs based on information just loaded.
* Set 'GameState.saveToLoadFrom' equal to null to avoid loading a level again