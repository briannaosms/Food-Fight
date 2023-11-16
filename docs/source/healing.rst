Healing
=======

.. default-domain:: sphinxsharp


**Overview**

At the beginning of the game, the player has 3 healing items. A button that says "HEAL" as well as a 
counter for how many healing potions the player has will be displayed on the battle screen. When the 
player uses a healing potion, it will heal the player *1/2* health up to but not exceeding the player's 
max health. Health packs can also be picked up within the level. Once the player touches a health pack,
it will disappear from the level and the player's health pack inventory will be incremented by one.

**How to Add A Health Pack to a Level**

* On the designer of the level you want to add a health pack to, create a pictureBox, assign the health pack image (that is already contained in the Resources file), and rename the image (ex. healthPackImg9).
* In the level's code, create a new *private* variable of type *Character* at the top of the class.

.. code-block::

  private Character healthPack9;

* In the setup function of the level's code where all of the enemies are defined, define your new health pack (Character object) cooresponding to the image of the health pack that was created.

.. code-block::

  healthPack9 = new Character(CreatePosition(healthPackImg9), CreateCollider(healthPackImg9, PADDING));


* In the *tmrPlayerMove_Tick* in the level's code, add a conditional check using the *HitAChar()* function to see if the player collides with the health pack. If the condition is met, then the player gets a new health pack aand the health pack is removed from the level. 

.. code-block::

  if (HitAChar(player, healthPack9)){
    player.HealthPackCount++;
    healthPack9.RemoveCollider();
    healthPackImg9.Visible = false;
  }

**Changes to the Code Base**

The changes to the code for healing are as follows:

* Added a HealthPackCount variable which is initialized within the constructor of the BattleCharacter 
  class.
* Added a *useHealthPack()* class method to the BattleCharacter class that will decrement the 
  HealthPackCount by one every time that it is used.
* A "HEAL" button (and the related code to its function), an image of a health pack beside the "HEAL" 
  button, and a counter that pulls from HealthPackCount (which is updated every time the health bars 
  are updated) were added to the FrmBattle class and Designer files.
* The player can pick up a health pack from the level (health pack is represented as a Character object).
