
namespace FlyGame
{
    partial class MainForm
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
            this.startControl = new FlyGame.StartControl();
            this.battleControl = new FlyGame.BattleControl();
            this.SuspendLayout();
            // 
            // startControl
            // 
            this.startControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.startControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startControl.Location = new System.Drawing.Point(0, 0);
            this.startControl.Name = "startControl";
            this.startControl.Size = new System.Drawing.Size(1720, 900);
            this.startControl.TabIndex = 0;
            // 
            // battleControl
            // 
            this.battleControl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.battleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.battleControl.Location = new System.Drawing.Point(0, 0);
            this.battleControl.Name = "battleControl";
            this.battleControl.Size = new System.Drawing.Size(1720, 900);
            this.battleControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 900);
            this.Controls.Add(this.battleControl);
            this.Controls.Add(this.startControl);
            this.Name = "MainForm";
            this.Text = "ХУЙ";
            this.ResumeLayout(false);

        }

        #endregion

        private StartControl startControl;
        private BattleControl battleControl;
    }
}