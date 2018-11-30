/// Created by Mr. T. 
/// August 2017
/// 
/// This program is used as a template to test the draw methods that each student will
/// create and then combine into one group project. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Media;

namespace DeathStarExhaustPort
{
    public partial class MainForm : Form
    {
        Graphics onScreen;

        Bitmap bm; //bitmap area size of whole screen
        Graphics offScreen; //Sets off-screen graphics to the bitmap

        public MainForm()
        {
            InitializeComponent();

            onScreen = this.CreateGraphics();
            bm = new Bitmap(this.Width, this.Height); //bitmap area size of whole screen
            offScreen = Graphics.FromImage(bm); //Sets off-screen graphics to the bitmap
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            SoundPlayer player;

            int shipX = 360;
            int shipY = 25;

            int torpedoX = 265;
            int torpedoY = 35;

            // ************************** X wing fly in **************************
            for (int x = 0; x < 10; x++)
            {
                shipX = shipX - 10;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);              

                DeathStar(55, 55, 400);

                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** X - wing fly out and torpedo fly in  **************************
            player = new SoundPlayer(Properties.Resources.torpedo);
            player.Play();

            for (int x = 0; x < 4; x++)
            {
                shipX -= 8;
                shipY -= 9;

                torpedoX -= 5;
                torpedoY += 5;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 10);
                Torpedo(torpedoX, torpedoY, 20);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** torpedo drop **************************
            for (int x = 0; x < 38; x++)
            {
                torpedoY += 5;

                Thread.Sleep(50);
                offScreen.Clear(Color.Black);
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);
                Xwing(shipX, shipY, 30, 8);
                Torpedo(torpedoX, torpedoY, 20);

                onScreen.DrawImage(bm, 0, 0);
            }

            // ************************** Explosion **************************
            player = new SoundPlayer(Properties.Resources.explosion);
            player.Play();

            for (int x = 1; x < 10; x++)
            {
                Thread.Sleep(150);
                offScreen.Clear(Color.Black);             
                
                DeathStar(55, 55, 400);
                ExhaustPort(245, 62, 20, 205);               

                if (x % 2 == 0) { Explosion(205, 205, 100); }
                else            { Explosion(155, 155, 200); }

                onScreen.DrawImage(bm, 0, 0);
            }
        }

        public void Xwing(float x, float y, float width, float height)
        {
            Pen shipPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(shipPen, x, y, width, height);

        }

        public void Torpedo(float x, float y, float pixels)
        {
            Pen torpPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(torpPen, x, y, pixels, pixels);
        }

        public void Explosion(float x, float y, float pixels)
        {
            Pen exPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(exPen, x, y, pixels, pixels);           
        }

        public void DeathStar(float x, float y, float pixels)
        {
            Pen deathPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawEllipse(deathPen, x, y, pixels, pixels);
        }

        public void ExhaustPort(float x, float y, float width, float height)
        {
            Pen exPen = new Pen(Color.White);

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawRectangle(exPen, x, y, width, height);
        }

        private void fullButton_Click(object sender, EventArgs e)
        {
            MainForm_Click(sender, e);
        }

        private void partButton_Click(object sender, EventArgs e)
        {
            offScreen.Clear(Color.Black); // do not remove

            /// Call your method here. This is where you can adjust the location and size 
            /// to make sure that it draws on the screen correctly.
            Xwing(0, 0, 100, 50);


            // Draws to the screen 
            onScreen.DrawImage(bm, 0, 0);
        }
    }
}
