Weapons
=======

.. default-domain:: sphinxsharp

**Overview**

Weapons can be found on the ground within the level and can be picked up by touching the weapon. 
When the weapon is equipped, the weapon will appear beside the "ATTACK" button when the player goes 
into a battle, and will add additional strength to the player's attack power based on the strength of 
the weapon. When the player selects the "ATTACK" button, a short animation will happen where it will 
appear that the weapon (in this exmample case being a firearm) is firing and will show a short burst of 
ammunition fire from the gun before inflicting the attack on the enemy. 

The current weapons that can be found and equipped in the game are the AK-47 (strength=4) and the RPG-7 
Rocket Launcher (strength=7). When a player collides with a weapon, the code checks (in the FrmLevel that
the player is in) whether the strength of the new weapon is stronger than the strength of the current weapon
equipped by the player (if applicable). If the new weapon's strength is greater, than the new weapon is added
to the player's inventory and the player's former weapon is disguarded. Otherwise, the weapon is not picked up
by the player.


**How to Create a Weapon in a Level (+ an example)**

(For our example, we will create a pistol. The object will be named *pistol* and the image of the object will be named *pistolPic*)

* Gather an image to be used for your weapon and save the image to the following path: */Project/Fall2020_CSC403_Project/data/*

* Add the new weapon image to */Project/Fall2020_CSC403_Project/Properties/Resources.resx*

* Add a pictureBox item to your given level's designer. Assign the new weapon's image to it and rename it.

* In the level's code, create a new *private* variable of type *Weapon* at the top of the class.

.. code-block::

  private Weapon pistol;


* In the setup function of the level's code where all of the enemies are defined, define your new weapon and set the weapons strength.

.. code-block::

  pistol = new Weapon(CreatePosition(pistolPic), CreateCollider(pistolPic, PADDING));
  pistol.setStrength(3);


* In the *tmrPlayerMove_Tick* function, create a conditional statement using the *HitAChar()* function that will compare the player's current weapon strength and make the player pick up the new weapon if the new weapon's strength is greater than the current player's weapon's strength.

.. code-block::

  if (HitAChar(player, pistol)){
    if (player.WeaponStrength < pistol.getStrength()){
      player.WeaponStrength = pistol.getStrength();
      player.WeaponEquiped = 3; // i.d. number of the weapon
      pistolPic.Visible = false; // Hides the weapon image 
    }
  }


* In the *Setup* function of *FrmBattle.cs*, add a check to see if the new weapon is equipped so that the weapon that is equipped is shown when the player goes into battle.

.. code-block::

  if (player.WeaponEquiped == 3){
    weapon.Image = Resources.pistolPic;
  }

  
**Class Structure**

*public class Weapon*

Class Variables:

* *private int strength* - defines the weapons strength (defaults to 0 if not defined in initialization)

The only methods in this class are a getter and setter for the strength variable.


**Changes to the Code Base**

The changes to the code for weapons are as follows:

* Added the *Weapon Class* to the code base
* Added the class variables WeaponStrength and WeaponEquipped variables to the BattleCharacter class
* Added picture of weapon to the FrmBattle when the player has a weapon equipped
* Added a gunfire animation to FrmBattle when the player clicks "ATTACK" and a weapon is equipped
* Added the WeaponStrength variable to the AttackEvent in the BattleCharacter class
* Created the weapon in the FrmLevel
* Added checks within the FrmLevel code to check and see if the player has collided with the weapon object
* More than one weapon is availabe for use within the FrmLevels
* Weapon strength is compared to the player's weapon's strength when the player collides with a weapon on the level.
