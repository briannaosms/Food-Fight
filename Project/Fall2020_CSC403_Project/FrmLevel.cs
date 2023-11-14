﻿using Fall2020_CSC403_Project.code;
using MyGameLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
  public partial class FrmLevel : Level {
    public Player player;
    private Enemy enemyPoisonPacket;
    private Enemy bossKoolaid;
    private Enemy enemyCheeto;
    private Character[] walls;

    private Weapon ak;

    private DateTime timeStart;
    private FrmBattle frmBattle;
    private BossDefeatedWrapper bossIsDefeated = new BossDefeatedWrapper(false);

    public FrmLevel() : base() {
    //added this to keep track of whether or not the boss is defeated
      InitializeComponent();
    }
  
    private void FrmLevel_Load(object sender, EventArgs e) {

      //added this to keep track of which level has specifically been saved
      //to a file
      levelID = 1;

      const int PADDING = 0;
      const int NUM_WALLS = 13;

      player = new Player(
        base.CreatePosition(picPlayer), 
        base.CreateCollider(picPlayer, PADDING)
      );
      bossKoolaid = new Enemy(
        base.CreatePosition(picBossKoolAid), 
        base.CreateCollider(picBossKoolAid, PADDING),
        70
      );
      enemyPoisonPacket = new Enemy(
        base.CreatePosition(picEnemyPoisonPacket), 
        base.CreateCollider(picEnemyPoisonPacket, PADDING)
      );
      enemyCheeto = new Enemy(
        base.CreatePosition(picEnemyCheeto), 
        base.CreateCollider(picEnemyCheeto, PADDING),
        30
      );

      new GameState(player);
      timeStart = GameState.timeStart;

      //added these to keep track of which entity has been
      //saved to the file
      bossKoolaid.Name = "bossKoolaid";
      enemyCheeto.Name = "enemyCheeto";
      enemyPoisonPacket.Name = "enemyPoisonPacket";

      bossKoolaid.Img = picBossKoolAid.BackgroundImage;
      enemyPoisonPacket.Img = picEnemyPoisonPacket.BackgroundImage;
      enemyCheeto.Img = picEnemyCheeto.BackgroundImage;
      
      bossKoolaid.Color = Color.Red;
      enemyPoisonPacket.Color = Color.Green;
      enemyCheeto.Color = Color.FromArgb(255, 245, 161);

      ak = new Weapon(CreatePosition(weapon1), CreateCollider(weapon1, PADDING));
      ak.setStrength(4);
      ak.Name = "ak";

      walls = new Character[NUM_WALLS];
      for (int w = 0; w < NUM_WALLS; w++) {
        PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
        walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
      }

      Game.player = player;

      objectsToSave.Add(player);
      objectsToSave.Add(bossKoolaid);
      objectsToSave.Add(enemyCheeto);
      objectsToSave.Add(enemyPoisonPacket);
      objectsToSave.Add(ak);

      if (GameState.saveToLoadFrom != null)
      {
        LoadData(GameState.saveToLoadFrom);
      }
    }

    //private Vector2 CreatePosition(PictureBox pic) {
    //  return new Vector2(pic.Location.X, pic.Location.Y);
    //}

    //private Collider CreateCollider(PictureBox pic, int padding) {
    //  Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
    //  return new Collider(rect);
    //}

    private void FrmLevel_KeyUp(object sender, KeyEventArgs e) {
      player.ResetMoveSpeed();
    }

    private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
      if (!GameState.isGamePaused)
      {

        TimeSpan span;

        //GameState.totalPausedTime acts as a correcting factor for when
        //players pause the game
        /*if (GameState.saveTime != default(DateTime))
        {
          span = DateTime.Now.Subtract(GameState.saveTime) - GameState.totalPausedTime;
        }
        else
        {*/
          span = DateTime.Now - timeStart - GameState.totalPausedTime;
        //}
        string time = span.ToString(@"hh\:mm\:ss");
        lblInGameTime.Text = "Time: " + time.ToString();
      }
    }

    private void tmrPlayerMove_Tick(object sender, EventArgs e) {

      // move player
      player.Move();

      // check collision with walls
      if (HitAWall(player)) {
        player.MoveBack();
      }

      // check collision with enemies
      if (HitAChar(player, enemyPoisonPacket)) {
        Fight(enemyPoisonPacket);
      }
      else if (HitAChar(player, enemyCheeto)) {
        Fight(enemyCheeto);
      }
      if (HitAChar(player, ak)){
        player.WeaponStrength = ak.getStrength();
        player.WeaponEquiped = true;
        weapon1.Visible = false;
      }

      if (HitAChar(player, bossKoolaid) && bossIsDefeated.bossIsDefeated) {
        //this closes the current form and returns to main
        GameState.isLevelOneCompleted = true;
        GameState.levelToLoad = 2;
        GameState.NextLevel();
      }

      else if (HitAChar(player, bossKoolaid)){
        Fight(bossKoolaid);
      }

      // check state of each enemy
      if (!enemyPoisonPacket.IsAlive)
      {
        RemoveEnemy(enemyPoisonPacket, picEnemyPoisonPacket);
      }
      if (!enemyCheeto.IsAlive)
      {
        RemoveEnemy(enemyCheeto, picEnemyCheeto);
      }
      if (!bossKoolaid.IsAlive)
      {
        RemoveBoss(bossKoolaid, picBossKoolAid);
      }

      // update player's picture box
      picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
    }

    private bool HitAWall(Character c) {
      bool hitAWall = false;
      for (int w = 0; w < walls.Length; w++) {
        if (c.Collider.Intersects(walls[w].Collider)) {
          hitAWall = true;
          break;
        }
      }
      return hitAWall;
    }

    private bool HitAChar(Character you, Character other) {
      return you.Collider.Intersects(other.Collider);
    }

    private void Fight(Enemy enemy) {
      player.ResetMoveSpeed();
      player.MoveBack();
      frmBattle = FrmBattle.GetInstance(enemy, 1);
      frmBattle.Show();

      if (enemy == bossKoolaid) {

        // this gives the frmBattle object a reference to this level's bossIsDefeated bool
        frmBattle.bossIsDefeatedReference = this.bossIsDefeated;
        frmBattle.SetupForBossBattle(1);
      }
    }

    private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Left:
          player.GoLeft();
          break;

        case Keys.Right:
          player.GoRight();
          break;

        case Keys.Up:
          player.GoUp();
          break;

        case Keys.Down:
          player.GoDown();
          break;

        case Keys.Escape:
          FrmStartScreen.displayStartScreen();
          break;

        default:
          player.ResetMoveSpeed();
          break;
      }
    }

    private void RemoveEnemy(Enemy enemy, PictureBox picEnemy)
    {
      enemy.RemoveCollider();
      picEnemy.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.gravestone;
    }

    private void RemoveBoss(Enemy enemy, PictureBox picEnemy)
    {
            //enemy.RemoveCollider();
            picEnemy.BackgroundImage = null;
            picEnemy.Image = global::Fall2020_CSC403_Project.Properties.Resources.Nether_portal1;
            picEnemy.SizeMode = PictureBoxSizeMode.Zoom;
    }

    public override void LoadData(string fileName)
    {
      foreach (Character character in objectsToSave)
      {
        character.Load(fileName);
      }

      if (!player.WeaponEquiped)
      {
        player.WeaponStrength = ak.getStrength();
        player.WeaponEquiped = true;
        weapon1.Visible = false;
      }

      GameState.saveToLoadFrom = null;
    }
  }
}
