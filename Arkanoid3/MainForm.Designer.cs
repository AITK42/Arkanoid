/*
 * Created by SharpDevelop.
 * User: Utilizador
 * Date: 24/06/2020
 * Time: 23:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Arkanoid3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menu = new System.Windows.Forms.GroupBox();
			this.exitbt = new System.Windows.Forms.Button();
			this.startbt = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.TimerLoopGame = new System.Windows.Forms.Timer(this.components);
			this.menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.Controls.Add(this.exitbt);
			this.menu.Controls.Add(this.startbt);
			this.menu.Location = new System.Drawing.Point(195, 341);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(393, 100);
			this.menu.TabIndex = 0;
			this.menu.TabStop = false;
			this.menu.Text = "Menu";
			// 
			// exitbt
			// 
			this.exitbt.Location = new System.Drawing.Point(159, 62);
			this.exitbt.Name = "exitbt";
			this.exitbt.Size = new System.Drawing.Size(75, 23);
			this.exitbt.TabIndex = 1;
			this.exitbt.Text = "Exit";
			this.exitbt.UseVisualStyleBackColor = true;
			this.exitbt.Click += new System.EventHandler(this.ExitbtClick);
			// 
			// startbt
			// 
			this.startbt.Location = new System.Drawing.Point(159, 19);
			this.startbt.Name = "startbt";
			this.startbt.Size = new System.Drawing.Size(75, 23);
			this.startbt.TabIndex = 0;
			this.startbt.Text = "Start";
			this.startbt.UseVisualStyleBackColor = true;
			this.startbt.Click += new System.EventHandler(this.StartbtClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(1, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(782, 560);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// TimerLoopGame
			// 
			this.TimerLoopGame.Enabled = true;
			this.TimerLoopGame.Interval = 40;
			this.TimerLoopGame.Tick += new System.EventHandler(this.TimerLoopTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.menu);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Arkanoid";
			this.menu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer TimerLoopGame;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button startbt;
		private System.Windows.Forms.Button exitbt;
		private System.Windows.Forms.GroupBox menu;
	}
}
