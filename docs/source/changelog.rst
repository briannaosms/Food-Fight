Changelog
=========

.. note::
   Once you have completed your feature implementation and documentation, please update
   the changelog according to the existing format (your user, user story/major task 
   description, and pull request in each bullet point). 

Version 1.0.0
-------------
**Date:** 16 November 2023

**Features:**

- `@Jonah`_: Added a save and load feature for creating save states (`#11 <https://github.com/briannaosms/Food-Fight/pull/17>`_)
	
	- Players can create a new save file from the pause screen while playing
	- PLayers can load previous games from a save file from the start screen or pause screen

- `@Jonah`_: Added a start and pause screen (`#11 <https://github.com/briannaosms/Food-Fight/pull/17>`_)
	
	- A start screen is displayed when the game starts
	- The player can use the escape key to pause the game and see the menu again

- `@Brianna`_: Added a third level to the game (`#23 <https://github.com/briannaosms/Food-Fight/pull/23>`_)
	
	- Added new environment with walls and obstacles
	- Added enemies and new battle assets
	- Create new win screen ``FrmWinLevelThree.cs`` after the player defeats the last boss 

- `@Kennedy`_: Added more weapons and health packs to the levels. (`#20 <https://github.com/briannaosms/Food-Fight/pull/20>`_) 

- `@Luke`_: Added a flee button to FrmBattle.cs (`#18 <https://github.com/briannaosms/Food-Fight/pull/18>`_)

	- Added to flee button to FrmBattle designer
	- When button is clicked, the player have a fifty percent chance for the flee to succeed
	- If the flee succeeds, the FrmBattle window closes
	- If the flee fails, the flee button become inoperable

- `@Luke`_: Added various sounds to all three levels (`#21 <https://github.com/briannaosms/Food-Fight/pull/21>`_)

	- In some Forms, a function was added to initialize all sounds in the Form
	- Sounds are in .wav formats, located in the project's properties
	- Sounds are called into variables, loaded, then played

**Bug Fixes:**

- `@Brianna`_: Fix ``OutOfMemory Exception`` when exiting the game on Level 2 (`#23 <https://github.com/briannaosms/Food-Fight/pull/23>`_)

	- Redesigned Level 2 and Level 3 to have significantly less ``Character`` objects to reduce memory usage


Version 0.1.0
-------------
**Date:** 24 October 2023

**Features:**

- `@Brianna`_: Added a park themed level with different assets (`#12 <https://github.com/briannaosms/Food-Fight/pull/12>`_)

	- Created new enemies and boss enemy	
	- Added obstacles to interfere with player walkway

- `@Jonah`_: Added player win condition when boss is defeated (`#11 <https://github.com/briannaosms/Food-Fight/pull/11>`_)
	
	- A level win screen is displayed upon defeating the level boss
	- The boss is replaced with a portal to the next level after the boss's defeat
	- Player cannot move to next level without beating the current level's boss

- `@Luke`_: Added player lose condition when player dies (`#10 <https://github.com/briannaosms/Food-Fight/pull/10>`_)

	- Designed Restart screen for when IsAlive is false
	- When "Yes" button is clicked, application restarts
	- When "No" button is clicked, environment is closed

- `@Brianna`_: Setup fully functional documentation using ReadTheDocs and Sphinx (`#5 <https://github.com/briannaosms/Food-Fight/pull/5>`_)
- `@Brianna`_: Added documentation configuration files (`#4 <https://github.com/briannaosms/Food-Fight/pull/4>`_)
- `@Kennedy`_: Added healing system and weapons system (`#3 <https://github.com/briannaosms/Food-Fight/pull/3>`_)
- `@Jonah`_: Added experience system (`#2 <https://github.com/briannaosms/Food-Fight/pull/2>`_)

	- Enemies give player experience
	- Player scales in health and strength as they level up
	- Added experience and level interface

**Bug Fixes:**

- `@Luke`_: Enemies disappear after defeat (`#7 <https://github.com/briannaosms/Food-Fight/pull/7>`_)
	
	- Added "IsAlive" variable to character class
	- Added function that turns off enemy pictures when IsAlive is false

- `@Brianna`_: Fixed level textures scaling (`#6 <https://github.com/briannaosms/Food-Fight/pull/6>`_)
- `@Brianna`_: Fixed crash when battle window closes (`#1 <https://github.com/briannaosms/Food-Fight/pull/1>`_)

.. _@Brianna: https://github.com/briannaosms
.. _@Kennedy: https://github.com/kennedyford
.. _@Jonah: https://github.com/jonahf0
.. _@Luke: https://github.com/ldm04


Version 0.0.0
-------------
**Date:** 19 October 2023

* Original `code base`_ assigned

.. _code base: https://github.com/kcherr1/Fall2020_CSC403_Project