Experience
==========

.. note::
   This page is in development.

.. default-domain:: sphinxsharp

Overview
--------
Players gain experience after defeating enemies and level up after gaining a certain amount of experience.
Players also gain a strength bonus and heal a small amount after leveling up. The current iteration
of the experience system has these specific characteristics:

* Gain 10 experience points per defeated enemy
* Gain 1 level after earning 20 experience points
* Increase base damage dealt per attack by 2
* Increase the player's maximum health by 5
* Heal the player by 5 points

Details
-------
To setup the experience system, these key changes were made:

* the Player class was given a 'level' and 'experiencePerLevel' variable
* the BattleCharacter class was given a 'experience' variable
* the Player class was given a 'earnExperience' method

While FrmBattle is active, if the player defeats the enemy inside the 'btnAttack_Click' method, then the player's 'earnExperience' method is called.
The only argument that the method takes is the enemy's 'experience' variable. Inside the method, if the 'experience'
exceeds the 'experiencePerLevel' variable, then the following is done:

* 'experience' is set to 0
* 'level' is increased by 1
* 'maxHealth' is increased by 5
* 'Health' is increased by 5
* 'strength' is increased by 2

The 'experience' variable is reset to make it easy to calculate when the player needs to level up. Each of
the other variables are increased by a small amount to give the player some additional health and extra
strength so they can continue with the level.

