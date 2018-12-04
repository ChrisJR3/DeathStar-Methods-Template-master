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
                else { Explosion(155, 155, 200); }

                onScreen.DrawImage(bm, 0, 0);
            }
        }

        public void Xwing(float x, float y, float width, float height)
        {
            Pen shipPen = new Pen(Color.White);
            Pen trailPen = new Pen(Color.Orange);
            Pen redPen = new Pen(Color.Red);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            //Nose of ship
            offScreen.DrawLine(shipPen, x, y + height / 2, x + width / 10, y + height * 3 / 8);
            offScreen.DrawLine(shipPen, x, y + height / 2, x + width / 10, y + height * 5 / 8);

            //Line-connectors
            offScreen.DrawLine(shipPen, x + width / 10, y + height * 3 / 8, x + width / 10, y + height * 13 / 32);
            offScreen.DrawLine(shipPen, x + width / 10, y + height * 5 / 8, x + width / 10, y + height * 19 / 32);

            //Main lines
            offScreen.DrawLine(shipPen, x + width / 10, y + height * 13 / 32, x + width * 7 / 16, y + height * 2 / 6);
            offScreen.DrawLine(shipPen, x + width / 10, y + height * 19 / 32, x + width * 4 / 6, y + height * 9 / 15);

            //Cockpit
            offScreen.DrawArc(shipPen, x + width * 7 / 16, y + height * 1 / 5, width * 11 / 50, height * 3 / 15, 180, 180);

            //Cockit-Cockpit-wing
            offScreen.DrawLine(shipPen, x + width * 4 / 6, y + height * 2 / 6, x + width * 5 / 6, y + height * 2 / 6);

            //Cockit-wing
            offScreen.DrawLine(shipPen, x + width * 5 / 6, y + height * 2 / 6, x + width * 5 / 6, y + height * 2 / 15);

            //Upper gun
            offScreen.DrawLine(shipPen, x + width * 3 / 8, y + height * 2 / 15, x + width * 7 / 8, y + height * 2 / 15);

            //Upper secondary gun
            offScreen.DrawLine(shipPen, x + width * 3 / 8, y + height / 15, x + width * 5 / 6, y + height / 15);

            //Upper gun > part
            offScreen.DrawLine(shipPen, x + width * 4 / 8, y + height * 2 / 15, x + width * 3 / 8, y + height * 1 / 15);
            offScreen.DrawLine(shipPen, x + width * 4 / 8, y + height * 2 / 15, x + width * 3 / 8, y + height * 3 / 15);

            //Back of ship
            offScreen.DrawLine(shipPen, x + width * 7 / 8, y + height * 2 / 15, x + width * 7 / 8, y + height * 12 / 15);

            //Trail
            offScreen.DrawLine(trailPen, x + width * 7 / 8, y + height * 4 / 15, x + width, y + height * 5 / 15);
            offScreen.DrawLine(trailPen, x + width * 7 / 8, y + height * 6 / 15, x + width, y + height * 5 / 15);
            offScreen.DrawLine(trailPen, x + width * 7 / 8, y + height * 9 / 15, x + width, y + height * 10 / 15);
            offScreen.DrawLine(trailPen, x + width * 7 / 8, y + height * 11 / 15, x + width, y + height * 10 / 15);

            //Lower gun
            offScreen.DrawLine(shipPen, x + width * 3 / 8, y + height * 12 / 15, x + width * 7 / 8, y + height * 12 / 15);

            //Secondary Lower gun
            offScreen.DrawLine(shipPen, x + width * 3 / 8, y + height * 11 / 15, x + width * 4 / 6, y + height * 11 / 15);

            //Lower gun connector
            offScreen.DrawLine(shipPen, x + width * 4 / 6, y + height * 12 / 15, x + width * 4 / 6, y + height * 9 / 15);

            //Upper gun > part
            offScreen.DrawLine(shipPen, x + width * 4 / 8, y + height * 12 / 15, x + width * 3 / 8, y + height * 11 / 15);
            offScreen.DrawLine(shipPen, x + width * 4 / 8, y + height * 12 / 15, x + width * 3 / 8, y + height * 13 / 15);

            //Cockpit bottom line
            offScreen.DrawLine(shipPen, x + width * 7 / 16, y + height *7 / 20, x + width * 22 / 32, y + height * 7 / 20);

            //Red Bars
            offScreen.FillRectangle(drawBrush, x + width * 2 / 10, y + height * 15 / 32, width * 2 / 10, height * 2 / 32);
            offScreen.FillRectangle(drawBrush, x + width * 4 / 10, y + height * 15 / 32, width * 3 / 10, height * 2 / 32);
        }

        public void Torpedo(float x, float y, float pixels)
        {
            Pen torpPen = new Pen(Color.White);
            Pen torpPen3 = new Pen(Color.Red);
            Pen torpPen2 = new Pen(Color.Blue);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            float scale = pixels / 100;

            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            offScreen.DrawEllipse(torpPen3, x, y, pixels, pixels);
            offScreen.FillEllipse(drawBrush, x, y, pixels, pixels);
            offScreen.DrawLine(torpPen2, 40 * scale + x, 40 * scale + y, 40 * scale + x, 60 * scale + y);
            offScreen.DrawLine(torpPen2, 40 * scale + x, 40 * scale + y, 60 * scale + x, 40 * scale + y);
            offScreen.DrawLine(torpPen2, 60 * scale + x, 40 * scale + y, 60 * scale + x, 60 * scale + y);
            offScreen.DrawLine(torpPen2, 60 * scale + x, 60 * scale + y, 40 * scale + x, 60 * scale + y);
        }

        public void Explosion(float x, float y, float pixels)
        {
            Pen exPen = new Pen(Color.Orange);
            Pen exPenInner = new Pen(Color.Yellow);
            Pen exPenCircle = new Pen(Color.Red);
            float Scale = (pixels / 236);
            /// Use the rectangle below for testing purposes. 
            /// Your shape should always draw within this rectangle, reglardless of size and position.
            /// Comment it out when you are done.
            //offScreen.DrawRectangle(exPen, x, y, pixels, pixels);

            //Circles
            offScreen.DrawEllipse(exPenCircle, (15 * Scale) + x, (15 * Scale) + y, (10 * Scale), (10 * Scale));
            offScreen.DrawEllipse(exPenCircle, (211 * Scale) + x, (137 * Scale) + y, (10 * Scale), (10 * Scale));
            offScreen.DrawEllipse(exPenCircle, (35 * Scale) + x, (175 * Scale) + y, (10 * Scale), (10 * Scale));
            offScreen.DrawEllipse(exPenCircle, (171 * Scale) + x, (198 * Scale) + y, (10 * Scale), (10 * Scale));
            offScreen.DrawEllipse(exPenCircle, (210 * Scale) + x, (52 * Scale) + y, (10 * Scale), (10 * Scale));

            //Outline
            offScreen.DrawLine(exPen, (109 * Scale) + x - 5, (23 * Scale) + y, (99 * Scale) + x - 5, (57 * Scale) + y);
            offScreen.DrawLine(exPen, (44 * Scale) + x - 5, (22 * Scale) + y, (99 * Scale) + x - 5, (57 * Scale) + y);
            offScreen.DrawLine(exPen, (44 * Scale) + x - 5, (22 * Scale) + y, (70 * Scale) + x - 5, (79 * Scale) + y);
            offScreen.DrawLine(exPen, (22 * Scale) + x - 5, (80 * Scale) + y, (70 * Scale) + x - 5, (79 * Scale) + y);
            offScreen.DrawLine(exPen, (22 * Scale) + x - 5, (80 * Scale) + y, (60 * Scale) + x - 5, (111 * Scale) + y);
            offScreen.DrawLine(exPen, (18 * Scale) + x - 5, (145 * Scale) + y, (60 * Scale) + x - 5, (111 * Scale) + y);
            offScreen.DrawLine(exPen, (18 * Scale) + x - 5, (145 * Scale) + y, (71 * Scale) + x - 5, (157 * Scale) + y);
            offScreen.DrawLine(exPen, (54 * Scale) + x - 5, (203 * Scale) + y, (71 * Scale) + x - 5, (157 * Scale) + y);
            offScreen.DrawLine(exPen, (54 * Scale) + x - 5, (203 * Scale) + y, (104 * Scale) + x - 5, (179 * Scale) + y);
            offScreen.DrawLine(exPen, (140 * Scale) + x - 5, (212 * Scale) + y, (104 * Scale) + x - 5, (179 * Scale) + y);
            offScreen.DrawLine(exPen, (140 * Scale) + x - 5, (212 * Scale) + y, (158 * Scale) + x - 5, (170 * Scale) + y);
            offScreen.DrawLine(exPen, (240 * Scale) + x - 5, (179 * Scale) + y, (158 * Scale) + x - 5, (170 * Scale) + y);
            offScreen.DrawLine(exPen, (240 * Scale) + x - 5, (179 * Scale) + y, (186 * Scale) + x - 5, (132 * Scale) + y);
            offScreen.DrawLine(exPen, (232 * Scale) + x - 5, (99 * Scale) + y, (186 * Scale) + x - 5, (132 * Scale) + y);
            offScreen.DrawLine(exPen, (232 * Scale) + x - 5, (99 * Scale) + y, (177 * Scale) + x - 5, (86 * Scale) + y);
            offScreen.DrawLine(exPen, (178 * Scale) + x - 5, (16 * Scale) + y, (177 * Scale) + x - 5, (86 * Scale) + y);
            offScreen.DrawLine(exPen, (178 * Scale) + x - 5, (16 * Scale) + y, (140 * Scale) + x - 5, (62 * Scale) + y);
            offScreen.DrawLine(exPen, (109 * Scale) + x - 5, (23 * Scale) + y, (140 * Scale) + x - 5, (62 * Scale) + y);

            //Inside
            offScreen.DrawLine(exPenInner, (118 * Scale) + x, (67 * Scale) + y + 3, (111 * Scale) + x, (85 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (87 * Scale) + x, (73 * Scale) + y + 3, (111 * Scale) + x, (85 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (87 * Scale) + x, (73 * Scale) + y + 3, (100 * Scale) + x, (94 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (64 * Scale) + x, (93 * Scale) + y + 3, (100 * Scale) + x, (94 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (64 * Scale) + x, (93 * Scale) + y + 3, (90 * Scale) + x, (111 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (68 * Scale) + x, (134 * Scale) + y + 3, (90 * Scale) + x, (111 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (68 * Scale) + x, (134 * Scale) + y + 3, (104 * Scale) + x, (124 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (96 * Scale) + x, (160 * Scale) + y + 3, (104 * Scale) + x, (124 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (96 * Scale) + x, (160 * Scale) + y + 3, (118 * Scale) + x, (137 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (142 * Scale) + x, (149 * Scale) + y + 3, (118 * Scale) + x, (137 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (142 * Scale) + x, (149 * Scale) + y + 3, (136 * Scale) + x, (127 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (165 * Scale) + x, (109 * Scale) + y + 3, (136 * Scale) + x, (127 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (165 * Scale) + x, (109 * Scale) + y + 3, (142 * Scale) + x, (98 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (154 * Scale) + x, (77 * Scale) + y + 3, (142 * Scale) + x, (98 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (154 * Scale) + x, (77 * Scale) + y + 3, (130 * Scale) + x, (84 * Scale) + y + 3);
            offScreen.DrawLine(exPenInner, (118 * Scale) + x, (67 * Scale) + y + 3, (130 * Scale) + x, (84 * Scale) + y + 3);
        }

        public void DeathStar(float x, float y, float pixels)
        {
            //Pens and Brushes
            Pen deathPen = new Pen(Color.White);
            Pen testPen = new Pen(Color.Red);
            Pen gunPen = new Pen(Color.LimeGreen, 2);
            SolidBrush beamBrush = new SolidBrush(Color.LightBlue);
            Pen laserPen = new Pen(Color.LimeGreen, 4);
            Pen superlaserPen = new Pen(Color.LimeGreen, 6);


            //Scale for adjusting
            float scale = pixels / 400;

            //testing rectangle, Size and Coordinates must stay inside it
            //offScreen.DrawRectangle(deathPen, x, y, pixels, pixels);

            //arc of DeathStar
            offScreen.DrawArc(deathPen, x, y, pixels, pixels, 281, 338);

            //top half rectangle of the DeathStar
            offScreen.DrawLine(deathPen, (163 * scale) + x, (4 * scale) + y, (163 * scale) + x, (30 * scale) + y);
            offScreen.DrawLine(deathPen, (238 * scale) + x, (4 * scale) + y, (238 * scale) + x, (30 * scale) + y);
            offScreen.DrawLine(deathPen, (163 * scale) + x, (30 * scale) + y, (238 * scale) + x, (30 * scale) + y);

            //Gun of DeathStar
            //Circles 
            offScreen.DrawEllipse(deathPen, (260 * scale) + x, (110 * scale) + y, 90 * scale, 120 * scale); //first
            offScreen.DrawEllipse(deathPen, (300 * scale) + x, (155 * scale) + y, 20 * scale, 30 * scale);  //third
            offScreen.DrawEllipse(deathPen, (268 * scale) + x, (118 * scale) + y, 75 * scale, 105 * scale); //second
            offScreen.FillEllipse(beamBrush, (305 * scale) + x, (160 * scale) + y, 10 * scale, 20 * scale); //fourth

            //Lasers
            offScreen.DrawLine(laserPen, (310 * scale) + x, (170 * scale) + y, (360 * scale) + x, (110 * scale) + y);
            offScreen.DrawLine(gunPen, (310 * scale) + x, (110 * scale) + y, (360 * scale) + x, (110 * scale) + y); //1
            offScreen.DrawLine(gunPen, (337 * scale) + x, (212 * scale) + y, (360 * scale) + x, (110 * scale) + y); //2
            offScreen.DrawLine(gunPen, (270 * scale) + x, (130 * scale) + y, (360 * scale) + x, (110 * scale) + y); //3
            offScreen.DrawLine(gunPen, (297 * scale) + x, (231 * scale) + y, (360 * scale) + x, (110 * scale) + y); //4
            offScreen.DrawLine(gunPen, (260 * scale) + x, (160 * scale) + y, (360 * scale) + x, (110 * scale) + y); //5
            offScreen.DrawLine(gunPen, (268 * scale) + x, (205 * scale) + y, (360 * scale) + x, (110 * scale) + y); //6
            offScreen.DrawLine(superlaserPen, (360 * scale) + x, (110 * scale) + y, (390 * scale) + x, (80 * scale) + y);
        }

        public void ExhaustPort(float x, float y, float width, float height)
        {
            //Pen Colors Red & White
            Pen exPen = new Pen(Color.White);
            Pen rPen = new Pen(Color.Red);

            //Resize Variable
            float reSw = width / 20;
            float reSh = height / 205;

            //Exterior Exhaust
            offScreen.DrawLine(rPen, 7 * reSw + x, 0 * reSh + y, 7 * reSw + x, 187 * reSh + y);
            offScreen.DrawLine(rPen, 13 * reSw + x, 0 * reSh + y, 13 * reSw + x, 187 * reSh + y);
            offScreen.DrawArc(rPen, 2 * reSw + x, 187 * reSh + y, 16 * reSw, 16 * reSh, -120, -300);

            //Exterior Exhaust
            offScreen.DrawLine(exPen, 5 * reSw + x, 4 * reSh + y, 5 * reSw + x, 186 * reSh + y);
            offScreen.DrawLine(exPen, 15 * reSw + x, 4 * reSh + y, 15 * reSw + x, 186 * reSh + y);
            offScreen.DrawArc(exPen, 0 * reSw + x, 185 * reSh + y, 20 * reSw, 20 * reSh, -120, -300);

            //Open Exhaust
            offScreen.DrawLine(exPen, 7 * reSw + x, 0 * reSh + y, 0 * reSw + x, 18 * reSh + y);
            offScreen.DrawLine(exPen, 0 * reSw + x, 18 * reSh + y, 5 * reSw + x, 22 * reSh + y);
            offScreen.DrawLine(exPen, 13 * reSw + x, 0 * reSh + y, 20 * reSw + x, 18 * reSh + y);
            offScreen.DrawLine(exPen, 20 * reSw + x, 18 * reSh + y, 15 * reSw + x, 22 * reSh + y);
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
            Xwing(0, 0, 200, 100);


            // Draws to the screen 
            onScreen.DrawImage(bm, 0, 0);
        }
    }
}
