using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeans
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        const float e = 2.718f;

        const int zoneNumber = 3;
        int[] mX = new int[zoneNumber];
        int[] mY = new int[zoneNumber];
        int[] sigmaX = new int[zoneNumber];
        int[] sigmaY = new int[zoneNumber];

        int pointsNr = 0;
        Point[] point;
        const int Kcount = 4;
        Centroid[] K = new Centroid[Kcount];
        int rndZone = 0;

        static string workingDirectory = Environment.CurrentDirectory;
        string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\pointsList.txt";
        List<string> pointDetails = new List<string>();
        int count = 0;
        int age = 0;

        public Form1()
        {
            InitializeComponent();
            mX[0] = 180; mY[0] = 220;
            sigmaX[0] = 10; sigmaY[0] = 10;

            mX[1] = -100; mY[1] = 110;
            sigmaX[1] = 15; sigmaY[1] = 10;

            mX[2] = 210; mY[2] = -150;
            sigmaX[2] = 5; sigmaY[2] = 20;

            
        }

        public double Gauss(int x, int zoneM, int zoneSigma)
        {
            double above = (zoneM - x) * (zoneM - x);
            double under = 2 * (zoneSigma * zoneSigma);
            double power = -(above / under);
            return Math.Pow(e, power);
        }
        private void GeneratePointX()
        {
            rndZone = rnd.Next(zoneNumber);
            int rndX = rnd.Next(-300, 300);
            double G = Gauss(rndX, mX[rndZone], sigmaX[rndZone]);
            double prag = rnd.Next(0, (int)Math.Pow(2, 10)) / Math.Pow(2, 10);

            if (G > prag) { GeneratePointY(rndX); }
            else { GeneratePointX(); }
        }
        private void GeneratePointY(int rndX)
        {
            int rndY = rnd.Next(-300, 300);
            double G = Gauss(rndY, mY[rndZone], sigmaY[rndZone]);
            double prag = rnd.Next(0, (int)Math.Pow(2, 10)) / Math.Pow(2, 10);

            if (G > prag)
            {
                DrawPoint(rndX, rndY, Color.Black);
                pointDetails.Add("(" + rndX + "," + rndY + "," + rndZone + ") - " + count);
                count++;
            }
            else { GeneratePointY(rndX); }
        }

        public void DrawLines()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            g.DrawLine(p, 0, 300, 599, 300); //x
            g.DrawLine(p, 300, 0, 300, 599); //y
            g.DrawLine(p, 0, 0, 599, 0);
            g.DrawLine(p, 0, 599, 599, 599);
            g.DrawLine(p, 0, 0, 0, 599);
            g.DrawLine(p, 599, 0, 599, 599);
        }
        public void DrawPoint(int X, int Y, Color colour)
        {
            int pointSize = Int32.Parse(textBox_pointSize.Text); // = 1
            var (screenX, screenY) = conversionToScreen(X, Y);
            Graphics g = panel1.CreateGraphics();
            g.FillRectangle(new SolidBrush(colour), screenX, screenY, pointSize, pointSize);
        }
        private void DrawCentroid(int X, int Y, Color colour)
        {
            int screenX = conversionToScreen(X, Y).Item1;
            int screenY = conversionToScreen(X, Y).Item2;
            Graphics gr = panel1.CreateGraphics();
            gr.FillEllipse(new SolidBrush(colour), screenX, screenY, 10, 10);
        }
        private (int, int) conversionToScreen(int rndX, int rndY)
        {
            int screenX = rndX + (panel1.Width / 2);
            int screenY = -rndY + (panel1.Height / 2);
            return (screenX, screenY);
        }
        private double calcDist(Point point, Centroid centroid)
        {
            int a = centroid.getX() - point.getX();
            int b = centroid.getY() - point.getY();
            return Math.Sqrt((a * a) + (b * b));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_Generate.Enabled = false;
            double oldE = 0, newE = 1;
            pointsNr = Int32.Parse(textBox_pointsNr.Text);
            point = new Point[pointsNr];
            RefreshPanelAndTextFile();
            GeneratePoints();
            ParseTextFileForPointsDetails();
            GenerateKCentroids();
            while (oldE!=newE)
            {
                labelAge.Refresh();
                oldE = newE;
                GroupEachPointToCentroid();
                //centru de greutate 
                CalculateMassCenter();
                System.Threading.Thread.Sleep(1000);
                //Move K centroids in new calculated positions
                RedrawPointsAndCentroids();
                newE = FunctieConvergenta();
                age++;
                labelAge.Text = "Epoca: " + age.ToString();
            }
            button_Generate.Enabled = true;
            labelAge.Text = "Epoca: " + age.ToString();
        }


        private double FunctieConvergenta()
        {
            double sum = 0;
            for (int i = 0; i < Kcount; i++)
            {
                for (int j = 0; j < K[i].GetPointsList().Count; j++)
                {
                    int tempX = K[i].GetPointsList().ElementAt(j).getX();
                    int tempY = K[i].GetPointsList().ElementAt(j).getY();
                    Point tempPoint = new Point(tempX, tempY);
                    sum = sum + calcDist(tempPoint, K[i]);
                }
            }
            return sum;
        }
        private void GeneratePoints()
        {
            for (int i = 0; i < pointsNr; i++) { GeneratePointX(); }
            File.WriteAllLines(path, pointDetails);
        }
        private void ParseTextFileForPointsDetails()
        {
            string[] parsedDetails = new string[pointsNr];
            parsedDetails = File.ReadAllLines(path);
            for (int i = 0; i < pointsNr; i++)
            {
                //get each point coordinates
                int indexX = parsedDetails[i].IndexOf(',');
                int parsedX = Int32.Parse(parsedDetails[i].Substring(1, indexX - 1));
                int indexY = parsedDetails[i].IndexOf(',', parsedDetails[i].IndexOf(',') + 1);
                int parsedY = Int32.Parse(parsedDetails[i].Substring(indexX + 1, indexY - (indexX + 1)));
                point[i] = new Point(parsedX, parsedY);
            }
        }
        private void GenerateKCentroids()
        {
            for (int i = 0; i < Kcount; i++)
            {
                Color colour = Color.Black;
                switch (i)
                {
                    case 0: { colour = Color.Red; break; }
                    case 1: { colour = Color.Green; break; }
                    case 2: { colour = Color.Blue; break; }
                    case 3: { colour = Color.Yellow; break; }
                }
                K[i] = new Centroid(
                    rnd.Next(-300, 300),    //centroidX
                    rnd.Next(-300, 300),    //centroidY
                    colour                  //centroidColour
                    );
                DrawCentroid(K[i].getX(), K[i].getY(), K[i].getColour());
            }
        }
        private void GroupEachPointToCentroid()
        {
            for (int j = 0; j < Kcount; j++)
            {
                K[j].clearPointsList();
            }
                for (int i = 0; i < pointsNr; i++)
            {
                //calculate closest K centroid to each point (smallest distance)
                Centroid closestK = K[0];
                double distancePointToCentroid = calcDist(point[i], K[0]);
                for (int j = 1; j < Kcount; j++)
                {
                    double temporaryDist = calcDist(point[i], K[j]);
                    if (temporaryDist < distancePointToCentroid)
                    {
                        distancePointToCentroid = temporaryDist;
                        closestK = K[j];
                    }
                }
                //recolour point based on closest K centroid
                point[i].setColour(closestK.getColour());
                if (age == 0)
                {
                    DrawPoint(point[i].getX(), point[i].getY(), point[i].getColour());
                }
                //"link" each point to a K centroid
                for (int j = 0; j < Kcount; j++)
                {
                    if (closestK == K[j])
                    {
                        K[j].addPointToCentroid(point[i]);
                    }
                }
            }
        }
        private void CalculateMassCenter()
        {
            for (int j = 0; j < Kcount; j++)
            {
                List<int> averageX = new List<int>();
                List<int> averageY = new List<int>();
                for (int i = 0; i < K[j].GetPointsList().Count(); i++)
                {
                    averageX.Add(K[j].GetPointsList().ElementAt(i).getX());
                    averageY.Add(K[j].GetPointsList().ElementAt(i).getY());
                }
                if (averageX.Count > 0)
                {
                    double newX = averageX.Average();
                    K[j].setX((int)newX);
                }
                if (averageX.Count > 0)
                {
                    double newY = averageY.Average();
                    K[j].setY((int)newY);
                }
            }
        }
        private void RedrawPointsAndCentroids()
        {
            panel1.Refresh();
            DrawLines();
            for (int i = 0; i < pointsNr; i++)
            {
                DrawPoint(point[i].getX(), point[i].getY(), point[i].getColour());
            }
            for (int j = 0; j < Kcount; j++)
            {
                DrawCentroid(K[j].getX(), K[j].getY(), K[j].getColour());
            }
            System.Threading.Thread.Sleep(100);
        }
        private void RefreshPanelAndTextFile()
        {
            count = 0;
            panel1.Refresh();
            DrawLines();
            File.Delete(path);
            pointDetails.Clear();
        }
    }
}