﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace Fall2020_CSC403_Project.code {
  public class Character {
    private const int GO_INC = 3;

    public Vector2 MoveSpeed { get; private set; }
    public Vector2 LastPosition { get; private set; }
    public Vector2 Position { get; protected set; }
    public Collider Collider { get; private set; }

    public Character(Vector2 initPos, Collider collider) {
      Position = initPos;
      Collider = collider;
    }

    public void Move() {
      LastPosition = Position;
      Position = new Vector2(Position.x + MoveSpeed.x, Position.y + MoveSpeed.y);
      Collider.MovePosition((int)Position.x, (int)Position.y);
    }

    public void MoveTo(float x, float y) {
      LastPosition = Position;
      Position = new Vector2(x, y);
      Collider.MovePosition((int) x, (int) y);
    }

    public void MoveBack() {
      Position = LastPosition;
    }

    public void GoLeft() {
      MoveSpeed = new Vector2(-GO_INC, 0);
    }
    public void GoRight() {
      MoveSpeed = new Vector2(+GO_INC, 0);
    }
    public void GoUp() {
      MoveSpeed = new Vector2(0, -GO_INC);
    }
    public void GoDown() {
      MoveSpeed = new Vector2(0, +GO_INC);
    }

    public void ResetMoveSpeed() {
      MoveSpeed = new Vector2(0, 0);
    }

    public void RemoveCollider()
    {
      Collider = new Collider(new Rectangle());
    }

    public virtual void Save(string fileName) { }
    public virtual void Load(string fileName) { }

    public void ChangeCollider(Collider col) {
      Collider = col;
    }
  }
}
