using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class Level
    {
        public static int mapBlockWidth;
        public static int mapBlockHeight;
        public static int mapWidth;
        public static int mapHeight;

        public static void initializeLists()
        {
            MainForm.bulletList = new List<Bullet>();
            MainForm.enemyList = new List<Soldier>();
            MainForm.wallList = new List<Wall>();
            MainForm.explosionList = new List<Explosion>();
            MainForm.weponList = new List<Wepon>();
            MainForm.autoGunnerList = new List<AutoGunner>();
        }

        public static void createWalls()
        {
            System.IO.StreamReader mapFile;
            if (MainForm.levelNum == 1)
                mapFile = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "/maps/test_map.txt");
            else
                mapFile = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "/maps/test_map.txt");

            string inputString = mapFile.ReadLine(); //first line of map txt file defines the map width in blocks
            mapBlockWidth = Convert.ToInt16(inputString); //converting to int
            mapWidth = mapBlockWidth * MainForm.blockSize; //defining varuable for actual map width

            inputString = mapFile.ReadLine();
            mapBlockHeight = Convert.ToInt16(inputString);
            mapHeight = mapBlockHeight * MainForm.blockSize;

            MainForm.levelMap = new String[mapBlockHeight];

            for (int i = 0; i < mapBlockHeight; i++)
                MainForm.levelMap[i] = mapFile.ReadLine();

            mapFile.Close();

            Wall[] walls1 = new Wall[100000];
            for (int i = 0; i < mapBlockHeight; i++)
            {
                String mapRow = MainForm.levelMap[i];
                for (int j = 0; j < mapBlockWidth; j++)
                {
                    String mapCell = mapRow.Substring(j, 1);
                    if (mapCell.Equals("1"))
                    {
                        walls1[(i * 100) + j] = new Wall("Blue1", j * MainForm.blockSize, i * MainForm.blockSize, MainForm.blockSize, MainForm.blockSize);
                    }
                }
            }

            MainForm.Player1.location = new PointF(80, 80);

            Wall BoarderTop = new Wall("Green", 0, 0, mapBlockWidth * 100 + 80, 80);
            Wall BoarderLeft = new Wall("Green", -80, 0, 80, mapBlockHeight * 100 + 0);
            Wall BoarderRight = new Wall("Green", mapBlockWidth * 100, -80, 80, mapBlockWidth * 100 + 80);
            Wall BoarderBottom = new Wall("Green", 0, mapBlockHeight * 100, mapBlockWidth * 100 + 80, 80);
        }
        
        public static void createEnemys()
        {
            //MainForm.Player1 = new Player(new PointF(1000, 1000));
            if (MainForm.levelNum == 1)
            {
                Enemy e1 = new Enemy(new PointF(2200, 2000)); //room 1
                Enemy e2 = new Enemy(new PointF(2250, 2300)); //room 1
                Enemy e3 = new Enemy(new PointF(2095, 2100)); //hallway 1
                Enemy e4 = new Enemy(new PointF(2000, 1150)); //room 2
                Enemy e5 = new Enemy(new PointF(2200, 1300)); //room 2
                Enemy e6 = new Enemy(new PointF(2150, 1350)); //room 2
                Enemy e7 = new Enemy(new PointF(2300, 1200)); //room 2
            }
            else if (MainForm.levelNum == 2)
            {
                MainForm.Player1.location = new PointF(2300, 1750);
                Enemy e1 = new Enemy(new PointF(2200, 2000));
            }
        }

        public static void createWepon()
        {
            if (MainForm.levelNum == 1)
            {
                RapidGun rg1 = new RapidGun(new PointF(2360, 1915)); // outside spawn room
                EnemyPistol ep1 = new EnemyPistol(new PointF(2165, 2370));  // ouside room 1
                AutoGun ag1 = new AutoGun(new PointF(2100, 1600));  // outside room 2

                ep1.onGround = true;
                rg1.onGround = true;
                ag1.onGround = true;

                MainForm.weponList.Add(ep1);
                MainForm.weponList.Add(rg1);
                MainForm.weponList.Add(ag1);
            }
        }

        public static void createLevel()
        {
            initializeLists();
            //createEnemys();
            createWalls();
            //createWepon();
        }
    }
}
