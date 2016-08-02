﻿namespace LiveSplit.OriDE {
	partial class OriManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OriManager));
			this.lblMap = new System.Windows.Forms.Label();
			this.lblPos = new System.Windows.Forms.Label();
			this.lblArea = new System.Windows.Forms.Label();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblHP = new System.Windows.Forms.Label();
			this.lblEN = new System.Windows.Forms.Label();
			this.lblXP = new System.Windows.Forms.Label();
			this.lblAbility = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblMap
			// 
			this.lblMap.AutoSize = true;
			this.lblMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMap.Location = new System.Drawing.Point(12, 9);
			this.lblMap.Name = "lblMap";
			this.lblMap.Size = new System.Drawing.Size(115, 20);
			this.lblMap.TabIndex = 4;
			this.lblMap.Text = "Total: 100.00%";
			// 
			// lblPos
			// 
			this.lblPos.AutoSize = true;
			this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPos.Location = new System.Drawing.Point(12, 49);
			this.lblPos.Name = "lblPos";
			this.lblPos.Size = new System.Drawing.Size(143, 20);
			this.lblPos.TabIndex = 5;
			this.lblPos.Text = "Position: 0.00, 0.00";
			// 
			// lblArea
			// 
			this.lblArea.AutoSize = true;
			this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblArea.Location = new System.Drawing.Point(12, 29);
			this.lblArea.Name = "lblArea";
			this.lblArea.Size = new System.Drawing.Size(161, 20);
			this.lblArea.TabIndex = 7;
			this.lblArea.Text = "Area: Sunken Glades";
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel.Location = new System.Drawing.Point(12, 69);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(80, 20);
			this.lblLevel.TabIndex = 6;
			this.lblLevel.Text = "Level: N/A";
			// 
			// lblHP
			// 
			this.lblHP.AutoSize = true;
			this.lblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHP.Location = new System.Drawing.Point(112, 69);
			this.lblHP.Name = "lblHP";
			this.lblHP.Size = new System.Drawing.Size(65, 20);
			this.lblHP.TabIndex = 8;
			this.lblHP.Text = "HP: N/A";
			// 
			// lblEN
			// 
			this.lblEN.AutoSize = true;
			this.lblEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEN.Location = new System.Drawing.Point(225, 69);
			this.lblEN.Name = "lblEN";
			this.lblEN.Size = new System.Drawing.Size(65, 20);
			this.lblEN.TabIndex = 9;
			this.lblEN.Text = "EN: N/A";
			// 
			// lblXP
			// 
			this.lblXP.AutoSize = true;
			this.lblXP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblXP.Location = new System.Drawing.Point(112, 89);
			this.lblXP.Name = "lblXP";
			this.lblXP.Size = new System.Drawing.Size(64, 20);
			this.lblXP.TabIndex = 10;
			this.lblXP.Text = "XP: N/A";
			// 
			// lblAbility
			// 
			this.lblAbility.AutoSize = true;
			this.lblAbility.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAbility.Location = new System.Drawing.Point(12, 89);
			this.lblAbility.Name = "lblAbility";
			this.lblAbility.Size = new System.Drawing.Size(84, 20);
			this.lblAbility.TabIndex = 11;
			this.lblAbility.Text = "Ability: N/A";
			// 
			// OriManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(354, 119);
			this.Controls.Add(this.lblAbility);
			this.Controls.Add(this.lblXP);
			this.Controls.Add(this.lblEN);
			this.Controls.Add(this.lblHP);
			this.Controls.Add(this.lblArea);
			this.Controls.Add(this.lblLevel);
			this.Controls.Add(this.lblPos);
			this.Controls.Add(this.lblMap);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OriManager";
			this.Text = "Ori Manager";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OriManager_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblMap;
		private System.Windows.Forms.Label lblPos;
		private System.Windows.Forms.Label lblArea;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblHP;
		private System.Windows.Forms.Label lblEN;
		private System.Windows.Forms.Label lblXP;
		private System.Windows.Forms.Label lblAbility;
	}
}