﻿namespace Fall2020_CSC403_Project
{
  partial class FrmStartScreen
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.button1.Location = new System.Drawing.Point(471, 494);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(98, 41);
      this.button1.TabIndex = 1;
      this.button1.Text = "Start";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.button2.Location = new System.Drawing.Point(716, 494);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(98, 41);
      this.button2.TabIndex = 2;
      this.button2.Text = "Exit";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(463, 133);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(351, 45);
      this.label2.TabIndex = 4;
      this.label2.Text = "Food-Fight: The Game";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.button3.Location = new System.Drawing.Point(591, 494);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(98, 41);
      this.button3.TabIndex = 5;
      this.button3.Text = "Controls";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label1.Location = new System.Drawing.Point(885, 153);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(250, 362);
      this.label1.TabIndex = 6;
      this.label1.Text = "Controls:\r\n\r\nArrow keys: move around the level\r\nMouse 1: interact with buttons\r\nE" +
    "scape: display the pause menu\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
      this.label1.Visible = false;
      // 
      // FrmStartScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Khaki;
      this.ClientSize = new System.Drawing.Size(1280, 640);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Name = "FrmStartScreen";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label1;
  }
}