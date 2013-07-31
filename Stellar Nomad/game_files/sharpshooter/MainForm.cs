using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sharpshooter
{
    public partial class MainForm : Form
    {
        public static Player Player1 = new Player(new PointF(1000, 1000));
        public static List<Soldier> enemyList;
        Graphics windowsGraphics;
        Graphics onScreenGraphics;
        Bitmap screen;
        public static List<Bullet> bulletList;
        public static List<Wall> wallList;
        public static List<Explosion> explosionList;
        public static List<Wepon> weponList;
        public static List<AutoGunner> autoGunnerList;
        public Picture gameOverScreen;
        public Picture victoryScreen;
        public static Point veiwOffSet;
        public static SoundEngin sound;
        public static int levelNum = 1;
        public static String[] levelMap;
        public static int blockSize = checkConfig("block size");
        

        public MainForm()
        {
            InitializeComponent();
            windowsGraphics = this.CreateGraphics();
            this.Paint += new PaintEventHandler(DrawGame);
            screen = new Bitmap(this.Width, this.Height);
            onScreenGraphics = Graphics.FromImage(screen);
            sound = new SoundEngin(this);
            Init();
        }

        public static int checkConfig(String toFind)
        {
            toFind = toFind + ": ";
            System.IO.StreamReader configFile = new System.IO.StreamReader(Directory.GetCurrentDirectory() +  "/config.txt");
            string inputString = "*not null yet ";
            while (inputString != null)
            {
                inputString = configFile.ReadLine();
                inputString.Trim();
                if (inputString.StartsWith(toFind))
                {
                    configFile.Close();
                    return(Convert.ToInt16(inputString.Substring(toFind.Length, inputString.Length - toFind.Length)));
                }
            }
            configFile.Close();
            return (1);
        }

        void Init()
        {

            LevelNumLabel.Visible = true;
            levelLabel.Visible = true;
            GunNumLabel.Visible = true;
            GunLabel.Visible = true;
            HPNumLabel.Visible = true;
            HPLabel.Visible = true;

            Level.createLevel();

            Player1.HP = Player1.startHP;
            LevelNumLabel.Text = levelNum + "";
            HPNumLabel.Text = Player1.HP + "";

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Player1.KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Player1.KeyUp);
            
            gameOverScreen = new Picture("Images/GameOver.png", new PointF(this.Width / 2, this.Height / 2), 1, 1);
            victoryScreen = new Picture("Images/Victory.png", new PointF(this.Width / 2, this.Height / 2), 1, 1);

            //sound.playBGM("Sounds/ShadowRock.mp3");
        }

        public void DrawGame(Object sender, PaintEventArgs e)
        {
            if(!gameTimer.Enabled)
            {
                return;
            }
            onScreenGraphics.Clear(Color.Black);
            Player1.Draw(onScreenGraphics);
            HPNumLabel.Text = Player1.HP + "";
            foreach (Soldier s in enemyList)
            {
                s.Draw(onScreenGraphics);
            }

            foreach (Bullet b in bulletList)
            {
                b.Draw(onScreenGraphics);
            }
            foreach (Wall b in wallList)
            {
                b.Draw(onScreenGraphics);
            }
            foreach (Explosion ex in explosionList)
            {
                ex.Draw(onScreenGraphics);
            }
            foreach (Wepon w in weponList)
            {
                w.Draw(onScreenGraphics);
            }
            foreach (AutoGunner ag in autoGunnerList)
            {
                ag.Draw(onScreenGraphics);
            }
            if (Player1.killed == true)
            {
                gameOverScreen.Draw(onScreenGraphics);
            }
            if (enemyList.Count == -1) // level will not advance
            {
                levelNum += 1;
                LevelNumLabel.Text = levelNum + " ";
                Level.createLevel();
                if (levelNum > 2)
                {
                    victoryScreen.Draw(onScreenGraphics);
                }
            }
            windowsGraphics.DrawImage(screen, new PointF(0, 0));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Player1.Update(gameTimer.Interval);
            GunNumLabel.Text = Player1.currentWepon.name;
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(gameTimer.Interval);
                if (enemyList[i].killed)
                {
                    enemyList.RemoveAt(i);
                }
            }
            
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update(gameTimer.Interval);
            }
            for (int i = 0; i < weponList.Count; i++)
            {
                weponList[i].Update(gameTimer.Interval);
            }
            for (int i = 0; i < explosionList.Count; i++)
            {
                explosionList[i].Update(gameTimer.Interval);
            }
            for (int i = 0; i < autoGunnerList.Count; i++)
            {
                autoGunnerList[i].Update(gameTimer.Interval);
            }
            veiwOffSet.X = (int)Player1.location.X - this.Width / 2;
            veiwOffSet.Y = (int)Player1.location.Y - this.Height / 2;
            OnPaint(new PaintEventArgs(windowsGraphics, new Rectangle(0, 0, this.Width, this.Height)));
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            levelNum = 1;
            Init();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            Init();
            gameTimer.Enabled = true;
            menuBackground.Hide();
            label1.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
