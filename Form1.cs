using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace BACKROOMS
{
    public partial class Form1 : Form
    {

        readonly Random rand = new Random();

        Point playerPosition = new Point(0, 0);

        int tileSize = 30;
        int tileCount;
        int level = 0;
        int floorRate = 7;
        int darkRange = 120;

        int wMin = 5;
        int wMax = 20;
        int lMin = 10;
        int lMax = 20;

        int genLength = 10;
        int genWidth = 10;

        bool busy = false;

        bool dark = false;
        bool walls = true;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        Color floorColor = Color.Gold;
        Color wallColor = Color.Goldenrod;
        Color exitColor = Color.Green;
        Color doorColor = Color.Brown;

        List<PictureBox> tiles = new List<PictureBox>();

        private void darknessUpdate()
        {
            if (dark == false)
            {
                return;
            }
            else
            {
                foreach (PictureBox b in tiles)
                {
                    try
                    {
                        if (b.Name == "darkTile" && (Math.Pow(playerPosition.X - b.Location.X, 2) + Math.Pow(playerPosition.Y - b.Location.Y, 2) < (darkRange*darkRange)) )
                        {
                            int tileType = rand.Next(1, 10);

                            if (tileType <= floorRate)
                            {
                                b.Name = "floorTile";
                                b.BackColor = floorColor;
                            }
                            else if (tileType > floorRate && tileType <= 10 && b.Location != playerPosition)
                            {
                                b.Name = "wallTile";
                                b.BackColor = wallColor;
                            }
                            if ((b.Location == new Point(0, b.Location.Y) || b.Location == new Point(tileSize * genWidth, b.Location.Y) || b.Location == new Point(b.Location.X, 0) || b.Location == new Point(b.Location.X, tileSize * genLength)) && walls == true)
                            {
                                if (rand.Next(1, 10) == 1)
                                {
                                    b.Name = "doorTile";
                                    b.BackColor = doorColor;
                                }
                                else
                                {
                                    if (b.Location != playerPosition)
                                    {
                                        b.Name = "wallTile";
                                        b.BackColor = wallColor;
                                    }
                                }
                            }
                            else if (rand.Next(1, 1000) == 1)
                            {
                                b.Name = "exitTile";
                                b.BackColor = exitColor;
                            }
                        }
                    }
                    catch
                    {
                        Close();
                        return;
                    }

                }
            }
        }

        private void levelUpdate()
        {
            levelDisplay.Text = $"LEVEL {level}";
            if (level == 0)
            {
                floorColor = Color.Gold;
                wallColor = Color.Goldenrod;
                doorColor = Color.Brown;
                floorRate = 8;
                dark = false;
                walls = true;
                lMin = 10;
                lMax = 20;
                wMin = 5;
                wMax = 20;
            }
            else if (level == 1)
            {
                floorColor = Color.Silver;
                wallColor = Color.DimGray;
                doorColor = Color.Beige;
                floorRate = 8;
                darkRange = 90;
                dark = true;
                walls = false;
                lMin = 10;
                lMax = 20;
                wMin = 10;
                wMax = 20;
            }
            else if (level == 2)
            {
                floorColor = Color.DimGray;
                wallColor = Color.DarkGray;
                doorColor = Color.Silver;
                floorRate = 7;
                darkRange = 60;
                dark = true;
                walls = true;
                lMin = 10;
                lMax = 15;
                wMin = 10;
                wMax = 15;
            }
            else if (level == 3)
            {
                int r = rand.Next(1, 2);
                floorColor = Color.DimGray;
                wallColor = Color.Salmon;
                doorColor = Color.DarkGray;
                floorRate = 8;
                darkRange = 120;
                if (rand.Next(1,10) == 1)
                {
                    dark = true;
                }
                else
                {
                    dark = false;
                }
                walls = true;
                lMin = 10;
                lMax = 20;
                wMin = 10;
                wMax = 20;
            }
        }

        private void generate()
        {
            busy = true;
            Refresh();
            foreach (PictureBox b in tiles)
            {
                b.Dispose();
            }

            tileCount = 0;
            tiles.Clear();

            Refresh();
            Thread.Sleep(10);

            genLength = rand.Next(lMin, lMax);
            genWidth = rand.Next(wMin, wMax);

            tileCount = genWidth * genLength;

            for (int r = 0; r < genWidth; r++)
            {
                for (int i = 0; i < genLength; i++)
                {
                    int tileType = rand.Next(1, 10);

                    levelUpdate();
                    //darknessUpdate();

                    PictureBox tile = new System.Windows.Forms.PictureBox();
                    this.SuspendLayout();

                    tile.Name = $"tile{i}";
                    tile.Size = new System.Drawing.Size(tileSize, tileSize);
                    tile.Location = new System.Drawing.Point(tileSize * i, r * tileSize);
                    tile.TabIndex = 0;
                    tile.Text = "";
                   // tile.UseVisualStyleBackColor = true;
                   // tile.FlatStyle = FlatStyle.Flat;
                   // tile.FlatAppearance.BorderSize = 0;
                    tiles.Add(tile);

                    this.Controls.Add(tile);
                    if (dark == false)
                    {
                        if (tileType <= floorRate)
                        {
                            tile.BackColor = floorColor;
                            tile.Name = "floorTile";
                        }
                        else if (tileType > floorRate && tileType <= 10)
                        {
                            if (rand.Next(1, 10) == 1)
                            {
                                tile.BackColor = doorColor;
                                tile.Name = "doorTile";
                            }
                            else
                            {
                                tile.BackColor = wallColor;
                                tile.Name = "wallTile";
                            }
                        }
                        if ((r == 0 || r == genWidth - 1 || i == 0 || i == genLength - 1) && walls == true)
                        {
                            if (rand.Next(1, 10) == 1)
                            {
                                tile.BackColor = doorColor;
                                tile.Name = "doorTile";
                            }
                            else
                            {
                                tile.BackColor = wallColor;
                                tile.Name = "wallTile";
                            }
                        }
                        else if (rand.Next(1, 5000) == 1)
                        {
                            tile.BackColor = exitColor;
                            tile.Name = "exitTile";
                        }
                    }
                    else if (dark == true)
                    {
                        tile.Name = "darkTile";
                        tile.BackColor = Color.Black;
                    }
                }
            }

            Refresh();
            Thread.Sleep(10);
            updateReal("reg");

            busy = false;
        }

        private void updateReal(string direction)
        {
            try
            {
                darknessUpdate();

                if (direction == "reg")
                {
                    busy = true;
                    foreach (PictureBox b in tiles)
                    {
                        if (dark == false)
                        {
                            PictureBox tileUp = tiles.Find(t => t.Location == new Point(playerPosition.X, playerPosition.Y - tileSize));
                            PictureBox tileDown = tiles.Find(t => t.Location == new Point(playerPosition.X, playerPosition.Y + tileSize));
                            PictureBox tileLeft = tiles.Find(t => t.Location == new Point(playerPosition.X - tileSize, playerPosition.Y));
                            PictureBox tileRight = tiles.Find(t => t.Location == new Point(playerPosition.X + tileSize, playerPosition.Y));

                            if (b != null && b.Name != "wallTile" && rand.Next(1,2) == 1 && ((tileUp != null && tileUp.Name != "wallTile") || (tileDown != null && tileDown.Name != "wallTile") || (tileLeft != null && tileLeft.Name != "wallTile") || (tileRight != null && tileRight.Name != "wallTile")))
                            {
                                playerPosition = b.Location;
                                playerPart.Location = new Point(b.Location.X + (tileSize / 4), b.Location.Y + (tileSize / 4));
                                return;
                            }
                        }
                        else
                        {
                            if (b != null && b.Name != "wallTile" && rand.Next(1,10) == 1)
                            {
                                playerPosition = b.Location;
                                playerPart.Location = new Point(b.Location.X + (tileSize / 4), b.Location.Y + (tileSize / 4));
                                return;
                            }
                        }
                    }
                    generate();
                    busy = false;
                }

                if (direction == "up")
                {
                    try
                    {
                        PictureBox playerTile = tiles.Find(b => b.Location == playerPosition);
                        PictureBox a = tiles.Find(b => b.Location == new Point(playerPosition.X, playerPosition.Y - tileSize));
                        if (a != null && a.Name != "wallTile")
                        {
                            playerPart.Location = new Point(a.Location.X + (tileSize / 4), a.Location.Y + (tileSize / 4));
                            playerPosition = a.Location;

                            if (a.BackColor == doorColor)
                            {
                                generate();
                            }

                            if (a.BackColor == exitColor)
                            {
                                level += 1;
                                Refresh();
                                Thread.Sleep(10);
                                generate();
                            }

                        }
                        else if (a == null)
                        {
                            generate();
                        }

                        
                    }
                    catch
                    {
                        generate();
                        return;
                    }

                }
                if (direction == "down")
                {
                    try
                    {
                        PictureBox a = tiles.Find(b => b.Location == new Point(playerPosition.X, playerPosition.Y + tileSize));
                        if (a != null && a.Name != "wallTile")
                        {
                            PictureBox playerTile = tiles.Find(b => b.Location == playerPosition);
                            playerPart.Location = new Point(a.Location.X + (tileSize / 4), a.Location.Y + (tileSize / 4));
                            playerPosition = a.Location;
                            if (a.BackColor == doorColor)
                            {
                                generate();
                            }
                            if (a.BackColor == exitColor)
                            {
                                level += 1;
                                Refresh();
                                Thread.Sleep(10);
                                generate();
                            }
                        }
                        else if (a == null)
                        {
                            generate();
                        }
                    }
                    catch
                    {
                        generate();
                        return;
                    }
                }
                if (direction == "left")
                {
                    try
                    {
                        PictureBox playerTile = tiles.Find(b => b.Location == playerPosition);
                        PictureBox a = tiles.Find(b => b.Location == new Point(playerPosition.X - tileSize, playerPosition.Y));
                        if (a != null && a.Name != "wallTile")
                        {
                            playerPart.Location = new Point(a.Location.X + (tileSize / 4), a.Location.Y + (tileSize / 4));
                            playerPosition = a.Location;
                            if (a.BackColor == doorColor)
                            {
                                generate();
                            }
                            if (a.BackColor == exitColor)
                            {
                                level += 1;
                                Refresh();
                                Thread.Sleep(10);
                                generate();
                            }
                        }
                        else if (a == null)
                        {
                            generate();
                        }
                    }
                    catch
                    {
                        generate();
                        return;
                    }
                }
                if (direction == "right")
                {
                    try
                    {
                        PictureBox a = tiles.Find(b => b.Location == new Point(playerPosition.X + tileSize, playerPosition.Y));
                        if (a != null && a.Name != "wallTile")
                        {
                            PictureBox playerTile = tiles.Find(b => b.Location == playerPosition);
                            playerPart.Location = new Point(a.Location.X + (tileSize / 4), a.Location.Y + (tileSize / 4));
                            playerPosition = a.Location;
                            if (a.BackColor == doorColor)
                            {
                                generate();
                            }
                            if (a.BackColor == exitColor)
                            {
                                level += 1;
                                Refresh();
                                Thread.Sleep(10);
                                generate();
                            }
                        }
                        else if (a == null)
                        {
                            generate();
                        }
                    }
                    catch
                    {
                        generate();
                        return;
                    }
                }
            }
            catch
            {
                generate();
                return;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (busy == false)
            {
                darknessUpdate();

                PictureBox playerTile = tiles.Find(b =>b.Location == playerPosition);

                if (playerTile == null)
                {
                    generate();
                }
                else if(playerTile.Name == "wallTile")
                {
                    generate();
                }

                if (upArrowDown == true)
                {
                    updateReal("up");
                }
                if (downArrowDown == true)
                {
                    updateReal("down");
                }
                if (leftArrowDown == true)
                {
                    updateReal("left");
                }
                if (rightArrowDown == true)
                {
                    updateReal("right");
                }
            }
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                leftArrowDown = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightArrowDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                upArrowDown = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downArrowDown = true;
            }
            Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }
    }
}
