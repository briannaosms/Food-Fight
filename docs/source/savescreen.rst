Save / Pause Screen
===================
Overview
--------
The 'FrmStartScreen' is used as the first screen that the user sees when they load they game and as
the screen that users see when they pause the game. It has these characteristics:

* Really cool, cash-money animations
* A start button
* A controls button
* An exit button
* Input fields for loading and saving games

How to Use the Start Screen during the Level
--------------------------------------------
To use the pause screen, the level's 'FrmLevel_KeyDown' has to be editted to account for the keyboard's
escape key. The following snippet shows the case that has to be added to the method's switch statement:

.. code-block:: c#

	case Keys.Escape:
		FrmStartScreen.displayStartScreen();
		break;

The 'FrmStartScreen.displayStartScreen()' is what is used to display the screen during the level. Since the 
new window automatically gains focus, the game effectively pauses. While the window is displayed, the 
'GameState.isGamePaused' variable gets set to true. This causes this 'tmrUpdateInGameTime_Tick' function
for the level to not update the time. Once the window is closed when the user clicks the 'continue' button,
then the 'GameState.totalPausedTime' is set to how long the window was displayed for. This helps to adjust
the game's timer so it accounts for pause time. 

Saving and Loading
------------------
The game can be saved only while users are in a level. However, the game can be loaded at anytime during play.
After the save and load buttons check for input text, they call the 'GameState.SaveGame()' and 'GameState.LoadGame()'
functions. See the documentation on saving and loading the game to see what these functions do.

Animations
----------
The animations were achieve by using this snippet of code in the constructor:

.. code-block:: c#

	System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
	timer1.Interval = 1000;
	timer1.Tick += new System.EventHandler(timer1_Tick);
	timer1.Start();

This just calls the 'timer1_Tick' function every 1 second. The 'timer1_Tick' function just changes
the visibility of some the screen's images each time it is called.


