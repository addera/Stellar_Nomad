namespace sharpshooter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.LevelNumLabel = new System.Windows.Forms.Label();
            this.HPLabel = new System.Windows.Forms.Label();
            this.HPNumLabel = new System.Windows.Forms.Label();
            this.GunLabel = new System.Windows.Forms.Label();
            this.GunNumLabel = new System.Windows.Forms.Label();
            this.menuBackground = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 25;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainmenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainmenu
            // 
            this.mainmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem});
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(61, 20);
            this.mainmenu.Text = "Options";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.resetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ModernBlck", 26.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(334, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Play";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.Black;
            this.levelLabel.ForeColor = System.Drawing.Color.White;
            this.levelLabel.Location = new System.Drawing.Point(29, 544);
            this.levelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(46, 16);
            this.levelLabel.TabIndex = 3;
            this.levelLabel.Text = "level ";
            this.levelLabel.Visible = false;
            // 
            // LevelNumLabel
            // 
            this.LevelNumLabel.AutoSize = true;
            this.LevelNumLabel.BackColor = System.Drawing.Color.White;
            this.LevelNumLabel.Location = new System.Drawing.Point(82, 544);
            this.LevelNumLabel.Name = "LevelNumLabel";
            this.LevelNumLabel.Size = new System.Drawing.Size(16, 16);
            this.LevelNumLabel.TabIndex = 4;
            this.LevelNumLabel.Text = "1";
            this.LevelNumLabel.Visible = false;
            // 
            // HPLabel
            // 
            this.HPLabel.AutoSize = true;
            this.HPLabel.ForeColor = System.Drawing.Color.White;
            this.HPLabel.Location = new System.Drawing.Point(650, 544);
            this.HPLabel.Name = "HPLabel";
            this.HPLabel.Size = new System.Drawing.Size(29, 16);
            this.HPLabel.TabIndex = 5;
            this.HPLabel.Text = "HP";
            this.HPLabel.Visible = false;
            // 
            // HPNumLabel
            // 
            this.HPNumLabel.AutoSize = true;
            this.HPNumLabel.BackColor = System.Drawing.Color.White;
            this.HPNumLabel.Location = new System.Drawing.Point(685, 544);
            this.HPNumLabel.Name = "HPNumLabel";
            this.HPNumLabel.Size = new System.Drawing.Size(24, 16);
            this.HPNumLabel.TabIndex = 6;
            this.HPNumLabel.Text = "25";
            this.HPNumLabel.Visible = false;
            // 
            // GunLabel
            // 
            this.GunLabel.AutoSize = true;
            this.GunLabel.ForeColor = System.Drawing.Color.White;
            this.GunLabel.Location = new System.Drawing.Point(205, 544);
            this.GunLabel.Name = "GunLabel";
            this.GunLabel.Size = new System.Drawing.Size(35, 16);
            this.GunLabel.TabIndex = 7;
            this.GunLabel.Text = "Gun";
            this.GunLabel.Visible = false;
            // 
            // GunNumLabel
            // 
            this.GunNumLabel.AutoSize = true;
            this.GunNumLabel.BackColor = System.Drawing.Color.White;
            this.GunNumLabel.Location = new System.Drawing.Point(246, 544);
            this.GunNumLabel.Name = "GunNumLabel";
            this.GunNumLabel.Size = new System.Drawing.Size(34, 16);
            this.GunNumLabel.TabIndex = 8;
            this.GunNumLabel.Text = "N/A";
            this.GunNumLabel.Visible = false;
            // 
            // menuBackground
            // 
            this.menuBackground.Image = ((System.Drawing.Image)(resources.GetObject("menuBackground.Image")));
            this.menuBackground.Location = new System.Drawing.Point(157, 95);
            this.menuBackground.Name = "menuBackground";
            this.menuBackground.Size = new System.Drawing.Size(427, 418);
            this.menuBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuBackground.TabIndex = 9;
            this.menuBackground.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuBackground);
            this.Controls.Add(this.GunNumLabel);
            this.Controls.Add(this.GunLabel);
            this.Controls.Add(this.HPNumLabel);
            this.Controls.Add(this.HPLabel);
            this.Controls.Add(this.LevelNumLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "A_Window";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainmenu;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label LevelNumLabel;
        private System.Windows.Forms.Label HPLabel;
        private System.Windows.Forms.Label HPNumLabel;
        private System.Windows.Forms.Label GunLabel;
        private System.Windows.Forms.Label GunNumLabel;
        private System.Windows.Forms.PictureBox menuBackground;
    }
}

